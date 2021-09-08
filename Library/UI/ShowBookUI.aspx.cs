using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorldFromWebApp.Library.BLL;
using HelloWorldFromWebApp.Library.DAL.Model;

namespace HelloWorldFromWebApp.Library.UI
{
    public partial class ShowBookUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView("");
        }

        private void PopulateGridView(string name)
        {
            bookGridView.DataSource = showBookManager.GetAllBooks(name);
            bookGridView.DataBind();
        }

        ShowBookManager showBookManager  = new ShowBookManager();
        protected void searchButton_Click(object sender, EventArgs e)
        {
            string name = searchTextBox.Text;
            PopulateGridView(name);

        }
    }
}