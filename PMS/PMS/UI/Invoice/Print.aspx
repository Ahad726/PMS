<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Print.aspx.cs" Inherits="PMS.UI.Invoice.Print" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MainContent_InvoiceDetailsGrid td {
            text-align: center;
        }
    </style>
    <main class="main-section">
        <div class="card" style="width:80%;margin:0px auto;">
            <div class="card-header">
                <asp:Label ID="lblTitle" runat="server" Text="Print Invoice"></asp:Label>

            </div>
            <div class="card-body" >
                <div style="padding: 5px 10px">
                    <table cellpadding="3" class="auto-style1">
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label1" runat="server" Text="Invoice No:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="InvoiceNoLbl" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="DateLbl" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label3" runat="server" Text="Customer Name"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="CustNameLbl" runat="server" Text="Customer Name"></asp:Label>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Label ID="Label4" runat="server" Text="Contact"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="ContactLbl" runat="server" Text="Contact"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

                <div>
                    <asp:GridView ID="InvoiceDetailsGrid" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="MedName"  HeaderText="Medicine" />
                            <asp:BoundField DataField="BatchNo" HeaderText="Batch No" />
                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
                        </Columns>
                    </asp:GridView>
                    <table>
                        <tr style="padding: 8px">
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%">Sub Total</td>
                            <td width="20%" style="height: 15px; border: 1px solid #ccc; padding: 4px 6px;">
                                <asp:Label ID="subtotalLbl" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%">Discount(%)</td>
                            <td width="20%" style="height: 15px; border: 1px solid #ccc">
                                <asp:Label ID="DiscountLbl" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%"></td>
                            <td width="16%">Grand Total</td>
                            <td width="20%" style="height: 15px; border: 1px solid #ccc">
                                <asp:Label ID="GndTotalLbl" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <table style="margin-top: 10px; text-align: center; width: 100%;">
                    <tr>
                        <td>
                            <button type="button" class="btn" onclick="window.print()">Print</button>
                            <asp:Button ID="ClearButton" runat="server" CssClass="btn-clear" Text="Cancel" OnClick="ClearButton_Click"></asp:Button>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </main>

</asp:Content>
