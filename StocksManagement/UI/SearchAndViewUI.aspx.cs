using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorldFromWebApp.StocksManagement.BLL;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.UI
{
    public partial class Search_ViewUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCompanies();

                GetAllCategories();
            }
        }

        private void GetAllCategories()
        {
            categoryDropdownList.DataSource = categoryManager.GetAllCategory();
            categoryDropdownList.DataTextField = "Name";
            categoryDropdownList.DataValueField = "Id";
            categoryDropdownList.DataBind();
            ListItem listCategoryItem = new ListItem("Select a Category", "-1");
            categoryDropdownList.Items.Insert(0, listCategoryItem);
        }

        private void GetAllCompanies()
        {
            companyDropdownList.DataSource = companyManager.GetAllCompany();
            companyDropdownList.DataTextField = "Name";
            companyDropdownList.DataValueField = "Id";
            companyDropdownList.DataBind();
            ListItem listCompanyItem = new ListItem("Select a Company", "-1");
            companyDropdownList.Items.Insert(0, listCompanyItem);
        }

        CompanyManager companyManager = new CompanyManager();
        CategoryManager categoryManager = new CategoryManager();
        ViewAndSearchManager viewAndSearchManager = new ViewAndSearchManager();

        protected void searchButton_Click(object sender, EventArgs e)
        {
            StockOut stockOut = new StockOut();
            int companyId = Convert.ToInt32(companyDropdownList.SelectedItem.Value);
            int categoryId = Convert.ToInt32(categoryDropdownList.SelectedItem.Value);

            List<StockOut> stockOutlList = new List<StockOut>();

            if (companyId>0 && categoryId>0)
            {
                stockOutlList = viewAndSearchManager.GetItemByCompanyAndCategory(companyId, categoryId);
            }
            else if (companyId>0 && categoryId<0)
            {
                stockOutlList = viewAndSearchManager.GetItemByCompany(companyId);
            }
            else if (companyId<0 && categoryId>0)
            {
                stockOutlList = viewAndSearchManager.GetItemByCategory(categoryId);
            }
            else
            {
                messageLabel.Text = "Select a value from Dropdownlist";
            }

            if (stockOutlList.Count == 0)
            {
                viewSearchGridView.Visible = false;
                messageLabel.Text = "There is No value";
            }
            else
            {
                viewSearchGridView.Visible = true;
                messageLabel.Text = String.Empty;
                viewSearchGridView.DataSource = (List<StockOut>) stockOutlList;
                viewSearchGridView.DataBind();
            }
        }
    }
}