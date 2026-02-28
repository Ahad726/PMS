using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.DAO
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int InvoiceMasterId { get; set; }
        public int MedicineId { get; set; }
        public string MedName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
