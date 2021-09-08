<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.StockInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Stock In</legend>
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="Label1" Text="Comapny"></asp:Label></td>
                        <td><asp:DropDownList runat="server" ID="companyDropdownlist" AutoPostBack="True" OnSelectedIndexChanged="companyDropdownlist_SelectedIndexChanged"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2" Text="Item"></asp:Label></td>
                        <td><asp:DropDownList runat="server" ID="itemDropdownlist" AutoPostBack="True" OnSelectedIndexChanged="itemDropdownlist_SelectedIndexChanged"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label3" Text="Reorder Level"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="reorderLevelTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label4" Text="Available Quentity"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="availabeQuentityTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label5" Text="Stock In Quentity"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="stockInQuentityTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button runat="server" ID="saveButton" Text="Save" OnClick="saveButton_Click" style="height: 26px"/></td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
            </fieldset>
        </div>
    </form>
</body>
</html>
