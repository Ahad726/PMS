using PMS.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace PMS.DAL.Gateway
{
    public class MedicineGateway
    {

        string conString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;

        public List<Medicine> GetMedicineList()
        {
            var medList = new List<Medicine>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Select * From Medicines";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var med = new Medicine();
                            med.Id = Convert.ToInt32(reader["Id"]);
                            med.MedicineName = Convert.ToString(reader["MedicineName"]);
                            med.GroupName = Convert.ToString(reader["GroupName"]);
                            med.BatchNo = Convert.ToString(reader["BatchNo"]);
                            med.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                            med.Quantity = Convert.ToInt32(reader["Quantity"]);
                            med.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                            medList.Add(med);
                        }
                    }
                }
            }
            return medList;
        }

        public int InsertMedicine(Medicine medicine)
        {
            int rowsSaved = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Insert Into Medicines (MedicineName, GroupName, BatchNo, ExpiryDate, Quantity, UnitPrice, IsDeleted) 
                                 VALUES (@MedicineName, @GroupName, @BatchNo, @ExpiryDate, @Quantity, @UnitPrice, @IsDeleted )";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MedicineName", medicine.MedicineName);
                    cmd.Parameters.AddWithValue("@GroupName", medicine.GroupName);
                    cmd.Parameters.AddWithValue("@BatchNo", medicine.BatchNo);
                    cmd.Parameters.AddWithValue("@ExpiryDate", medicine.ExpiryDate);
                    cmd.Parameters.AddWithValue("@Quantity", medicine.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", medicine.UnitPrice);
                    cmd.Parameters.AddWithValue("@IsDeleted", medicine.IsDeleted);
                    con.Open();
                    rowsSaved = cmd.ExecuteNonQuery();
                }
            }
            return rowsSaved;
        }


        public int UpdateMedicine(Medicine medicine)
        {
            int rowsUpdated = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Update Medicines Set MedicineName=@MedicineName, GroupName=@GroupName, BatchNo=@BatchNo, ExpiryDate=@ExpiryDate, Quantity=@Quantity, UnitPrice=@UnitPrice 
                                 WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", medicine.Id);
                    cmd.Parameters.AddWithValue("@MedicineName", medicine.MedicineName);
                    cmd.Parameters.AddWithValue("@GroupName", medicine.GroupName);
                    cmd.Parameters.AddWithValue("@BatchNo", medicine.BatchNo);
                    cmd.Parameters.AddWithValue("@ExpiryDate", medicine.ExpiryDate);
                    cmd.Parameters.AddWithValue("@Quantity", medicine.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", medicine.UnitPrice);
                    con.Open();
                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }
            return rowsUpdated;
        }

        public Medicine GetMedicineById(int id)
        {
            Medicine medicine = null;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Select * From Medicines Where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            medicine = new Medicine();
                            medicine.Id = Convert.ToInt32(reader["Id"]);
                            medicine.MedicineName = Convert.ToString(reader["MedicineName"]);
                            medicine.GroupName = Convert.ToString(reader["GroupName"]);
                            medicine.BatchNo = Convert.ToString(reader["BatchNo"]);
                            medicine.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                            medicine.Quantity = Convert.ToInt32(reader["Quantity"]);
                            medicine.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                            medicine.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        }
                    }
                }
            }
            return medicine;
        }

        public int DeleteMedicine(int id)
        {
            int rowsDeleted = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Delete From Medicines Where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    rowsDeleted = cmd.ExecuteNonQuery();
                }
            }
            return rowsDeleted;
        }
    }
}
