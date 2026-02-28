using PMS.DAL.DAO;
using PMS.DAL.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public class InvoiceManager
    {

        public Medicine GetMedicineById(int id)
        {
            var mediGateway = new MedicineGateway();
            return mediGateway.GetMedicineById(id);
        }


        public int CreateInvoice(InvoiceMaster invoiceMaster, List<Medicine> customerMedicineList)
        {
            decimal subTotal = 0m;
            decimal grandTotal = 0m;
            var invoiceDetailsList = new List<InvoiceDetails>();

            foreach (var customerMed in customerMedicineList)
            {
                var existingMedicine = GetMedicineById(customerMed.Id);
                
                subTotal += customerMed.Quantity * existingMedicine.UnitPrice;


                var invDetails = new InvoiceDetails();
                invDetails.MedicineId = customerMed.Id;
                invDetails.Quantity = customerMed.Quantity;
                invDetails.MedName = existingMedicine.MedicineName;
                invDetails.UnitPrice = existingMedicine.UnitPrice;
                invDetails.BatchNo = existingMedicine.BatchNo;
                invDetails.ExpiryDate = existingMedicine.ExpiryDate;

                invoiceDetailsList.Add(invDetails);
            }

            decimal discountPercentage = invoiceMaster.Discount;
            decimal discountedAmount = subTotal * discountPercentage / 100m;

            grandTotal = subTotal - discountedAmount;

            invoiceMaster.SubTotal = subTotal;
            invoiceMaster.GrandTotal = grandTotal;

            var invGateway = new InvoiceGateway();
            int result = invGateway.CreateInvoice(invoiceMaster, invoiceDetailsList);

            return result;
        }
    }
}
