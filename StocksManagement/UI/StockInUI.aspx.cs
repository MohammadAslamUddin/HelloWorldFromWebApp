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
    public partial class StockInUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCompanies();

                ItemList();
                MekingFalse();
            }


        }

        private void ItemList()
        {
            ListItem listItem = new ListItem("Select an Item", "-1");
            itemDropdownlist.Items.Insert(0, listItem);
        }

        private void MekingFalse()
        {
            itemDropdownlist.Enabled = false;
            reorderLevelTextBox.Enabled = false;
            availabeQuentityTextBox.Enabled = false;
            stockInQuentityTextBox.Enabled = false;
        }

        private void GetAllCompanies()
        {
            companyDropdownlist.DataSource = companyManager.GetAllCompany();
            companyDropdownlist.DataValueField = "Id";
            companyDropdownlist.DataTextField = "Name";
            companyDropdownlist.DataBind();
            ListItem listcompany = new ListItem("Select a Company", "-1");
            companyDropdownlist.Items.Insert(0, listcompany);
        }

        Item item = new Item();
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        CategoryManager categoryManager = new CategoryManager();
        StockInManager stockInManager = new StockInManager();
        protected void companyDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            List<Item> items = new List<Item>();
            if (Convert.ToInt32(companyDropdownlist.SelectedItem.Value) > 0)
            {
                items = itemManager.GetAllItems().Where(i => i.CompanyId == Convert.ToInt32(companyDropdownlist.SelectedItem.Value)).ToList();

                ListItem litems = new ListItem("Select an Item","-1");

                if (items.Count == 0)
                {
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    itemDropdownlist.DataSource = items;
                    itemDropdownlist.DataValueField = "Id";
                    itemDropdownlist.DataTextField = "Name";
                    itemDropdownlist.DataBind();

                    itemDropdownlist.Items.Insert(0, litems);
                    itemDropdownlist.SelectedIndex = 0;
                    itemDropdownlist.Enabled = true;
                }
            }
        }

        protected void itemDropdownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(companyDropdownlist.SelectedItem.Value)>0 && Convert.ToInt32(itemDropdownlist.SelectedItem.Value)>0)
            {
                item = itemManager.GetReorderLevel(Convert.ToInt32(itemDropdownlist.SelectedItem.Value));

                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                availabeQuentityTextBox.Text = item.AvailableQuentity.ToString();
                stockInQuentityTextBox.Enabled = true;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(companyDropdownlist.SelectedItem.Value) > 0 && Convert.ToInt32(itemDropdownlist.SelectedItem.Value) > 0)
            {

                StockIn stockIn = new StockIn();
                if (stockInQuentityTextBox.Text.Equals(""))
                {
                    messageLabel.Text = "Please Enter some value for stock In";
                }
                else
                {
                    stockIn.CompanyId = Convert.ToInt32(companyDropdownlist.SelectedItem.Value);
                    stockIn.ItemId = Convert.ToInt32(itemDropdownlist.SelectedItem.Value);
                    stockIn.AvailableQuentity = Convert.ToInt32(availabeQuentityTextBox.Text);
                    stockIn.StockInQuentity = Convert.ToInt32(stockInQuentityTextBox.Text);
                    stockIn.reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

                    messageLabel.Text = stockInManager.Save(stockIn);

                    GetAllCompanies();
                    
                    itemDropdownlist.Items.Clear();
                    
                    ItemList();
                    
                    MekingFalse();

                    reorderLevelTextBox.Text = String.Empty;
                    availabeQuentityTextBox.Text = String.Empty;
                    stockInQuentityTextBox.Text = String.Empty;
                }
            }
        }
    }
}