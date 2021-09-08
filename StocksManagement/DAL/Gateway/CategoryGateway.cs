using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class CategoryGateway : Gateway
    {
        public List<Category> GetAllCategory()
        {
            Query = "SELECT * FROM Category";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            
            List<Category> categories = new List<Category>();
            while (Reader.Read())
            {
                Category category = new Category();
                category.Id = (int) Reader["id"];
                category.Name = Reader["name"].ToString();

                categories.Add(category);
            }

            Reader.Close();
            Connection.Close();

            return categories;
        }

        public bool IsExistCategory(string name)
        {
            Query = "SELECT * FROM Category WHERE name = '" + name + "';";
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

        public int Save(Category category)
        {
            Query = "INSERT INTO Category VALUES('" + category.Name + "')";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}