using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorldFromWebApp.BLL;

namespace HelloWorldFromWebApp
{
    public partial class FindEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        EmployeeManager employeeManager = new EmployeeManager();
        protected void findButton_Click(object sender, EventArgs e)
        {
            Employee employee = employeeManager.Find(emailTextBox.Text);

            if (employee!=null)
            {
                messageLabel.Text = String.Empty;
                nameTextBox.Text = employee.Name;
                emailTextBox.Text = employee.Email;
                addressTextBox.Text = employee.Address;
                contactTextBox.Text = employee.Contact;
                bloodGroupDropDownList.Text = employee.BloodGroup;
                hiddenId.Value = employee.Id.ToString();
                updateButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            else
            {
                AllClear();
                messageLabel.Text = "No Data";
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Name = nameTextBox.Text;
            employee.Contact = contactTextBox.Text;
            employee.Address = addressTextBox.Text;
            employee.BloodGroup = bloodGroupDropDownList.Text;
            employee.Email = emailTextBox.Text;
            employee.Id = Convert.ToInt32(hiddenId.Value);

            messageLabel.Text = employeeManager.Update(employee);
            AllClear();
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hiddenId.Value);
            messageLabel.Text = employeeManager.Delete(id);
            AllClear();
        }

        private void AllClear()
        {
            nameTextBox.Text = String.Empty;
            emailTextBox.Text = String.Empty;
            contactTextBox.Text = String.Empty;
            bloodGroupDropDownList.Text = String.Empty;
            addressTextBox.Text = String.Empty;
        }
    }
}