<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndViewUI.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.Search_ViewUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Search & View Items Summary</legend>
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="Label1" Text="Company"></asp:Label></td>
                        <td><asp:DropDownList runat="server" ID="companyDropdownList"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2" Text="Category"></asp:Label></td>
                        <td><asp:DropDownList runat="server" ID="categoryDropdownList"/></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button runat="server" ID="searchButton" Text="Search" OnClick="searchButton_Click"/></td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
                <asp:GridView runat="server" ID="viewSearchGridView" AutoGenerateColumns="False">
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
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <label><%#Eval("CategoryName") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Available Quantity">
                            <ItemTemplate>
                                <label><%#Eval("AvailableQuantity") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reorder Level">
                            <ItemTemplate>
                                <label><%#Eval("ReorderLevel") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>
        </div>
    </form>
</body>
</html>
