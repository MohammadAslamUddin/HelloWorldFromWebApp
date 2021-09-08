<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyUI.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.CompanyUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Company Setup</legend>
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="Label1" Text="Name"></asp:Label></td> 
                        <td><asp:TextBox runat="server" ID="nameTextBox" Text="" ></asp:TextBox></td> 
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: right"><asp:Button runat="server" ID="saveButton" Text="Save" OnClick="saveButton_Click" /></td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
                <asp:GridView runat="server" ID="compnayGridView" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <label><%#Container.DataItemIndex+1 %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <label><%#Eval("Name") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>
        </div>
    </form>
</body>
</html>
