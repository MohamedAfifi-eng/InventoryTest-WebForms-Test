using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTest_WebForms.Models.DBModels
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Account { get; set; }

        #region Navigation Properties 
        public IEnumerable<Invoice> Invoices { get; set; }
        #endregion

    }
}