<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveEmployee.aspx.cs" Inherits="HelloWorldFromWebApp.SaveEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Save Employee</legend>
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="label1" Text="Name"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="nameTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="label2" Text="Email"></asp:Label></td>
                        <td><asp:TextBox runat="server" ID="emailTextBox"></asp:TextBox></td>
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
                        <td><asp:Label runat="server" ID="label6" Text="Department"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="departmentDropDownList" runat="server" Height="24px" Width="123px">
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button runat="server" ID="saveButton" Text="Save" Width="125px" OnClick="saveButton_Click" style="height: 26px"/></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Label runat="server" ID="messageLabel"></asp:Label></td>
                    </tr>
                </table>
            </fieldset>
        </div>
        
        <asp:GridView runat="server" ID="allDataGridView" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ><%#Eval("EmpName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email Id No">
                    <ItemTemplate>
                        <asp:Label runat="server" ><%#Eval("Email") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact No">
                    <ItemTemplate>
                        <asp:Label runat="server" ><%#Eval("Contact") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Blood Group">
                    <ItemTemplate>
                        <asp:Label runat="server" ><%#Eval("BloodGroup") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label runat="server" ><%#Eval("Address") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label runat="server" ><%#Eval("DeptName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
