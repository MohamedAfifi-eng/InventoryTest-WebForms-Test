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
    public partial class List : System.Web.UI.Page
    {
        private readonly IRepository<InventoryTest_WebForms.Models.DBModels.Item> repository;
        public List()
        {
            repository=new Repository<InventoryTest_WebForms.Models.DBModels.Item>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvList.DataSource = repository.GetAll();
            gvList.DataBind();
        }
    }
}