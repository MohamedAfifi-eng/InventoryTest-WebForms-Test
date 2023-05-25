using InventoryTest_WebForms.Models.DBModels;
using InventoryTest_WebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTest_WebForms.Items
{
    public partial class CreateItem : System.Web.UI.Page
    {
        private readonly IRepository<Item> repository;

        public CreateItem()
        {
            this.repository = new Repository<Item>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Item item = new Item();
                item.UnitPrice = float.Parse( txtUnitPrice.Text); // we shold make a validation proccess here to avoid errors
                item.Name=txtName.Text;
                item.AvailableUnits = int.Parse(txtAvailableUnits.Text);// we shold make a validation proccess here to avoid errors
                repository.Create(item);
                Response.Redirect("List.aspx");
            }
            
        }
    }
}