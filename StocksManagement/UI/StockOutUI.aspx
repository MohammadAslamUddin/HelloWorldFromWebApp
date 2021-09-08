<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Stock Out</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Label1" Text="Company"></asp:Label></td>
                        <td>
                            <asp:DropDownList runat="server" ID="companyDropdownList" AutoPostBack="True" OnSelectedIndexChanged="companyDropdownList_SelectedIndexChanged" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Label2" Text="Item"></asp:Label></td>
                        <td>
                            <asp:DropDownList runat="server" ID="itemDropdownList" AutoPostBack="True" OnSelectedIndexChanged="itemDropdownList_SelectedIndexChanged" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Label3" Text="Reorder Level"></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="reorderLevelTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Label4" Text="Available Quantity"></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="availableQuentityTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Label5" Text="Stock Out Quantity"></asp:Label></td>
                        <td>
                            <asp:TextBox runat="server" ID="stockOutQuentityTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="addButton" Text="Add" OnClick="addButton_Click" /></td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
                <asp:GridView runat="server" ID="stockOutGridView" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <label><%#Container.DataItemIndex+1 %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                <label><%#Eval("ItemName") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                <label><%#Eval("CompanyName") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <label><%#Eval("StockOutQuantity") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button runat="server" ID="sellButton" Text="Sell" OnClick="sellButton_Click" />
                <asp:Button runat="server" ID="damageButton" Text="Damage" OnClick="damageButton_Click" />
                <asp:Button runat="server" ID="lostButton" Text="Lost" OnClick="lostButton_Click" />
            </fieldset>
        </div>
    </form>
</body>
</html>
