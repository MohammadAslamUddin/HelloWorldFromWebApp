using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorldFromWebApp.StocksManagement.DAL.Gateway;
using HelloWorldFromWebApp.StocksManagement.DAL.Model;

namespace HelloWorldFromWebApp.StocksManagement.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();

        public string Save(Item item)
        {
            if (itemGateway.IsItemNameExist(item.Name))
            {
                return "Item Exist!";
            }
            else
            {
                int rowAffected = itemGateway.Save(item);
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

        public List<Item> GetAllItems()
        {
            return itemGateway.GetAllItems();
        }

        public Item GetReorderLevel(int itemId)
        {
            return itemGateway.GetReorderLevel(itemId);
        }
    }
}