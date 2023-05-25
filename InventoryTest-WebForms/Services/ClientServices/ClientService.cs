using InventoryTest_WebForms.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTest_WebForms.Services.ClientServices
{
    public class ClientService : Repository<Client>, IClientService
    {
        public IEnumerable<Client> SearchByPhone(string phone)
        {
            return _db.Clients.Where(x=>x.Phone.Contains(phone));
        }
    }
}