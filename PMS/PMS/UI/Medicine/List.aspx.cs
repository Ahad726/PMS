using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.UI.Medicine
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}