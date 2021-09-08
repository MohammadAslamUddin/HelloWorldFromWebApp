using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway = new StockInGateway();

        public string Save(StockIn stockIn)
        {
            if (stockIn.reorderLevel>stockIn.StockInQuentity)
            {
                return "StockIn Quantity Must be equal or bigger than Reorder Level";
            }
            else
            {
                int rowAffected = stockInGateway.Save(stockIn);
                if (rowAffected>0)
                {
                    return "Saved!";
                }
                else
                {
                    return "Saving Failed!";
                }
            }
        }
    }
}