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
    public partial class ItemUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryList();
                CompnayList();
            }
        }
        
        ItemManager itemManager = new ItemManager();
        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        
        
        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(categoryDropdownList.SelectedItem.Value)>0 && Convert.ToInt32(companyDropdownList.SelectedItem.Value)>0)
            {
                if (itemNameTextBox.Text.Equals(""))
                {
                    messageLabel.Text = "Please Enter a name for ITEM";
                }
                else
                {
                    Item item = new Item();
                    item.CategoryId = Convert.ToInt32(categoryDropdownList.SelectedValue);
                    item.CompanyId = Convert.ToInt32(companyDropdownList.SelectedValue);
                    item.Name = itemNameTextBox.Text;
                    if (reorderLevelTextBox.Text.Equals(""))
                    {
                        item.ReorderLevel = 0;
                    }
                    else
                    {
                        item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                    }

                    messageLabel.Text = itemManager.Save(item);
                }
            }
            else
            {
                messageLabel.Text = "Select the category and Company First!";
            }
        }
        private void CompnayList()
        {
            companyDropdownList.DataSource = companyManager.GetAllCompany();
            companyDropdownList.DataValueField = "Id";
            companyDropdownList.DataTextField = "Name";
            companyDropdownList.DataBind();
            ListItem listCompany = new ListItem("Select a Company", "-1");
            companyDropdownList.Items.Insert(0, listCompany);
        }

        private void CategoryList()
        {
            categoryDropdownList.DataSource = categoryManager.GetAllCategory();
            categoryDropdownList.DataValueField = "Id";
            categoryDropdownList.DataTextField = "Name";
            categoryDropdownList.DataBind();
            ListItem listitem = new ListItem("Select a Category", "-1");
            categoryDropdownList.Items.Insert(0, listitem);
        }
    }
}