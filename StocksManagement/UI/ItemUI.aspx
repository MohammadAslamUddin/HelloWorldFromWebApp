<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemUI.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.ItemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td><asp:Label runat="server" ID="Label1" Text="Category"></asp:Label></td>
                    <td><asp:DropDownList runat="server" ID="categoryDropdownList"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="Label2" Text="Company"></asp:Label></td>
                    <td><asp:DropDownList runat="server" ID="companyDropdownList"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="Label3" Text="Item Name"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="itemNameTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="Label4" Text="Reorder Level"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="reorderLevelTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="saveButton" Text="Save" OnClick="saveButton_Click"/></td>
                </tr>
            </table>
            <asp:Label runat="server" ID="messageLabel"></asp:Label>
        </div>
    </form>
</body>
</html>
