using InventoryTest_WebForms.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTest_WebForms.Services.ItemServices
{
    public class ItemService : Repository<Item>, IItemService
    {
        public IEnumerable<Item> SearchByName(string name)
        {
            return _db.Items.Where(x => x.Name.Contains(name));
        }
    }
}