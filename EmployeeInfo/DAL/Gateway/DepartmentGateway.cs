using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using HelloWorldFromWebApp.DAL.Model;

namespace HelloWorldFromWebApp.DAL.Gateway
{
    public class DepartmentGateway :Gateway
    {
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = (int)Reader["id"];
                department.Code = Reader["code"].ToString();
                department.Name = Reader["Name"].ToString();

                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();

            return departments;
        }
    }
}