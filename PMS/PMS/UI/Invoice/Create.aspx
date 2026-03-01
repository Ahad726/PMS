<%@ Page Title="New - Invoice" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="PMS.UI.Invoice.Create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #itemTable {
            width: 100%;
            border-collapse: collapse;
        }

            #itemTable td {
                border: 1px solid #ccc;
                text-align: left;
            }


            #itemTable th {
                background-color: #f5f5f5;
                border: 1px solid #ccc;
                padding: 8px;
                text-align: left;
            }

            #itemTable td input, select {
                border: none;
            }

        #MainContent_discountInput {
            border: none;
        }
    </style>
    <main class="main-section">
        <div class="card">
            <div class="card-header">
                <asp:Label ID="lblTitle" runat="server" Text="Create Invoice"></asp:Label>

            </div>
            <div class="card-body">
                <div style="padding: 5px 10px">
                    <table cellpadding="3" class="auto-style1">
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label1" runat="server" Text="Invoice No"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="InvoiceNoTextBox" runat="server" Width="206px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DateTextBox" runat="server" Width="206px" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DateTextBox" ErrorMessage="Date is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label3" runat="server" Text="Customer Name"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="CustNameTextBox" runat="server" Width="206px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CustNameTextBox" ErrorMessage="Name is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Label ID="Label4" runat="server" Text="Contact"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ContactTextBox" runat="server" Width="206px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>

                <div>
                    <table id="itemTable">
                        <thead>
                            <tr>
                                <th>Medicine</th>
                                <th>Batch No</th>
                                <th>Expiry Date</th>
                                <th>Quantity</th>
                                <th>Price</th>
                                <th>Total</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody id="itemTbody" style="border-collapse: collapse">
                        </tbody>
                        <tfoot>
                            <tr>
                                <td style="text-align: center;">
                                    <span onclick="AddNewRow()" class="btn">+ New</span>
                                </td>
                                <td colspan="6"></td>
                            </tr>
                            <%-- <tr style="padding: 8px">
                                <td colspan="4"></td>
                                <td>Sub Total</td>
                                <td id="subtotalTd" colspan="2" style="padding: 8px;"></td>

                            </tr>--%>
                            <%-- <tr>
                                <td colspan="4"></td>
                                <td>Discount(%)</td>
                                <td colspan="2">--%>
                            <%--<input type="number" id="discountInput" oninput="grandTotalCalculation()" />--%>
                            <%--<asp:TextBox ID="discountInput" runat="server" oninput="grandTotalCalculation()"></asp:TextBox>--%>
                            <%-- </td>
                            </tr>--%>
                            <%-- <tr>
                                <td colspan="4"></td>
                                <td>Grand Total</td>
                                <td id="grandTotalTd" colspan="2" style="padding: 8px;"></td>
                            </tr>--%>
                        </tfoot>
                    </table>
                    <table>
                        <tr style="padding: 8px">
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%">Sub Total</td>
                            <td id="subtotalTd" width="20%" style="height: 15px; border: 1px solid #ccc;padding:4px 6px;"></td>
                        </tr>
                        <tr>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%">Discount(%)</td>
                            <td width="20%" style="height: 15px; border: 1px solid #ccc">
                                <asp:TextBox ID="discountInput" runat="server" oninput="grandTotalCalculation()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%">Grand Total</td>
                            <td id="grandTotalTd" width="20%" colspan="2" style="height: 15px; border: 1px solid #ccc;padding:4px 6px;"></td>

                        </tr>
                    </table>
                </div>
                <table style="margin-top: 10px; text-align: center; width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="SaveButton" runat="server" CssClass="btn" Text="Save" OnClick="SaveButton_Click"></asp:Button>
                            <asp:Button ID="ClearButton" runat="server" CssClass="btn-clear" Text="Clear" OnClick="ClearButton_Click"></asp:Button>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </main>
    <script src="../../Scripts/jquery-3.7.0.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            AddNewRow();
        })


        function AddNewRow() {
            var serial = $("#itemTbody").find('tr').length;
            var tr = document.createElement('tr');
            var medicineTd = document.createElement('td');

            var MedicineSelectItem = document.createElement('select');
            MedicineSelectItem.setAttribute("name", "MedicineId[" + serial + "]");
            var defaultOption = document.createElement('option');
            defaultOption.value = '';
            defaultOption.textContent = '--Choose--';
            MedicineSelectItem.appendChild(defaultOption);

            $.ajax({
                type: 'POST',
                url: 'Create.aspx/GetMedicines',
                contentType: 'application/json; charset=utf-8',
                data: {},
                dataType: 'json',
                success: function (response) {
                    var medicineRow = response.d;
                    medicineRow.forEach((option, index) => {
                        console.log(option.MedicineName);
                        const opt = document.createElement('option');
                        opt.value = option.Id;
                        opt.textContent = option.MedicineName;
                        MedicineSelectItem.appendChild(opt);

                        MedicineSelectItem.addEventListener("change", function () {
                            getMedicineDetails(this.value, serial);
                        });
                    });
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error: " + error);
                    console.error("Status: " + status);
                    console.error("Response: " + xhr.responseText);
                }
            });

            medicineTd.appendChild(MedicineSelectItem);
            tr.appendChild(medicineTd);



            //Batch No
            // Add input field
            var batchNoTd = document.createElement('td');
            var batchNoInput = document.createElement('INPUT');
            batchNoInput.setAttribute("type", "text");
            batchNoInput.setAttribute("readonly", "true");
            batchNoInput.setAttribute("name", "BatchNo[" + serial + "]");
            batchNoTd.append(batchNoInput);
            tr.appendChild(batchNoTd);


            //  Expiry Date input field
            var dateTd = document.createElement('td');
            var dateInput = document.createElement('INPUT');
            dateInput.setAttribute("type", "text");
            dateInput.setAttribute("readonly", "true");
            dateInput.setAttribute("name", "Expiry[" + serial + "]");
            dateTd.append(dateInput);
            tr.appendChild(dateTd);


            // Qunantity input field
            var qtyTd = document.createElement('td');
            var qtyInput = document.createElement('INPUT');
            qtyInput.setAttribute("type", "number");
            qtyInput.setAttribute("name", "Quantity[" + serial + "]");
            qtyInput.addEventListener("input", function () {
                rowWiseTotalCalculation(tr);
            });
            qtyTd.append(qtyInput);
            tr.appendChild(qtyTd);


            // Price input field
            var priceTd = document.createElement('td');
            var priceInput = document.createElement('INPUT');
            priceInput.setAttribute("type", "number");
            priceInput.setAttribute("readonly", "true");
            priceInput.setAttribute("name", "Price[" + serial + "]");
            priceTd.append(priceInput);
            tr.appendChild(priceTd);

            // Total input field
            var totalTd = document.createElement('td');
            var totalInput = document.createElement('INPUT');
            totalInput.setAttribute("type", "number");
            totalInput.setAttribute("readonly", "true");
            totalInput.setAttribute("name", "Total[" + serial + "]");
            totalTd.append(totalInput);
            tr.appendChild(totalTd);

            // Cross  field
            var actionTd = document.createElement('td');
            var actionButton = document.createElement("span");
            actionButton.textContent = " X ";
            actionButton.style.color = "red";
            actionButton.style.cursor = "pointer";
            actionButton.addEventListener("click", function () {
                removeItemRow(this);
            });


            actionTd.appendChild(actionButton);
            tr.appendChild(actionTd);

            // Append All 
            $("#itemTbody").append(tr);
        }

        function removeItemRow(obj) {
            console.log(obj);
            $(obj).closest('tr').remove();
            //totalCalculation();
        }


        function getMedicineDetails(medicineId, serial) {
            console.log(medicineId);
            console.log(serial);

            $.ajax({
                type: 'POST',
                url: 'Create.aspx/GetMedicineById',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ id: medicineId }),
                success: function (response) {
                    var medicine = response.d;
                    console.log(medicine);
                    $("input[name='BatchNo[" + serial + "]']").val(medicine.BatchNo);
                    $("input[name='Expiry[" + serial + "]']").val(medicine.ExpiryDate);
                    $("input[name='Price[" + serial + "]']").val(medicine.UnitPrice);

                    var tr = document.querySelector("input[name='Price[" + serial + "]']").closest("tr");
                    rowWiseTotalCalculation(tr);
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error: " + error);
                    console.error("Status: " + status);
                    console.error("Response: " + xhr.responseText);
                }
            });
        }

        function rowWiseTotalCalculation(tr) {

            const qtyField = tr.querySelector('input[name*="Quantity"]');
            const priceField = tr.querySelector('input[name*="Price"]');
            const totalField = tr.querySelector('input[name*="Total"]');
            const quantity = parseFloat(qtyField.value) || 0;
            const medicinePrice = parseFloat(priceField.value) || 0;

            if (quantity > 0 && medicinePrice > 0) {
                totalField.value = "";
                totalField.value = (quantity * medicinePrice).toFixed(2);
            } else {
                totalField.value = "";
            }
            subTotalCalculation();
        }

        function subTotalCalculation() {

            var netValue = 0;
            var tableBody = document.getElementById("itemTbody");
            var rows = tableBody.querySelectorAll("tr");
            rows.forEach(function (tr) {
                var totalField = tr.querySelector('input[name*="Total"]');
                var totalAmount = parseFloat(totalField.value);

                if (!isNaN(totalAmount) && totalAmount > 0) {
                    netValue += totalAmount;
                }
            });

            if (!isNaN(netValue) && netValue > 0) {
                document.getElementById("subtotalTd").textContent = netValue.toFixed(2);
                grandTotalCalculation();
            }
        }

        function grandTotalCalculation() {

            let subTotal = parseFloat(document.getElementById("subtotalTd").textContent);

            if (!isNaN(subTotal) && subTotal > 0) {
                const discountPercent = parseFloat(document.getElementById("MainContent_discountInput").value) || 0;
                const discountAmount = subTotal * discountPercent / 100;
                const grandTotal = subTotal - discountAmount;
                if (grandTotal >= 0) {
                    document.getElementById("grandTotalTd").textContent = grandTotal.toFixed(2);
                }
            }
        }
    </script>

</asp:Content>

