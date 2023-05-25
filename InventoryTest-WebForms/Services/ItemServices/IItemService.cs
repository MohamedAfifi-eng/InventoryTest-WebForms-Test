using InventoryTest_WebForms.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest_WebForms.Services.ItemServices
{
    internal interface IItemService:IRepository<Item>
    {
        IEnumerable<Item> SearchByName(string name);
    }
}
