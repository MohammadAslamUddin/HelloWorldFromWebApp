using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldFromWebApp.Library.DAL.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
    }
}