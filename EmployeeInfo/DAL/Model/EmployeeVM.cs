using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldFromWebApp.DAL.Model
{
    public class EmployeeVM
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}