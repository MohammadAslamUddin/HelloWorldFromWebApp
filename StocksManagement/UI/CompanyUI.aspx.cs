using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorldFromWebApp.StocksManagement.BLL;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.UI
{
    public partial class CompanyUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            compnayGridView.DataSource = companyManager.GetAllCompany();
            compnayGridView.DataBind();
        }

        CompanyManager companyManager = new CompanyManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Name = nameTextBox.Text;

            messageLabel.Text = companyManager.Save(company);

            PopulateGridView();
        }
    }
}