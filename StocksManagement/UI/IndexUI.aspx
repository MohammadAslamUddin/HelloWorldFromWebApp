<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="HelloWorldFromWebApp.StocksManagement.UI.IndexUI" %>

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
                    <th>Story Name</th>
                </tr>
                <tr>
                    <td><a href="CategoryUI.aspx">Setup Category</a></td>
                </tr>
                <tr>
                    <td><a href="CompanyUI.aspx">Setup Company</a></td>
                </tr>
                <tr>
                    <td><a href="ItemUI.aspx">Setup Item</a></td>
                </tr>
                <tr>
                    <td><a href="StockInUI.aspx">Stock In</a></td>
                </tr>
                <tr>
                    <td><a href="StockOutUI.aspx">Stock Out</a></td>
                </tr>
                <tr>
                    <td><a href="SearchAndViewUI.aspx">Search & View</a></td>
                </tr>
                <tr>
                    <td><a href="ViewSalesBetweenTwoDates.aspx">View Sales Between Two Dates</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
