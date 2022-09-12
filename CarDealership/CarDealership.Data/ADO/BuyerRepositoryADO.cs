using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class BuyerRepositoryADO
    {
        public void Create(Buyers buyer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BuyersInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@BuyerId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@BuyerName", buyer.BuyerName);
                cmd.Parameters.AddWithValue("@Street1", buyer.BuyerStreet1);
                if (buyer.BuyerPhone == null)
                {
                    cmd.Parameters.AddWithValue("@BuyerPhone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BuyerPhone", buyer.BuyerPhone);
                }

                if (buyer.BuyerEmail == null)
                {
                    cmd.Parameters.AddWithValue("@BuyerEmail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BuyerEmail", buyer.BuyerEmail);
                }

                if (buyer.BuyerStreet2 == null)
                {
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", buyer.BuyerStreet2);
                }

                cmd.Parameters.AddWithValue("@BuyerCity", buyer.BuyerCity);
                cmd.Parameters.AddWithValue("@StateId", buyer.StateId);
                cmd.Parameters.AddWithValue("@BuyerZipcode", buyer.BuyerZipCode);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public Buyers GetByName(string Name)
        {
            Buyers buyer = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BuyersSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BuyerName", Name);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        buyer = new Buyers();
                        buyer.BuyerName = dr["BuyerName"].ToString();
                        buyer.BuyerId = (int)dr["BuyerId"];
                        buyer.BuyerStreet1 = dr["Street1"].ToString();
                        buyer.BuyerStreet2 = dr["Street2"].ToString();
                        buyer.StateId = dr["StateId"].ToString();
                        buyer.BuyerZipCode = (int)dr["BuyerZipcode"];

                        if (dr["BuyerEmail"] != DBNull.Value)
                        {
                            buyer.BuyerEmail = dr["BuyerEmail"].ToString();
                        }

                        if (dr["BuyerPhone"] != DBNull.Value)
                        {
                            buyer.BuyerPhone = dr["BuyerPhone"].ToString();
                        }
                    }
                }
            }
            return buyer;
        }
    }
}
