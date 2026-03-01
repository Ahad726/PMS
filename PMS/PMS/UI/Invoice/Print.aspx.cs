using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;

namespace PMS.UI.Invoice
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/LoginUI.aspx");
            }

            string id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("Create.aspx");
            }

            var invId = Convert.ToInt32(id);
            var invManager = new InvoiceManager();
            var invoiceMaster = invManager.GetInvoiceById(invId);

            if (invoiceMaster == null)
            {
                Response.Redirect("Create.aspx");
            }

            InvoiceNoLbl.Text = invoiceMaster.InvNo;
            DateLbl.Text = invoiceMaster.Date.ToString("dd-MMM-yyyy");
            CustNameLbl.Text = invoiceMaster.CName;
            ContactLbl.Text = invoiceMaster.CContact;
            subtotalLbl.Text = invoiceMaster.SubTotal.ToString("0.00");
            DiscountLbl.Text = invoiceMaster.Discount.ToString("0.00");
            GndTotalLbl.Text = invoiceMaster.GrandTotal.ToString("0.00");


            var invoiceDetails = invManager.GetInvoiceDetailsByMasterId(invId);
            InvoiceDetailsGrid.DataSource = invoiceDetails;
            InvoiceDetailsGrid.DataBind();
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }
    }
}