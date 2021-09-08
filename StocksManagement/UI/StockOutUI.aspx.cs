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
    public partial class StockOutUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCompanies();

                GetItems();

                MakingFalse();

                GridViewData();
            }
        }

        private void GridViewData()
        {
            if (ViewState["StockOut"] != null)
            {
                List<StockOut> stockOutItems = (List<StockOut>) ViewState["StockOut"];
                stockOutGridView.DataSource = stockOutItems;
                stockOutGridView.DataBind();
                
                MakingTrue();
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stockOutQuentityTextBox.Text)>Convert.ToInt32(availableQuentityTextBox.Text))
            {
                messageLabel.Text = "StockOut Quantity cannot be greater than available Quantity";
            }
            else if (stockOutQuentityTextBox.Text.Equals(""))
            {
                messageLabel.Text = "Stock Out Quantity Can not be empty!";
            }
            else
            {
                stockOutGridView.Visible = true;
                StockOut stockOut = new StockOut();
                stockOut.CompanyId = Convert.ToInt32(companyDropdownList.SelectedItem.Value);
                stockOut.ItemId = Convert.ToInt32(itemDropdownList.SelectedItem.Value);
                stockOut.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                stockOut.CompanyName = companyDropdownList.SelectedItem.ToString();
                stockOut.ItemName = itemDropdownList.SelectedItem.ToString();
                
                stockOut.AvailableQuantity = Convert.ToInt32(availableQuentityTextBox.Text) - Convert.ToInt32(stockOutQuentityTextBox.Text);
                stockOut.StockOutQuantity = Convert.ToInt32(stockOutQuentityTextBox.Text);

                if (ViewState["StockOut"]!=null)
                {
                    int flag = 0;
                    List<StockOut> stockOutList = (List<StockOut>) ViewState["StockOut"];
                    foreach (StockOut stock in stockOutList)
                    {
                        if (stock.ItemId == stockOut.ItemId)
                        {
                            stock.AvailableQuantity = stockOut.AvailableQuantity;
                            stock.StockOutQuantity += stockOut.StockOutQuantity;
                            flag = 1;
                            break;
                        }
                    }

                    if (flag == 0)
                    {
                        stockOutList.Add(stockOut);

                        ViewState["StockOut"] = stockOutList;
                    }

                    GridViewData();
                }
                else
                {
                    List<StockOut> stockOutList = new List<StockOut>();
                    
                    stockOutList.Add(stockOut);

                    ViewState["StockOut"] = stockOutList;

                    GridViewData();
                }

                availableQuentityTextBox.Text = stockOut.AvailableQuantity.ToString();
            }
            stockOutQuentityTextBox.Text = String.Empty;
            
        }

        private void GetItems()
        {
            ListItem listItem = new ListItem("Select an Item", "-1");
            itemDropdownList.Items.Insert(0, listItem);
        }

        private void MakingFalse()
        {
            itemDropdownList.Enabled = false;
            reorderLevelTextBox.Enabled = false;
            availableQuentityTextBox.Enabled = false;
            stockOutQuentityTextBox.Enabled = false;
            addButton.Enabled = false;
            sellButton.Visible = false;
            damageButton.Visible = false;
            lostButton.Visible = false;
            stockOutGridView.Visible = false;
        }

        private void GetAllCompanies()
        {
            companyDropdownList.DataSource = companyManager.GetAllCompany();
            companyDropdownList.DataTextField = "Name";
            companyDropdownList.DataValueField = "Id";
            companyDropdownList.DataBind();
            ListItem listCompanItem = new ListItem("Select a Company", "-1");
            companyDropdownList.Items.Insert(0, listCompanItem);
        }

        StockOutManager stockOutManager = new StockOutManager();
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();

        Item item = new Item();
        protected void itemDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            messageLabel.Text = String.Empty;
            if (Convert.ToInt32(companyDropdownList.SelectedItem.Value)>0 && Convert.ToInt32(itemDropdownList.SelectedItem.Value)>0)
            {
                
                item = itemManager.GetReorderLevel(Convert.ToInt32(itemDropdownList.SelectedItem.Value));

                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                availableQuentityTextBox.Text = item.AvailableQuentity.ToString();
                stockOutQuentityTextBox.Enabled = true;
                addButton.Enabled = true;
            }
        }

        private void MakingTrue()
        {
            sellButton.Visible = true;
            damageButton.Visible = true;
            lostButton.Visible = true;
        }

        protected void companyDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();
            if (Convert.ToInt32(companyDropdownList.SelectedItem.Value)>0)
            {
                MakingEmpty();
                items = itemManager.GetAllItems().
                    Where(i => i.CompanyId == Convert.ToInt32(companyDropdownList.SelectedItem.Value)).ToList();

                if (items.Count == 0)
                {
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    itemDropdownList.DataSource = items;
                    itemDropdownList.DataValueField = "Id";
                    itemDropdownList.DataTextField = "Name";
                    itemDropdownList.DataBind();
                    GetItems();

                    itemDropdownList.Enabled = true;
                }
            }
        }

        private void MakingEmpty()
        {
            reorderLevelTextBox.Text = String.Empty;
            availableQuentityTextBox.Text = String.Empty;
            stockOutQuentityTextBox.Text = String.Empty;
            
        }

        
        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOutItems =(List<StockOut>) ViewState["StockOut"];
            messageLabel.Text = stockOutManager.StockOut(stockOutItems, "Sell");

            GetAllCompanies();
            GetItems();
            MakingFalse();
            MakingEmpty();
            ViewState["StockOut"] = null;
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOutItems = (List<StockOut>)ViewState["StockOut"];
            messageLabel.Text = stockOutManager.StockOut(stockOutItems, "Damage");

            GetAllCompanies();
            GetItems();
            MakingFalse();
            MakingEmpty();
            ViewState["StockOut"] = null;
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOutItems = (List<StockOut>)ViewState["StockOut"];
            messageLabel.Text = stockOutManager.StockOut(stockOutItems, "Lost");

            GetAllCompanies();
            GetItems();
            MakingFalse();
            MakingEmpty();
            ViewState["StockOut"] = null;
        }
    }
}