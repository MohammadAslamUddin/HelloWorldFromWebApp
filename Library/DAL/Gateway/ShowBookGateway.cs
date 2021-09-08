using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.Library.DAL.Model;

namespace HelloWorldFromWebApp.Library.DAL.Gateway
{
    public class ShowBookGateway : Gateway
    {
        public List<Book> GetAllBooks(string name)
        {
            if (name.Equals(""))
            {
                Query = "SELECT * FROM Book;";
            }
            else
            {
                Query = "SELECT * FROM Book where name Like '%" + name + "%';";
            }

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Book> books = new List<Book>();
            while (Reader.Read())
            {
                Book book = new Book();
                book.Name = Reader["name"].ToString();
                book.Isbn = Reader["isbn"].ToString();
                book.Author = Reader["author"].ToString();

                books.Add(book);
            }
            Reader.Close();
            Connection.Close();

            return books;
        }
    }
}