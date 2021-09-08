using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.Library.DAL.Model;

namespace HelloWorldFromWebApp.Library.DAL.Gateway
{
    public class AddBookGateway : Gateway
    {
        public bool isIsbnExist(string isbn)
        {
            Query = "SELECT * FROM Book WHERE isbn = '" + isbn + "';";

            Command = new SqlCommand(Query, Connection);
            
            Connection.Open();

            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                return true;
            }
            
            Reader.Close();

            Connection.Close();
            
            return false;

        }

        public int Save(Book book)
        {
            Query = "INSERT INTO Book VALUES('"+ book.Name +"','" + book.Isbn + "','" + book.Author + "');";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}