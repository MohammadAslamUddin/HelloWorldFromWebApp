using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Model
{
    public class Item
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuentity { get; set; }
    }
}