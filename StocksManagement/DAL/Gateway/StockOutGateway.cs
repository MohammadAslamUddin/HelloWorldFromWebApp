using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class StockOutGateway : Gateway
    {
        public int StockOut(List<StockOut> stockOutItems, string action)
        {
            int count = 0, check = 0;
            foreach (StockOut stockOut in stockOutItems)
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");

                Query =
                    "INSERT INTO StockOut Values (@CompanyId, @ItemId, @StockOutQuantity, @date, @Action);";
                string Query1 = "UPDATE Item SET availableQuantity = @AvailableQuantity WHERE id = @Id";

                Command = new SqlCommand(Query, Connection);
                SqlCommand Command1 = new SqlCommand(Query1, Connection);

                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@CompanyId", stockOut.CompanyId);
                Command.Parameters.AddWithValue("@ItemId", stockOut.ItemId);
                Command.Parameters.AddWithValue("@StockOutQuantity", stockOut.StockOutQuantity);
                Command.Parameters.AddWithValue("@Action", action);
                Command.Parameters.AddWithValue("@date", date);
                Command1.Parameters.Clear();
                Command1.Parameters.AddWithValue("@AvailableQuantity", stockOut.AvailableQuantity);
                Command1.Parameters.AddWithValue("@Id", stockOut.ItemId);
                Connection.Open();

                int rowAffected = Command.ExecuteNonQuery();
                int rowAffected1 = Command1.ExecuteNonQuery();

                Connection.Close();

                if (rowAffected > 0 && rowAffected1 > 0)
                {
                    count++;
                }

                check++;
            }

            if (count==check)
            {
                return 1;
            }
            else
            {
                return check - count;
            }
            
        }
    }
}