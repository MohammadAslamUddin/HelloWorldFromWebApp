using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Model
{
    [Serializable]
    public class StockOut
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
        public int StockOutQuantity { get; set; }
        public int Sell { get; set; }
        public int Damage { get; set; }
        public int Lost { get; set; }
    }
}