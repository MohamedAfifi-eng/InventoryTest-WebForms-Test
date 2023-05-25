using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTest_WebForms.Models.DBModels
{
    public class Item
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableUnits { get; set; }

        #region Navigation Properties 
        public IEnumerable<InvoiceItem> invoiceItems { get; set; }
        #endregion
    }
}