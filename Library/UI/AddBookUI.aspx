<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBookUI.aspx.cs" Inherits="HelloWorldFromWebApp.Library.UI.AddBookUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Add Book</legend>
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="Label1" Text="Name"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="nameTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2" Text="ISBN"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="isbnTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label3" Text="Author"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="authorTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: right"><asp:Button runat="server" ID="saveButton" Text="Save" OnClick="saveButton_Click"/></td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
            </fieldset>
        </div>
    </form>
</body>
</html>
