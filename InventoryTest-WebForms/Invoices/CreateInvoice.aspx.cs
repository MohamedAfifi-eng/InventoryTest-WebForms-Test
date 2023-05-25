using InventoryTest_WebForms.Models.DBModels;
using InventoryTest_WebForms.Services;
using InventoryTest_WebForms.Services.ClientServices;
using InventoryTest_WebForms.Services.ItemServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTest_WebForms.Invoices
{
    public partial class CreateInvoice : System.Web.UI.Page
    {
        private readonly IClientService _clientRepository;
        private readonly IItemService _itemRepository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<InvoiceItem> _invoiceItemRepository;
        string dtInvoiceItems = "dtInvoiceItems";
        public CreateInvoice()
        {
            _clientRepository = new ClientService();
            _itemRepository = new ItemService();
            _invoiceRepository=new Repository<Invoice>();
            _invoiceItemRepository=new Repository<InvoiceItem>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session[dtInvoiceItems] = null;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Client> client = _clientRepository.SearchByPhone(txtSearch.Text).ToList();
            drplstClients.Items.Clear();
            drplstClients.DataTextField = "FullName";
            drplstClients.DataValueField = "Id";
            drplstClients.DataSource = client;
            drplstClients.DataBind();
        }

        protected void drplstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectedValue = drplstClients.SelectedValue;
                int clientid = int.Parse(SelectedValue);
                Client client = _clientRepository.FindById(clientid);
                txtClientID.Text = clientid.ToString();
                txtClientFullName.Text = client.FullName;
                txtClientPhone.Text = client.Phone;
                txtClientAddress.Text = client.Address;
            }
            catch (Exception)
            {

            }
        }

        protected void btnItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<Item> items = _itemRepository.SearchByName(txtItemSearch.Text).ToList();
                drpItems.Items.Clear();
                drpItems.DataValueField = "Id";
                drpItems.DataTextField = "Name";
                drpItems.DataSource = items;
                drpItems.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(drpItems.SelectedValue);
                Item item = _itemRepository.FindById(id);
                txtItemId.Text = item.Id.ToString();
                txtItemPrice.Text = item.UnitPrice.ToString();
                txtItemName.Text = item.Name;
                txtItemAvailable.Text = item.AvailableUnits.ToString();
                txtRequestedQuantity.Attributes["max"] = item.AvailableUnits.ToString();
                txtTotalPrice.Text = item.UnitPrice.ToString();
            }
            catch (Exception)
            {

            }

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = Session[dtInvoiceItems] as DataTable;
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("ItemID");
                    dt.Columns.Add("ItemName");
                    dt.Columns.Add("ItemPrice");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("TotalPrice");
                }
                DataRow row = dt.NewRow();
                row["ItemID"] = txtItemId.Text;
                row["ItemName"] = txtItemName.Text;
                row["ItemPrice"] = txtItemPrice.Text;
                row["Quantity"] = txtRequestedQuantity.Text;
                row["TotalPrice"] = txtTotalPrice.Text;
                dt.Rows.Add(row);
                Session[dtInvoiceItems] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                decimal invoiceTotalPrice, invoiceDiscountPrice, invoiceDiscountPercentage, invoiceNetPrice;
                invoiceTotalPrice = invoiceDiscountPrice = invoiceDiscountPercentage = invoiceNetPrice = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    invoiceTotalPrice += int.Parse(dt.Rows[i]["TotalPrice"].ToString());
                }
                txtInvoiceTotalPrice.Text = invoiceTotalPrice.ToString();
                decimal.TryParse(txtInvoiceDiscountPrice.Text, out invoiceDiscountPrice);
                decimal.TryParse(txtInvoiceDiscountPercentage.Text, out invoiceDiscountPercentage);
                invoiceNetPrice = invoiceTotalPrice - invoiceDiscountPrice - (invoiceDiscountPercentage * invoiceTotalPrice / 100);
                txtInvoiceNetPrice.Text = invoiceNetPrice.ToString();
                txtItemId.Text = txtItemName.Text = txtItemPrice.Text = txtRequestedQuantity.Text = txtTotalPrice.Text = txtItemAvailable.Text = "";
                drpItems.Items.Clear();
            }
            catch (Exception)
            {

            }
        }

        protected void txtRequestedQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int itemprice = int.Parse(txtItemPrice.Text);
                int quantity = int.Parse(txtRequestedQuantity.Text);
                int totalprice = itemprice * quantity;
                txtTotalPrice.Text = totalprice.ToString();

            }
            catch (Exception)
            {

            }
        }



        protected void txtInvoiceDiscountPrice_TextChanged(object sender, EventArgs e)
        {
            decimal invoiceTotalPrice, invoiceDiscountPrice, invoiceDiscountPercentage, invoiceNetPrice;
            invoiceTotalPrice = invoiceDiscountPrice = invoiceDiscountPercentage = invoiceNetPrice = 0;
            decimal.TryParse(txtInvoiceTotalPrice.Text, out invoiceTotalPrice);
            decimal.TryParse(txtInvoiceDiscountPrice.Text, out invoiceDiscountPrice);
            decimal.TryParse(txtInvoiceDiscountPercentage.Text, out invoiceDiscountPercentage);
            invoiceNetPrice = invoiceTotalPrice - invoiceDiscountPrice - (invoiceDiscountPercentage * invoiceTotalPrice / 100);
            txtInvoiceNetPrice.Text = invoiceNetPrice.ToString();
        }

        protected void BtnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (Session[dtInvoiceItems] != null)
            {
                DataTable dt = Session[dtInvoiceItems] as DataTable;
                if (dt.Rows.Count > 0)
                {
                    Invoice invoice = new Invoice();

                    invoice.InvoiceValue = float.Parse(txtInvoiceTotalPrice.Text);
                    invoice.InvoiceNetValue = float.Parse(txtInvoiceNetPrice.Text);
                    invoice.DiscountValue = float.Parse(txtInvoiceDiscountPrice.Text);
                    invoice.DiscountPercentage= float.Parse(txtInvoiceDiscountPercentage.Text);
                    invoice.ClientId_FK = int.Parse(txtClientID.Text);
                    _invoiceRepository.Create(invoice);
                    List<InvoiceItem> items = new List<InvoiceItem>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        items.Add(new InvoiceItem()
                        {
                            ItemId_FK = int.Parse(dt.Rows[i]["ItemID"].ToString()),
                            Quantity = int.Parse(dt.Rows[i]["Quantity"].ToString()),
                            UintPrice = int.Parse(dt.Rows[i]["ItemPrice"].ToString()),
                            TotalPrice = int.Parse(dt.Rows[i]["TotalPrice"].ToString()),
                             InvoiceId_FK=invoice.Id
                        });
                    }
                    _invoiceItemRepository.CreateRange(items);
                    Response.Redirect("/Default");
                }
            }
        }
    }
}