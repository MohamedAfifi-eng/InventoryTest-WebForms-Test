using InventoryTest_WebForms.Models.DBModels;
using InventoryTest_WebForms.Services;
using System;
using System.Web.UI;

namespace InventoryTest_WebForms.Items
{
    public partial class EditItem : System.Web.UI.Page
    {
        private readonly IRepository<Item> _repository;
        Item item;
        public EditItem()
        {
            _repository = new Repository<Item>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                     item = _repository.FindById(id);

                    if (item != null)
                    {
                        txtId.Value = item.Id.ToString();
                        txtName.Text = item.Name;
                        txtUnitPrice.Text = item.UnitPrice.ToString();
                        txtAvailableUnits.Text = item.AvailableUnits.ToString();
                    }
                    else
                    {
                        Response.StatusCode = 404;
                        Response.End();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                item=new Item();
                item.Id = int.Parse(txtId.Value);
                item.Name = txtName.Text;
                item.AvailableUnits =int.Parse( txtAvailableUnits.Text);
                item.UnitPrice =float.Parse( txtUnitPrice.Text);
                _repository.Update(item);
                Response.Redirect("List.aspx");
            }
        }
    }
}