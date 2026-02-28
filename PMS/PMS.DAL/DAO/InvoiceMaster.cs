using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.DAO
{
    public class InvoiceMaster
    {
        public int Id { get; set; }
        public string InvNo { get; set; }
        public DateTime Date { get; set; }
        public string CName { get; set; }
        public string CContact { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
