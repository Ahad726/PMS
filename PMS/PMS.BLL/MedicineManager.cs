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
    [DataObject]
    public class MedicineManager
    {
        public List<Medicine> GetMedicines()
        {
            var mediGateway = new MedicineGateway();
            return mediGateway.GetMedicineList();
        }

        public int InsertMedicine(Medicine medicine)
        {
            var mediGateway = new MedicineGateway();
            return mediGateway.InsertMedicine(medicine);
        }

        public int UpdateMedicine(Medicine medicine)
        {
            var mediGateway = new MedicineGateway();
            return mediGateway.UpdateMedicine(medicine);
        }
        public Medicine GetMedicineById(int id)
        {
            var mediGateway = new MedicineGateway();
            return mediGateway.GetMedicineById(id);
        }
        public int DeleteMedicineById(int id)
        {
            var mediGateway = new MedicineGateway();
            return mediGateway.DeleteMedicine(id);
        }
        public bool IsMedStockAvailable(int medicineId, int requiredQuantity)
        {
            bool isAvailable = false;
            string message = string.Empty;
            var mediGateway = new MedicineGateway();
            return mediGateway.IsStockAvailable(medicineId, requiredQuantity);
        }
    }
}
