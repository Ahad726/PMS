<%@ Page Title="New Medicine" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="PMS.UI.Medicine.Add" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
     
    </style>

    <main class="main-section">
        <div class="card">
            <div class="card-header">
                <asp:Label ID="lblTitle" runat="server" Text="New Medicine"></asp:Label>
            </div>
            <div class="card-body">
                <div>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style4"></td>
                            <td class="auto-style4"></td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="Label1" runat="server" Text="Medine Name"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="MedNameTxt" runat="server" Height="21px" Width="290px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="MedNameTxt" Display="Dynamic" ErrorMessage="Medicine Name required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:Label ID="Label2" runat="server" Text="Group Name"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:TextBox ID="GrpNameTxt" runat="server" Height="21px" Width="290px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="GrpNameTxt" Display="Dynamic" ErrorMessage="Group Name required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:Label ID="Label3" runat="server" Text="Batch No"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:TextBox ID="BatchNoTxt" runat="server" Height="21px" Width="290px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="BatchNoTxt" Display="Dynamic" ErrorMessage="Batch No required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Expiry Date</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="ExpiryDateTxt" runat="server" TextMode="Date" Width="287px" Height="21px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ExpiryDateTxt" Display="Dynamic" ErrorMessage="Expiry Date required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">Quantity</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="QuantityTxt" runat="server" Width="289px" Height="21px" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="QuantityTxt" Display="Dynamic" ErrorMessage="Quantity required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">Unit Price</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="UnitPriceTxt" runat="server" Width="288px" Height="21px" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="UnitPriceTxt" Display="Dynamic" ErrorMessage="Unit Price required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="MedSaveButton_Click" Text="Save" Width="102px" />
                                <asp:Button ID="MedCancelButton" runat="server" CssClass="btn-clear" Text="Cancel" CausesValidation="false" Width="102px" OnClick="MedCancelButton_Click" />
                            </td>
                        </tr>
                    </table>

                </div>
            </div>
        </div>
    </main>
</asp:Content>
