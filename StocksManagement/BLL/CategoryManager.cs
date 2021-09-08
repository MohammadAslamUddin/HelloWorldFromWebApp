using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

        public string Save(Category category)
        {
            if (categoryGateway.IsExistCategory(category.Name))
            {
                return "Category Name Must be Unique!";
            }
            else
            {
                int rowAffected = categoryGateway.Save(category);
                if (rowAffected>0)
                {
                    return "Saved!";
                }
                else
                {
                    return "Saving Failed!";
                }
            }
        }
    }
}