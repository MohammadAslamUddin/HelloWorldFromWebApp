<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesBetweenTwoDates.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.ViewSalesBetweenTwoDates" %>

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
                        <td><asp:Label runat="server" ID="Label1" Text="From Date"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="fromdateTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2" Text="To Date"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="toDateTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label runat="server" Text="Date Formal Must be yyyy-mm-dd"></asp:Label></td>
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
                        <asp:TemplateField HeaderText="Sale Quantity">
                            <ItemTemplate>
                                <label><%#Eval("Quantity") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>
        </div>
    </form>
</body>
</html>
