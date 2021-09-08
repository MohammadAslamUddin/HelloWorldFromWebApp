using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();

        public List<Company> GetAllCompany()
        {
            return companyGateway.GetAllCompnay();
        }

        public string Save(Company company)
        {
            if (companyGateway.IsExistCompany(company.Name))
            {
                return "Company Name Must be Unique!";
            }
            else
            {
                int rowAffected = companyGateway.Save(company);
                if (rowAffected > 0)
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