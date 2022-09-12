using CarDealership.Data.Interfaces;
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
    public class InteriorsRepositoryADO : IInteriorsRepository
    {
        public List<Interiors> GetAll()
        {
            List<Interiors> interiors = new List<Interiors>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interiors currentRow = new Interiors();
                        currentRow.InteriorId = (int)dr["InteriorId"];
                        currentRow.InteriorName = dr["InteriorName"].ToString();

                        interiors.Add(currentRow);
                    }
                }
            }

            return interiors;
        }
    }
}
