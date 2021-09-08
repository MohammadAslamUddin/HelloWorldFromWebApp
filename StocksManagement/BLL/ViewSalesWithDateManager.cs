using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class ViewSalesWithDateManager
    {
        ViewSalesWithDateGateway viewSalesWithDateGateway = new ViewSalesWithDateGateway();
        public List<ViewSalesWithDate> GetSelles(string fromDate, string toDate)
        {
            return viewSalesWithDateGateway.GetSelles(fromDate, toDate);
        }
    }
}