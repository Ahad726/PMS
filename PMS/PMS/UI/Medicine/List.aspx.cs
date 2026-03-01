using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.DAL.DAO;
using System.Web.Services;
using System.Web.Script.Services;


namespace PMS.UI.Medicine
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/LoginUI.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            Response.Redirect("Edit.aspx?id=" + id);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            var mediManager = new BLL.MedicineManager();
            int rowsDeleted = mediManager.DeleteMedicineById(Convert.ToInt32(id));

            if (rowsDeleted > 0)
            {
                string message = "<script>alert('Medicine deleted successfully')</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
                Response.Redirect("List.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add.aspx");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string message = "<script>alert('Export will be added soon')</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
        }
    }
}