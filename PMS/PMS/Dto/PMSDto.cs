using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Dto
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string BatchNo { get; set; }
    }
}