using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace InventoryTest_WebForms.Models.DBModels
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ClientId_FK { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public float InvoiceValue { get; set; }
        public float DiscountValue { get; set; }
        public float DiscountPercentage { get; set; }
        public float InvoiceNetValue { get; set; }

        #region Navigation Properties 
        [ForeignKey(nameof(ClientId_FK))]
        public Client Client { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItems { get; set; }
        #endregion
    }
}