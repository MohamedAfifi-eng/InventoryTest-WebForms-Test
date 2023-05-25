using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTest_WebForms.Models.DBModels
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId_FK { get; set; }
        public int ItemId_FK { get; set; }
        public float UintPrice { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }

        #region Navigation Properties 
        public Item Item { get; set; }
        public Invoice Invoice { get; set; }
        #endregion
    }
}