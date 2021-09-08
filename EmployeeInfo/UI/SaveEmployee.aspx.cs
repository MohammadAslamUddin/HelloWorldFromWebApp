using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorldFromWebApp.BLL;
using HelloWorldFromWebApp.DAL.Gateway;
using HelloWorldFromWebApp.DAL.Model;

namespace HelloWorldFromWebApp
{
    public partial class SaveEmployee : System.Web.UI.Page
    {
        EmployeeManager employeeManager = new EmployeeManager();
        DepartmentManager departmentManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Department> departments = departmentManager.GetAllDepartments();
                departmentDropDownList.DataSource = departments;
                departmentDropDownList.DataValueField = "Id";
                departmentDropDownList.DataTextField = "Code";
                departmentDropDownList.DataBind();
            }
            ReCall();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Name = nameTextBox.Text;
            employee.Contact = contactTextBox.Text;
            employee.Address = addressTextBox.Text;
            employee.BloodGroup = bloodGroupDropDownList.Text;
            employee.Email = emailTextBox.Text;
            employee.DepartmentId = Convert.ToInt32(departmentDropDownList.SelectedValue);

            messageLabel.Text = employeeManager.Save(employee);
            ReCall();
        }
        private void ReCall()
        {
            List<EmployeeVM> employees = employeeManager.GetEmployeeWithDepartmentName();
            allDataGridView.DataSource = employees;
            allDataGridView.DataBind();
        }

        
    }
}