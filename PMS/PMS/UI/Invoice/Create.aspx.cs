using Microsoft.Ajax.Utilities;
using PMS.BLL;
using PMS.DAL.DAO;
using PMS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.UI.Invoice
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/LoginUI.aspx");
            }
            var invNumber = "INV-" + DateTime.Now.ToString("yyMMddHHmmss").PadLeft(10, '0');
            InvoiceNoTextBox.Text = invNumber;
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
            var allKeyList = Request.Form.AllKeys.Where(key => key.StartsWith("MedicineId")).ToList();

            foreach (var key in allKeyList)
            {
                var index = key.Replace("MedicineId[", "").Replace("]", "");

                string medIdStr = Request.Form["MedicineId[" + index + "]"];
                if (string.IsNullOrEmpty(medIdStr))
                {
                    string message = $"<script>alert('Medicine is not selected')</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
                    return;
                }

                string qtyStr = Request.Form["Quantity[" + index + "]"];
                if (string.IsNullOrEmpty(qtyStr))
                {
                    string message = $"<script>alert('Quantity is required')</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
                    return;
                }

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
                    var medicine = medManager.GetMedicineById(med.Id);
                    string message = $"<script>alert('Insufficient stock for medicine: {medicine.MedicineName} , Batch No: {medicine.BatchNo}')</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
                    return;
                }
            }

            var invMaster = new InvoiceMaster();
            invMaster.InvNo = InvoiceNoTextBox.Text;
            invMaster.Date = DateTime.Parse(DateTextBox.Text);
            invMaster.CName = CustNameTextBox.Text;
            invMaster.CContact = ContactTextBox.Text;
            invMaster.Discount = 0;
            if (!string.IsNullOrEmpty(discountInput.Text))
            {
                invMaster.Discount = Convert.ToDecimal(discountInput.Text);
            }

            var invManager = new InvoiceManager();
            int id = invManager.CreateInvoice(invMaster, medList);

            //if (result > 0)
            //{
            //    string message = $"<script>alert('Invoice is created')</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", message);
            //}

            //discountInput.Text = string.Empty;

            Response.Redirect("Print.aspx?id=" + id);

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }
    }
}