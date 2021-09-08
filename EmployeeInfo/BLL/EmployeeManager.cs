using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.DAL.Gateway;
using HelloWorldFromWebApp.DAL.Model;

namespace HelloWorldFromWebApp.BLL
{
    public class EmployeeManager
    {
        EmployeeGateWay employeeGateWay = new EmployeeGateWay();


        public string Save(Employee employee)
        {
            if (!employeeGateWay.IsEmailExist(employee))
            {
                int rowAffected = employeeGateWay.Save(employee);

                if (rowAffected > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Failed";
                }
            }
            else
            {
                return "Please Enter an unique email address";
            }
        }
        private bool IsEmailExist(Employee employee)
        {
            return employeeGateWay.IsEmailExist(employee);
        }

        public List<Employee> GetAllEmployee()
        {
            return employeeGateWay.GetAllEmployee();
        }
        public List<EmployeeVM> GetEmployeeWithDepartmentName()
        {
            return employeeGateWay.GetEmployeeWithDepartmentName();
        }

       
        public string Update(Employee employee)
        {
            if (!IsEmailExist(employee))
            {
                int rowAffected = employeeGateWay.Update(employee);
                if (rowAffected > 0)
                {
                    return "Updated";
                }
                else
                {
                    return "Failed";
                }
            }
            else
            {
                return "Please Enter an unique email address";
            }
        }


        public Employee Find(string email)
        {
            return employeeGateWay.Find(email);
        }

        public string Delete(int employeeId)
        {
            int rowAffected = employeeGateWay.Delete(employeeId);
            if (rowAffected>0)
            {
                return "Deleted";
            }
            else
            {
                return "Failed";
            }
        }

        
    }
}