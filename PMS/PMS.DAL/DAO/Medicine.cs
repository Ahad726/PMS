using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.DAO
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string GroupName { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }

        public Medicine()
        {
            IsDeleted = false;
        }
    }
}
