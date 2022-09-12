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
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public void Create(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.Year);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicle.TransmissionId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.InteriorId);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);

                if (string.IsNullOrEmpty(vehicle.ImageFileName))
                {

                    cmd.Parameters.AddWithValue("@ImageFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                }

                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsPurchased", 0);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Delete(string VIN)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VIN", VIN);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<VehicleItem> GetAll()
        {
            List<VehicleItem> vehicles = new List<VehicleItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleItem row = new VehicleItem();

                        row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["VehicleYear"];
                        row.MakeId = (int)dr["MakeId"];
                        row.Make = dr["MakeName"].ToString();
                        row.ModelId = (int)dr["ModelId"];
                        row.Model = dr["ModelName"].ToString();
                        row.BodyStyleId = (int)dr["BodyStyleId"]; 
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.ColorId = (int)dr["ColorId"];
                        row.ColorName = dr["ColorName"].ToString();
                        row.TransmissionId = (int)dr["TransmissionId"];
                        row.TransmissionName = dr["TransmissionName"].ToString();
                        row.InteriorId = (int)dr["InteriorId"];
                        row.InteriorName = dr["InteriorName"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();

                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();

                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.IsPurchased = (bool)dr["IsPurchased"];

                        vehicles.Add(row);
                    }
                }
            }
            return (IEnumerable<VehicleItem>)vehicles;
        }

        public IEnumerable<VehicleShortItem> GetAllNew()
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["VehicleYear"];
                        row.MakeId = (int)dr["MakeId"];
                        row.Make = dr["MakeName"].ToString();
                        row.ModelId = (int)dr["ModelId"];
                        row.Model = dr["ModelName"].ToString();
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.ColorId = (int)dr["ColorId"];
                        row.ColorName = dr["ColorName"].ToString();
                        row.TransmissionId = (int)dr["TransmissionId"];
                        row.TransmissionName = dr["TransmissionName"].ToString();
                        row.InteriorId = (int)dr["InteriorId"];
                        row.InteriorName = dr["InteriorName"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();

                        row.IsPurchased = (bool)dr["IsPurchased"];

                        vehicles.Add(row);
                    }
                }
            }
            return (IEnumerable<VehicleShortItem>)vehicles;
        }

        public IEnumerable<VehicleShortItem> GetAllUsed()
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["VehicleYear"];
                        row.MakeId = (int)dr["MakeId"];
                        row.Make = dr["MakeName"].ToString();
                        row.ModelId = (int)dr["ModelId"];
                        row.Model = dr["ModelName"].ToString();
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.ColorId = (int)dr["ColorId"];
                        row.ColorName = dr["ColorName"].ToString();
                        row.TransmissionId = (int)dr["TransmissionId"];
                        row.TransmissionName = dr["TransmissionName"].ToString();
                        row.InteriorId = (int)dr["InteriorId"];
                        row.InteriorName = dr["InteriorName"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();

                        row.IsPurchased = (bool)dr["IsPurchased"];

                        vehicles.Add(row);
                    }
                }
            }
            return (IEnumerable<VehicleShortItem>)vehicles;
        }
        public IEnumerable<Inventory> GetAllInventory()
        {
            List<Inventory> vehicles = new List<Inventory>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectInventory", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Inventory row = new Inventory();

                        row.Year = (int)dr["VehicleYear"];
                        row.Make = dr["MakeName"].ToString();
                        row.Model = dr["ModelName"].ToString();
                        row.VehicleCount = (int)dr["VehicleCount"];
                        row.StockValue = (decimal)dr["StockValue"];

                        vehicles.Add(row);
                    }
                }
            }
            return (IEnumerable<Inventory>)vehicles;
        }

        public Vehicles GetById(string VIN)
        {
            Vehicles vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VIN", VIN);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicles();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Year = (int)dr["VehicleYear"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.ColorId = (int)dr["ColorId"];
                        vehicle.TransmissionId = (int)dr["TransmissionId"];
                        vehicle.InteriorId = (int)dr["InteriorId"];
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        
                        if(dr["ImageFileName"] != DBNull.Value)
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }
            }
            return vehicle;
        }

        public VehicleItem GetDetails(string VIN)
        {
            VehicleItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VIN", VIN);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleItem();
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Year = (int)dr["VehicleYear"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.Make = dr["MakeName"].ToString();
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.Model = dr["ModelName"].ToString();
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();
                        vehicle.ColorId = (int)dr["ColorId"];
                        vehicle.ColorName = dr["ColorName"].ToString();
                        vehicle.TransmissionId = (int)dr["TransmissionId"];
                        vehicle.TransmissionName = dr["TransmissionName"].ToString();
                        vehicle.InteriorId = (int)dr["InteriorId"];
                        vehicle.InteriorName = dr["InteriorName"].ToString();
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            vehicle.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<VehicleFeaturedItem> GetFeatured()
        {
            List<VehicleFeaturedItem> vehicles = new List<VehicleFeaturedItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleFeaturedItem row = new VehicleFeaturedItem();

                        row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["VehicleYear"];
                        row.Make = dr["MakeName"].ToString();
                        row.Model = dr["ModelName"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];


                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<VehicleShortItem> Search(VehicleSearchParameters parameters)
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VIN, VehicleYear, v.MakeId, MakeName, v.ModelId, ModelName, v.BodyStyleId, BodyStyleName, v.TransmissionId, TransmissionName, v.ColorId, ColorName, v.InteriorId, InteriorName, Mileage, SalePrice, MSRP, ImageFileName FROM Vehicles v  INNER JOIN BodyStyles b on v.BodyStyleId = b.BodyStyleId INNER JOIN Colors c on v.ColorId = c.ColorId INNER JOIN Transmissions t ON v.TransmissionId = t.TransmissionId INNER JOIN Interiors i ON v.InteriorId = i.InteriorId INNER JOIN Makes m ON v.MakeId = m.MakeId INNER JOIN Models mo ON v.ModelId = mo.ModelId WHERE 1=1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += " AND SalePrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += " AND SalePrice <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    query += " AND VehicleYear >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += " AND VehicleYear <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MakeModelYear))
                {
                    query += " AND( MakeName LIKE @MakeModelYear ";
                    cmd.Parameters.AddWithValue("@MakeModelYear", '%' + parameters.MakeModelYear + '%');

                    query += " OR ModelName LIKE @MakeModelYear ";

                    query += " OR VehicleYear LIKE @MakeModelYear )";
                }

                query += " ORDER BY MSRP DESC ";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();

                        row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["VehicleYear"];
                        row.MakeId = (int)dr["MakeId"];
                        row.Make = dr["MakeName"].ToString();
                        row.ModelId = (int)dr["ModelId"];
                        row.Model = dr["ModelName"].ToString();
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.ColorId = (int)dr["ColorId"];
                        row.ColorName = dr["ColorName"].ToString();
                        row.TransmissionId = (int)dr["TransmissionId"];
                        row.TransmissionName = dr["TransmissionName"].ToString();
                        row.InteriorId = (int)dr["InteriorId"];
                        row.InteriorName = dr["InteriorName"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();

                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public void Update(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.Year);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicle.TransmissionId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.InteriorId);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);

                if (string.IsNullOrEmpty(vehicle.ImageFileName))
                {

                    cmd.Parameters.AddWithValue("@ImageFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                }

                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsPurchased", vehicle.IsPurchased);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

    }
}
