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
    public class InvoiceGateway
    {

        string conString = ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString;




        public int CreateInvoice(InvoiceMaster invoiceMaster, List<InvoiceDetails> invDetailsList)
        {
            int rowsSaved = 0;
            int invMasterId = 0;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {

                    string query = @"Insert into InvoiceMaster (InvNo, Date, CName, CContact, SubTotal, Discount, GrandTotal) 
                                    values (@InvNo, @Date, @CName, @CContact, @SubTotal, @Discount, @GrandTotal);
                                     Select SCOPE_IDENTITY();";


                    using (SqlCommand cmd = new SqlCommand(query, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@InvNo", invoiceMaster.InvNo);
                        cmd.Parameters.AddWithValue("@Date", invoiceMaster.Date);
                        cmd.Parameters.AddWithValue("@CName", invoiceMaster.CName);
                        cmd.Parameters.AddWithValue("@CContact", invoiceMaster.CContact);
                        cmd.Parameters.AddWithValue("@SubTotal", invoiceMaster.SubTotal);
                        cmd.Parameters.AddWithValue("@Discount", invoiceMaster.Discount);
                        cmd.Parameters.AddWithValue("@GrandTotal", invoiceMaster.GrandTotal);

                        invMasterId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string detailsQuery = @"Insert into InvoiceDetails(InvoiceMasterId, MedicineId, MedName, Quantity, UnitPrice, BatchNo, ExpiryDate)
                                   values (@InvoiceMasterId, @MedicineId, @MedName, @Quantity, @UnitPrice, @BatchNo, @ExpiryDate)";

                    string medQtyUpdateQuery = @"Update Medicines set Quantity = Quantity-@Qty Where Id = @MedId and Quantity >=@Qty;";

                    foreach (var medDetails in invDetailsList)
                    {
                        using (SqlCommand cmd = new SqlCommand(medQtyUpdateQuery, con, tran))
                        {
                            cmd.Parameters.AddWithValue("@Qty", medDetails.Quantity);
                            cmd.Parameters.AddWithValue("@MedId", medDetails.MedicineId);

                            rowsSaved += cmd.ExecuteNonQuery();
                        }


                        using (SqlCommand detailsCmd = new SqlCommand(detailsQuery, con, tran))
                        {
                            detailsCmd.Parameters.AddWithValue("@InvoiceMasterId", invMasterId);
                            detailsCmd.Parameters.AddWithValue("@MedicineId", medDetails.MedicineId);
                            detailsCmd.Parameters.AddWithValue("@MedName", medDetails.MedName);
                            detailsCmd.Parameters.AddWithValue("@Quantity", medDetails.Quantity);
                            detailsCmd.Parameters.AddWithValue("@UnitPrice", medDetails.UnitPrice);
                            detailsCmd.Parameters.AddWithValue("@BatchNo", medDetails.BatchNo);
                            detailsCmd.Parameters.AddWithValue("@ExpiryDate", medDetails.ExpiryDate);

                            rowsSaved += detailsCmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }

            //return rowsSaved;
            return invMasterId;
        }

        public InvoiceMaster GetInvoiceMasterById(int id)
        {
            InvoiceMaster inv = null;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Select * From InvoiceMaster Where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inv = new InvoiceMaster();
                            inv.Id = Convert.ToInt32(reader["Id"]);
                            inv.InvNo = Convert.ToString(reader["InvNo"]);
                            inv.Date = Convert.ToDateTime(reader["Date"]);
                            inv.CName = Convert.ToString(reader["CName"]);
                            inv.CContact = Convert.ToString(reader["CContact"]);
                            inv.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                            inv.Discount = Convert.ToDecimal(reader["Discount"]);
                            inv.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);

                        }
                    }
                }
            }
            return inv;
        }

        public List<InvoiceDetails> GetInvoiceDetailsByMasterId(int masterId)
        {
            var invDetailsList = new List<InvoiceDetails>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"Select * From InvoiceDetails Where InvoiceMasterId = @invMasterId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@invMasterId", masterId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var invDetails = new InvoiceDetails();
                            invDetails.MedName = Convert.ToString(reader["MedName"]);
                            invDetails.Quantity = Convert.ToInt32(reader["Quantity"]);
                            invDetails.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                            invDetails.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                            invDetails.BatchNo = Convert.ToString(reader["BatchNo"]);

                            invDetailsList.Add(invDetails);
                        }
                    }
                }
            }
            return invDetailsList;
        }
    }
}
