using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS
{
    public partial class MedicineUI : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MedSaveButton_Click(object sender, EventArgs e)
        {
            int savedRowCount = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Insert into Medicines (MedicineName, GroupName, BatchNo, Quantity, UnitPrice, ExpiryDate)
                                values (@MedicineName, @GroupName, @BatchNo, @Quantity, @UnitPrice, @ExpiryDate)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@MedicineName", MedNameTxt.Text);
                cmd.Parameters.AddWithValue("@GroupName", GrpNameTxt.Text);
                cmd.Parameters.AddWithValue("@BatchNo", BatchNoTxt.Text);
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(QuantityTxt.Text));
                cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(UnitPriceTxt.Text));
                cmd.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(ExpiryDateTxt.Text));

                con.Open();
                savedRowCount = cmd.ExecuteNonQuery();
            }


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
    }
}