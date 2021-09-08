using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class ItemGateway : Gateway
    {
        public bool IsItemNameExist(string name)
        {
            Query = "SELECT * FROM Item WHERE name = '" + name + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }
            Reader.Close();
            Connection.Close();

            return hasRows;
        }

        public int Save(Item item)
        {
            Query = "INSERT INTO Item VALUES('" + item.Name + "'," + item.CompanyId + "," + item.CategoryId + "," + item.ReorderLevel + "," + item.AvailableQuentity + ")";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<Item> GetAllItems()
        {
            Query = "SELECT * FROM Item";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Item> items = new List<Item>();
            while (Reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(Reader["id"]);
                item.Name = Reader["name"].ToString();
                item.CategoryId = Convert.ToInt32(Reader["categoryId"]);
                item.CompanyId = Convert.ToInt32(Reader["companyId"]);
                item.ReorderLevel = Convert.ToInt32(Reader["reorderLevel"]);

                items.Add(item);
            }
            Reader.Close();
            Connection.Close();

            return items;
        }

        public Item GetReorderLevel(int itemId)
        {
            Item item = new Item();
            Query = "SELECT * FROM Item WHERE id = " + itemId + ";";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                item.Id = Convert.ToInt32(Reader["id"]);
                item.Name = Reader["name"].ToString();
                item.ReorderLevel = Convert.ToInt32(Reader["reorderLevel"]);
                item.AvailableQuentity = Convert.ToInt32(Reader["availableQuantity"]);
            }
            Reader.Close();
            Connection.Close();

            return item;
        }
    }
}