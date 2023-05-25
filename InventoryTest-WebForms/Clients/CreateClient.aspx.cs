using InventoryTest_WebForms.Models.DBModels;
using InventoryTest_WebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTest_WebForms.Clients
{
    public partial class CreateClient : System.Web.UI.Page
    {
        private readonly IRepository<Client> _repository;
        public CreateClient()
        {
            _repository= new Repository<Client>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Client client = new Client();
                client.FullName = txtFullName.Text;
                client.Phone = txtPhone.Text;
                client.Address= txtAddress.Text;
                if (double.TryParse(txtAccount.Text,out double account))
                {
                    client.Account = account;
                }
                else
                {
                    client.Account = 0;
                }
                _repository.Create(client);
                Response.Redirect("List");
            }
        }
    }
}