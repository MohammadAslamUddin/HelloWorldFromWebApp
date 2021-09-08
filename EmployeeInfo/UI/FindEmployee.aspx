<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindEmployee.aspx.cs" Inherits="HelloWorldFromWebApp.FindEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Find and Update or Delete Employee</legend>
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="label2" Text="Email"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="emailTextBox"></asp:TextBox></td>
                        <td><asp:Button runat="server" ID="findButton" Text="Find" OnClick="findButton_Click"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="label1" Text="Name"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="nameTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="label3" Text="Contact No"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="contactTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="label4" Text="Blood Group"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="bloodGroupDropDownList" runat="server" Height="24px" Width="123px">
                                <asp:ListItem>A+</asp:ListItem>
                                <asp:ListItem>A-</asp:ListItem>
                                <asp:ListItem>B+</asp:ListItem>
                                <asp:ListItem>B-</asp:ListItem>
                                <asp:ListItem>O+</asp:ListItem>
                                <asp:ListItem>O-</asp:ListItem>
                                <asp:ListItem>AB+</asp:ListItem>
                                <asp:ListItem>AB-</asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="label5" Text="Address"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="addressTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:HiddenField runat="server" ID="hiddenId"/></td>
                        <td><asp:Button runat="server" ID="updateButton" Text="Update" OnClick="updateButton_Click"/><asp:Button runat="server" ID="deleteButton" Text="Delete" OnClick="deleteButton_Click"/></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Label runat="server" ID="messageLabel"></asp:Label></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
