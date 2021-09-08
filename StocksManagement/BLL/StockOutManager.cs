using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class StockOutManager
    {
        
        StockOutGateway stockOutGateway = new StockOutGateway();

        public string StockOut(List<StockOut> stockOutItems, string action)
        {
            int rowAffected = stockOutGateway.StockOut(stockOutItems, action);
            if (rowAffected>0)
            {
                return "Items " + action +"!";
            }
            else
            {
                return "Items " + action + " Fail!";
            }
        }
    }
}