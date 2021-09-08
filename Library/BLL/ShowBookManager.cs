using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.Library.DAL.Gateway;
using HelloWorldFromWebApp.Library.DAL.Model;

namespace HelloWorldFromWebApp.Library.BLL
{
    public class ShowBookManager
    {
        ShowBookGateway showBookGateway = new ShowBookGateway();

        public List<Book> GetAllBooks(string name)
        {
            return showBookGateway.GetAllBooks(name);
        }
    }
}