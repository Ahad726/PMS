using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using PMS.BLL;
using PMS.Dto;

namespace PMS.UI.Invoice
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<DAL.DAO.Medicine> GetMedicines()
        {
            var mediManager = new MedicineManager();
            var medicines = mediManager.GetMedicines();
            return medicines;
        }

        [WebMethod]
        public static MedicineDto GetMedicineById(string id)
        {
            var medId = Convert.ToInt32(id);
            var mediManager = new MedicineManager();
            var medicine = mediManager.GetMedicineById(medId);
            var med = new MedicineDto
            {
                Id = medicine.Id,
                MedicineName = medicine.MedicineName,
                BatchNo = medicine.BatchNo,
                ExpiryDate = medicine.ExpiryDate.ToString("dd-MMM-yyyy"),
                UnitPrice = medicine.UnitPrice
            };
            return med;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var medList = new List<DAL.DAO.Medicine>();
            var allKeyList = Request.Form.AllKeys
                                    .Where(key => key.StartsWith("MedicineId"))
                                    .ToList();

            foreach (var key in allKeyList)
            {
                var index = key.Replace("MedicineId[", "").Replace("]","");

                var medicineId = Convert.ToInt32(Request.Form["MedicineId[" + index + "]"]);
                var quantity = Convert.ToInt32(Request.Form["Quantity[" + index + "]"]);
                var med = new DAL.DAO.Medicine();
                med.Id = medicineId;
                med.Quantity = quantity;
                medList.Add(med);
            }

            bool isStockAvailble = true;
            var medManager = new MedicineManager();
            foreach (var med in medList)
            {
                isStockAvailble = medManager.IsMedStockAvailable(med.Id, med.Quantity);

                if (!isStockAvailble)
                {
                    string message = "<script>alert('Insufficient Medicine stock ')</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
                    break;
                }
            }

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

        }
    }
}