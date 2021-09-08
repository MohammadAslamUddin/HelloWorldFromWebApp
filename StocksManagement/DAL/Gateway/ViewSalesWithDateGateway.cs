using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class ViewSalesWithDateGateway : Gateway
    {
        public List<ViewSalesWithDate> GetSelles(string fromDate, string toDate)
        {
            Query = "SELECT Item.name ItemName, StockOut.stockOutQuantity SaleQuantity " +
                    "FROM StockOut INNER JOIN Item " +
                    "ON StockOut.itemId = Item.id AND " +
                    "StockOut.Date BETWEEN '" + fromDate + "' AND '" + toDate + "' " +
                    "WHERE StockOut.Action='Sell';";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ViewSalesWithDate> viewSalesWithDates = new List<ViewSalesWithDate>();

            while (Reader.Read())
            {
                ViewSalesWithDate viewSalesWithDate = new ViewSalesWithDate();
                viewSalesWithDate.ItemName = Reader["ItemName"].ToString();
                viewSalesWithDate.Quantity = Convert.ToInt32(Reader["SaleQuantity"]);

                viewSalesWithDates.Add(viewSalesWithDate);
            }

            Reader.Close();
            Connection.Close();

            return viewSalesWithDates;
        }
    }
}