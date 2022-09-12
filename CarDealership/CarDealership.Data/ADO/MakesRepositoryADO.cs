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
    public class MakesRepositoryADO
    {
        public void Create(Makes make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);

                cmd.Parameters.AddWithValue("@UserId", make.UserId);

                //cmd.Parameters.AddWithValue("@UserEmail", make.UserEmail);
                cmd.Parameters.AddWithValue("@MakeDateAdded", DateTime.Today);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<Makes> GetAll()
        {
            List<Makes> makes = new List<Makes>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Makes currentRow = new Makes();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.MakeDateAdded = (DateTime)dr["MakeDateAdded"];
                        currentRow.UserEmail = dr["Email"].ToString();

                        makes.Add(currentRow);
                    }
                }
            }

            return makes;
        }
    }
}
