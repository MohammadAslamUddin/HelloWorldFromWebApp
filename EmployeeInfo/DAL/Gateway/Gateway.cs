﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HelloWorldFromWebApp.DAL.Gateway
{
    public class Gateway
    {
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public SqlConnection Connection { get; set; }
        public string Query { get; set; }

        private string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}