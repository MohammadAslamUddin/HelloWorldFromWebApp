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
    public partial class ViewSalesBetweenTwoDates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ViewSalesWithDateManager viewSalesWithDateManager = new ViewSalesWithDateManager();
        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromdateTextBox.Text;
            string toDate = toDateTextBox.Text;
            if (fromDate.Equals("") || toDate.Equals(""))
            {
                messageLabel.Text = "Dates aren't valid";
            }
            else
            {
                List<ViewSalesWithDate> viewSalesWithDate = viewSalesWithDateManager.GetSelles(fromDate, toDate);
                if (viewSalesWithDate.Count == 0)
                {
                    viewSearchGridView.Visible = false;
                    messageLabel.Text = "No data is available";
                }
                else
                {
                    viewSearchGridView.Visible = true;
                    messageLabel.Text = String.Empty;
                    viewSearchGridView.DataSource = viewSalesWithDate;
                    viewSearchGridView.DataBind();
                }
            }
        }
    }
}