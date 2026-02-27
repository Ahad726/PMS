using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.UI.Medicine
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    int medicineId = Convert.ToInt32(id);
                    var medicineManager = new MedicineManager();
                    var medicine = medicineManager.GetMedicineById(medicineId);
                    if (medicine != null)
                    {
                        MedNameTxt.Text = medicine.MedicineName;
                        GrpNameTxt.Text = medicine.GroupName;
                        BatchNoTxt.Text = medicine.BatchNo;
                        ExpiryDateTxt.Text = medicine.ExpiryDate.ToString("yyyy-MM-dd");
                        QuantityTxt.Text = medicine.Quantity.ToString();
                        UnitPriceTxt.Text = medicine.UnitPrice.ToString("F2");
                    }
                }
            }
        }

        protected void MedUpdateButton_Click(object sender, EventArgs e)
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
        }
    }
}