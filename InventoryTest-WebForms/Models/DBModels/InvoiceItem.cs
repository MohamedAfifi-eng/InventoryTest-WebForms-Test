using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(ItemId_FK))]
        public Item Item { get; set; }
        [ForeignKey(nameof(InvoiceId_FK))]
        public Invoice Invoice { get; set; }
        #endregion
    }
}