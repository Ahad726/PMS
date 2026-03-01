<%@ Page Title="All Medicines" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="PMS.UI.Medicine.List" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MainContent_medicineGridView {
            width: 100%;
            border-collapse: collapse;
        }

            #MainContent_medicineGridView th, #MainContent_medicineGridView td {
                border: 1px solid #ccc;
                padding: 8px;
                text-align: left;
            }

            #MainContent_medicineGridView th {
                background-color: #f5f5f5;
            }
    </style>
    <main class="main-section">
        <div class="card">
            <div class="card-header">
                <asp:Label ID="lblTitle" runat="server" Text="Medicine List"></asp:Label>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="New" CssClass="btn" OnClick="btnAdd_Click" />
                    <span>&nbsp</span>
                    <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="btn-clear" OnClick="btnExport_Click" />
                </div>
            </div>
            <div class="card-body">
                <div>
                    <asp:GridView ID="medicineGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <%--<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />--%>
                            <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name" SortExpression="MedicineName" />
                            <asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="GroupName" />
                            <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" SortExpression="BatchNo" />
                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="ExpiryDate"></asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div style="display: flex; gap: 10px; padding-left: 5px">
                                        <asp:Button runat="server" CssClass="btn-edit" Text="Edit" CommandArgument='<%#Eval("Id") %>' OnClick="EditButton_Click"></asp:Button>
                                        <asp:Button runat="server" CssClass="btn-delete" Text="Delete" CommandArgument='<%#Eval("Id") %>' OnClick="DeleteButton_Click"></asp:Button>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMedicines" TypeName="PMS.BLL.MedicineManager"></asp:ObjectDataSource>

                    <br />

                </div>
            </div>
        </div>
    </main>
</asp:Content>
