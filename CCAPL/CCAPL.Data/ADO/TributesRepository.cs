using CCAPL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAPL.Data.ADO
{
    public class TributesRepository
    {
        public List<Tributes> GetAll()
        {
            List<Tributes> tributes = new List<Tributes>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TributesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tributes currentRow = new Tributes();
                        currentRow.TributeId = (int)dr["TributeId"];
                        currentRow.MemberId = (int)dr["MemberId"];
                        currentRow.TributeMessage = dr["TributeMessage"].ToString();
                        currentRow.DonationAmount = (decimal)dr["DonationAmount"];
                        currentRow.CreatedDate = (DateTime)dr["CreatedDate"];

                        tributes.Add(currentRow);
                    }
                }
            }
            return tributes;
        }

        public static object GetDetails(int id)
        {
            Tributes tribute = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TributesSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TributeId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        tribute = new Tributes();
                        tribute.MemberId = (int)dr["MemberId"];
                        tribute.TributeMessage = dr["TributeMessage"].ToString();
                        tribute.DonationAmount = (decimal)dr["DonationAmount"];
                        tribute.CreatedDate = (DateTime)dr["CreatedDate"];
                    }
                }
            }
            return tribute;
        }

        public Tributes GetById(int tributeId)
        {
            throw new NotImplementedException();
        }

        public void Create(Tributes tribute)
        {
            throw new NotImplementedException();
        }
    }
}
