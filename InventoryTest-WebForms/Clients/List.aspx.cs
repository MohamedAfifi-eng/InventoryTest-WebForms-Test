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
    public partial class List : System.Web.UI.Page
    {
        private readonly IRepository<Client> _repository;
        public List()
        {
                _repository=new Repository<Client>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvClientsList.DataSource = _repository.GetAll();
            gvClientsList.DataBind();
        }
    }
}