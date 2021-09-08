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
    public partial class CategoryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }
        CategoryManager categoryManager = new CategoryManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = nameTextBox.Text;

            messageLabel.Text = categoryManager.Save(category);

            PopulateGridView();
        }

        private void PopulateGridView()
        {
            categoryGridView.DataSource = categoryManager.GetAllCategory();
            categoryGridView.DataBind();
        }
    }
}