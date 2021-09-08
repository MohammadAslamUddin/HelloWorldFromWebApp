using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Model
{
    public class StockIn
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int reorderLevel { get; set; }
        public int AvailableQuentity { get; set; }
        public int StockInQuentity { get; set; }
    }
}