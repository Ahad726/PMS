<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="PMS.LoginUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            width: 111px;
        }

        table {
            margin: auto;
            /*width: 10%;*/
            /*border: 1px black solid;*/
            padding: 5px;
        }

        .page-center {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background: #f0f0f0;
        }

        input[type="text"],input[type="password"] {
            padding: 4px 6px;
            border: 1px solid #ccc;
            border-radius: 3px;
            font-size: 13px;
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-center">
            <div class="card">
                <div class="card-header" style="justify-content: center">
                    PMS || LOGIN
                </div>
                <table cellpadding="5" cellspacing="5">
                    <tr>
                        <td>USERNAME</td>
                        <td>
                            <asp:TextBox ID="UserNameTextBox" ToolTip="admin" runat="server" Width="195px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserNameTextBox" Display="Dynamic" ErrorMessage="Please Enter Username" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>PASSWORD</td>
                        <td>
                            <asp:TextBox ID="PasswordTextBox" ToolTip="123456789" runat="server" Width="195px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox" Display="Dynamic" ErrorMessage="Please Enter Password" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td>
                            <asp:Button ID="LoginButton" runat="server" Text="LOGIN" Width="81px" OnClick="LoginButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
