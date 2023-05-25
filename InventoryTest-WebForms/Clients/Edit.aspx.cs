using InventoryTest_WebForms.Models.DBModels;
using InventoryTest_WebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace InventoryTest_WebForms.Clients
{
    public partial class Edit : System.Web.UI.Page
    {
        private readonly IRepository<Client> _repository;
        public Edit()
        {
            _repository=new Repository<Client>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"],out int id))
                {
                    var client= _repository.FindById(id);
                    txtId.Value = id.ToString();
                    txtAccount.Text = client.Account.ToString();
                    txtAddress.Text = client.Address;
                    txtFullName.Text = client.FullName; 
                    txtPhone.Text = client.Phone;
                }
                else
                {
                    Response.StatusCode = 404;
                    Response.End();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Client client=new Client();
                client.Id = int.Parse( txtId.Value);
                client.FullName=txtFullName.Text;
                client.Phone=txtPhone.Text; 
                client.Address=txtAddress.Text;
                if (double.TryParse(txtAccount.Text, out double account))
                {
                    client.Account = account;
                }
                _repository.Update(client);
                Response.Redirect("List");
            } 
        }
    }
}