using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.UI.Medicine
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/LoginUI.aspx");
            }
            UnitPriceTxt.Attributes["step"] = "0.1";
        }

        protected void MedSaveButton_Click(object sender, EventArgs e)
        {
            var medMenager = new MedicineManager();
            int savedRowCount = medMenager.InsertMedicine(new DAL.DAO.Medicine
            {
                MedicineName = MedNameTxt.Text,
                GroupName = GrpNameTxt.Text,
                BatchNo = BatchNoTxt.Text,
                Quantity = Convert.ToInt32(QuantityTxt.Text),
                ExpiryDate = Convert.ToDateTime(ExpiryDateTxt.Text),
                UnitPrice = Convert.ToDecimal(UnitPriceTxt.Text)
            });
            if (savedRowCount > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Medicine saved successfully')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Medicine save Failed')</script>");
            }

            ClearMedicineForm();
        }

        private void ClearMedicineForm()
        {
            MedNameTxt.Text = string.Empty;
            GrpNameTxt.Text = string.Empty;
            BatchNoTxt.Text = string.Empty;
            QuantityTxt.Text = string.Empty;
            ExpiryDateTxt.Text = string.Empty;
            UnitPriceTxt.Text = string.Empty;
            MedNameTxt.Focus();
        }

        protected void MedCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}