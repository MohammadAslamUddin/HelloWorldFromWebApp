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
    public partial class AddBookUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        BookManager bookManager = new BookManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Name = nameTextBox.Text;
            book.Isbn = isbnTextBox.Text;
            book.Author = authorTextBox.Text;

            messageLabel.Text = bookManager.Save(book);
        }
    }
}