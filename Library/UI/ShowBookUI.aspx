<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBookUI.aspx.cs" Inherits="HelloWorldFromWebApp.Library.UI.ShowBookUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="searchTextBox"></asp:TextBox>
            <asp:Button runat="server" ID="searchButton" Text="Search" OnClick="searchButton_Click"/>
        </div>
        <asp:GridView runat="server" ID="bookGridView" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <label><%#Eval("Name") %></label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ISBN">
                    <ItemTemplate>
                        <label><%#Eval("Isbn") %></label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author">
                    <ItemTemplate>
                        <label><%#Eval("Author") %></label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
