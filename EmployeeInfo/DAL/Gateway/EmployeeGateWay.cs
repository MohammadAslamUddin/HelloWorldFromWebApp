using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using HelloWorldFromWebApp.DAL.Model;

namespace HelloWorldFromWebApp.DAL.Gateway
{
    public class EmployeeGateWay : Gateway
    {
        public bool IsEmailExist(Employee employee)
        {
            int? employeeId = employee.Id > 0 ? employee.Id : 0;
            
            Query = "SELECT * FROM EmployeesInfo WHERE Email='" + employee.Email + "' AND Id != " + employeeId + ";";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Save(Employee employee)
        {
            Query = "INSERT INTO EmployeesInfo VALUES('" + employee.Name + "','" + employee.Email + "','" +
                    employee.Contact + "','" + employee.BloodGroup + "','" + employee.Address + "','" + employee.DepartmentId + "');";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
        }

        public List<Employee> GetAllEmployee()
        {
            Query = "SELECT * FROM EmployeesInfo;";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (Reader.Read())
            {
                Employee employee = new Employee();
                employee.Name = Reader["Name"].ToString();
                employee.Email = Reader["Email"].ToString();
                employee.BloodGroup = Reader["BloodGroup"].ToString();
                employee.Contact = Reader["Contact"].ToString();
                employee.Address = Reader["Address"].ToString();
                employee.DepartmentId = (int)Reader["DepartmentId"];

                employees.Add(employee);
            }
            Reader.Close();
            Connection.Close();
            return employees;
        }
        public List<EmployeeVM> GetEmployeeWithDepartmentName()
        {
            Query = "SELECT * FROM EmployeeWithDepartmentName;";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EmployeeVM> employees = new List<EmployeeVM>();
            while (Reader.Read())
            {
                EmployeeVM employee = new EmployeeVM();
                employee.EmpId = (int) Reader["EmpId"];
                employee.EmpName = Reader["EmpName"].ToString();
                employee.Email = Reader["Email"].ToString();
                employee.BloodGroup = Reader["BloodGroup"].ToString();
                employee.Contact = Reader["Contact"].ToString();
                employee.Address = Reader["Address"].ToString();
                employee.DeptId = (int) Reader["DeptId"];
                employee.DeptName = Reader["DeptName"].ToString();


                employees.Add(employee);
            }
            Reader.Close();
            Connection.Close();
            return employees;
        }

        public int Update(Employee employee)
        {
            Query = "Update EmployeesInfo SET Name='" + employee.Name + "', Email = '" + employee.Email + "', Address = '" + employee.Address + "', BloodGroup = '" + employee.BloodGroup + "', Contact = '" + employee.Contact + "' where id = " + employee.Id + ";";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
        }

        public Employee Find(string email)
        {
            Query = "SELECT * FROM EmployeesInfo WHERE Email='" + email + "';";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Employee employee = null;
            if (Reader.HasRows)
            {
                employee = new Employee();
                Reader.Read();
                employee.Name = Reader["Name"].ToString();
                employee.BloodGroup = Reader["BloodGroup"].ToString();
                employee.Contact = Reader["Contact"].ToString();
                employee.Address = Reader["Address"].ToString();
                employee.Email = Reader["Email"].ToString();
                employee.Id = Convert.ToInt32(Reader["id"].ToString());
            }

            Reader.Close();
            Connection.Close();

            return employee;
        }

        public int Delete(int employeeId)
        {
            Query = "DELETE FROM EmployeesInfo WHERE Id = "+employeeId+";";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        
    } 
}