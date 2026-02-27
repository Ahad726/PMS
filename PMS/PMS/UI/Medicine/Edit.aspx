<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="PMS.UI.Medicine.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-left-style: solid;
            border-left-width: 1px;
            border-right: 1px solid #C0C0C0;
            border-top-style: solid;
            border-top-width: 1px;
            border-bottom: 1px solid #C0C0C0;
        }
        #Text1 {
            width: 306px;
        }
        .auto-style4 {
            height: 23px;
            width: 30px;
        }
        #MedicineNameText {
            width: 238px;
        }
        #MedicineNameTextBox {
            width: 305px;
        }
        #MedicineNameTextBox0 {
            width: 305px;
        }
        #GroupNameTextBox {
            width: 304px;
        }
        #MedicineNameTextBox0 {
            width: 305px;
        }
        #BatchNoTextBox {
            width: 303px;
        }
        #ExpiryDateText {
        }
        .auto-style5 {
            width: 30px;
        }
        .auto-style9 {
            width: 30px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                    <asp:Button ID="MedUpdateButton" runat="server" OnClick="MedUpdateButton_Click" Text="Save" Width="102px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
