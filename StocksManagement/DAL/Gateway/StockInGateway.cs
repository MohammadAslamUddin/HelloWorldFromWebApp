using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class StockInGateway : Gateway
    {
        public int Save(StockIn stockIn)
        {
            int newAvailableQuantity = stockIn.AvailableQuentity + stockIn.StockInQuentity;
            Query = "UPDATE Item SET availableQuantity = @newAvailableQuantity WHERE id=@Id AND companyId=@CompanyId;";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@Id", stockIn.ItemId);
            Command.Parameters.AddWithValue("@newAvailableQuantity", newAvailableQuantity);
            Command.Parameters.AddWithValue("@CompanyId", stockIn.CompanyId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}