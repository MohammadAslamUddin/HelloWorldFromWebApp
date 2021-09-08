using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelloWorldFromWebApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }

    }
}