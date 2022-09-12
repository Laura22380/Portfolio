using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class ModelsRepositoryADO
    {
        public void Create(CarDealership.Models.Tables.Models model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@ModelDateAdded", model.ModelDateAdded);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public List<CarDealership.Models.Tables.Models> GetAll()
        {
            List<Models.Tables.Models> models = new List<Models.Tables.Models>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Models.Tables.Models currentRow = new Models.Tables.Models();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelDateAdded = (DateTime)dr["ModelDateAdded"];
                        currentRow.UserEmail = dr["Email"].ToString();

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }
    }
}
