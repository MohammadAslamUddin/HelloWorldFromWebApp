using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.DAL.Gateway
{
    public class CompanyGateway : Gateway
    {
        public List<Company> GetAllCompnay()
        {
            Query = "SELECT * FROM Company;";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Company> companies = new List<Company>();
            while (Reader.Read())
            {
                Company company = new Company();
                company.Id = (int)Reader["id"];
                company.Name = Reader["name"].ToString();

                companies.Add(company);
            }

            Reader.Close();
            Connection.Close();

            return companies;
        }

        public bool IsExistCompany(string name)
        {
            Query = "SELECT * FROM Company WHERE name = '" + name + "';";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();

            return hasRows;
        }

        public int Save(Company company)
        {
            Query = "INSERT INTO Company VALUES('" + company.Name + "')";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}