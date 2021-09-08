using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class ViewAndSearchGateway : Gateway
    {
        public List<StockOut> GetItemByCompanyAndCategory(int companyId, int categoryId)
        {
            Query = "SELECT i.name ItemName, c.name ComName, cat.name CatName, i.availableQuantity Quantity, i.reorderLevel ReorderLevel" +
                    " FROM ITEM i INNER JOIN Company c " +
                    "on i.companyId = c.id inner join Category cat " +
                    "on i.categoryId = cat.id " +
                    "where cat.id = " + categoryId + " AND C.id = " + companyId + "; ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<StockOut> stockOuts = new List<StockOut>();
            while (Reader.Read())
            {
                StockOut stockOut = new StockOut();
                stockOut.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                stockOut.AvailableQuantity = Convert.ToInt32(Reader["Quantity"]);
                stockOut.CategoryName = Reader["CatName"].ToString();
                stockOut.CompanyName = Reader["ComName"].ToString();
                stockOut.ItemName = Reader["ItemName"].ToString();

                stockOuts.Add(stockOut);
            }
            Reader.Close();
            Connection.Close();

            return stockOuts;
        }

        public List<StockOut> GetItemByCompany(int companyId)
        {
            Query = "SELECT i.name ItemName, c.name ComName, cat.name CatName, i.availableQuantity Quantity, i.reorderLevel ReorderLevel" +
                    " FROM ITEM As i INNER JOIN Company As c " +
                    "on i.companyId = c.id inner join Category cat " +
                    "on i.categoryId = cat.id " +
                    "where C.id = " + companyId + "; ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<StockOut> stockOuts = new List<StockOut>();
            while (Reader.Read())
            {
                StockOut stockOut = new StockOut();
                stockOut.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                stockOut.AvailableQuantity = Convert.ToInt32(Reader["Quantity"]);
                stockOut.CategoryName = Reader["CatName"].ToString();
                stockOut.CompanyName = Reader["ComName"].ToString();
                stockOut.ItemName = Reader["ItemName"].ToString();

                stockOuts.Add(stockOut);
            }
            Reader.Close();
            Connection.Close();

            return stockOuts;
        }

        public List<StockOut> GetItemByCategory(int categoryId)
        {
            Query = "SELECT i.name ItemName, c.name ComName, cat.name CatName, i.availableQuantity Quantity, i.reorderLevel ReorderLevel" +
                    " FROM ITEM i INNER JOIN Company c " +
                    "on i.companyId = c.id inner join Category cat " +
                    "on i.categoryId = cat.id " +
                    "where cat.id = " + categoryId + "; ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<StockOut> stockOuts = new List<StockOut>();
            while (Reader.Read())
            {
                StockOut stockOut = new StockOut();
                stockOut.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                stockOut.AvailableQuantity = Convert.ToInt32(Reader["Quantity"]);
                stockOut.CategoryName = Reader["CatName"].ToString();
                stockOut.CompanyName = Reader["ComName"].ToString();
                stockOut.ItemName = Reader["ItemName"].ToString();

                stockOuts.Add(stockOut);
            }
            Reader.Close();
            Connection.Close();

            return stockOuts;
        }
    }
}