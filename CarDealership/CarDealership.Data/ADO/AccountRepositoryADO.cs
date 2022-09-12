using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
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
    public class AccountRepositoryADO : IAccountRepository
    {
        public void AddMake(Makes make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                //cmd.Parameters.AddWithValue("@MakeId", make.MakeId);
                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@MakeDateAdded", make.MakeDateAdded);
                cmd.Parameters.AddWithValue("@UserId", make.UserId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public void AddModel(CarDealership.Models.Tables.Models model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                //cmd.Parameters.AddWithValue("@MakeId", make.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@ModelDateAdded", model.ModelDateAdded);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public void AddUser(Users user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                //cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void EditUser(Users user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<SalesItem> GetSalesReport()
        {
            List<SalesItem> sales = new List<SalesItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSelectReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesItem row = new SalesItem();

                        row.VIN = dr["VIN"].ToString();
                        row.UserId = (int)dr["UserId"];
                        row.FirstName = dr["FirstName"].ToString();
                        row.LastName = dr["LastName"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];

                        sales.Add(row);
                    }
                }
            }

            return (IEnumerable<SalesItem>)sales;
    }

        public IEnumerable<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Users row = new Users();

                        row.UserId = (int)dr["UserId"];
                        row.FirstName = dr["FirstName"].ToString();
                        row.LastName = dr["LastName"].ToString();
                        row.Email = dr["Email"].ToString();
                        row.Role = dr["UserRole"].ToString();


                        users.Add(row);
                    }
                }
            }

            return users;
        }

        public IEnumerable<VehicleItem> GetVehiclesInventory()
        {
            List<VehicleFeaturedItem> vehicles = new List<VehicleFeaturedItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectInventory", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleFeaturedItem row = new VehicleFeaturedItem();

                        //row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["VehicleYear"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];

                        vehicles.Add(row);
                    }
                }
            }

            return (IEnumerable<VehicleItem>)vehicles;
        }

        public void RemoveUser(int userId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
