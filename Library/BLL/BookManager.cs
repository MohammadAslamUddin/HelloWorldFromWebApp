using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.Library.DAL.Gateway;
using HelloWorldFromWebApp.Library.DAL.Model;

namespace HelloWorldFromWebApp.Library.BLL
{
    public class BookManager
    {
        AddBookGateway bookGateway = new AddBookGateway();

        public string Save(Book book)
        {
            if (bookGateway.isIsbnExist(book.Isbn))
            {
                return "Please Enter an unique ISBN number";
            }
            else
            { 
                if (book.Isbn.Length != 13)
                {
                    return "ISBN must be 13 character!";
                }
                else
                {
                    int rowAffected = bookGateway.Save(book);
                    if (rowAffected > 0)
                    {
                        return "Saved!";
                    }
                    else
                    {
                        return "Failed!";
                    }
                }
            }
        }
    }
}