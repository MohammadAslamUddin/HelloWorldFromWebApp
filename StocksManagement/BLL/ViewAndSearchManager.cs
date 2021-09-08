using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class ViewAndSearchManager
    { 
        ViewAndSearchGateway viewAndSearchGateway = new ViewAndSearchGateway();

        public List<StockOut> GetItemByCompanyAndCategory(int companyId, int categoryId)
        {
            return viewAndSearchGateway.GetItemByCompanyAndCategory(companyId, categoryId);
            
        }

        public List<StockOut> GetItemByCompany(int companyId)
        {
            return viewAndSearchGateway.GetItemByCompany(companyId);
        }

        public List<StockOut> GetItemByCategory(int categoryId)
        {
            return viewAndSearchGateway.GetItemByCategory(categoryId);
        }

    }
}