using InventoryTest_WebForms.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest_WebForms.Services.ClientServices
{
    public interface IClientService:IRepository<Client>
    {
        IEnumerable<Client> SearchByPhone(string phone);
    }
}
