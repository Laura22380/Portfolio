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
    public class SalesRepositoryADO
    {
        public IEnumerable<SalesReport> GetAll()
        {
            List<SalesReport> purchases = new List<SalesReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSelectReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport row = new SalesReport();

                        row.UserName = dr["UserName"].ToString();
                        row.TotalSales = (decimal)dr["TotalSales"];
                        row.TotalVehicles = (int)dr["TotalVehicles"];

                        purchases.Add(row);
                    }
                }
            }
            return (IEnumerable<SalesReport>)purchases;
        }

        public IEnumerable<SalesReport> Search(SalesSearchParameters parameters)
        {
            List<SalesReport> purchases = new List<SalesReport>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT CONCAT(u.FirstName, ' ', u.LastName) UserName, ISNULL(SUM(PurchasePrice),0) TotalSales, Count(VIN) TotalVehicles FROM Users u LEFT JOIN VehicleSales vs ON u.UserId = vs.UserId WHERE 1=1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.FromDate != null && parameters.ToDate != null)
                {
                    query += " AND (SaleDate Is NULL OR (SaleDate >= @fromDate  AND SaleDate <= @toDate)) ";
                    cmd.Parameters.AddWithValue("@toDate", parameters.ToDate);
                    cmd.Parameters.AddWithValue("@fromDate", parameters.FromDate);
                }

                if (parameters.FromDate == null && parameters.ToDate != null)
                {
                    query += " AND (SaleDate ISNULL OR SaleDate <= @toDate) ";
                    cmd.Parameters.AddWithValue("@toDate", parameters.ToDate);
                }

                if (parameters.FromDate != null && parameters.ToDate == null)
                {
                    query += " AND (SaleDate Is NULL OR SaleDate >= @fromDate) ";
                    cmd.Parameters.AddWithValue("@fromDate", parameters.FromDate);
                }

                if (!string.IsNullOrEmpty(parameters.UserName))
                {
                    query += " AND CONCAT(u.FirstName, ' ', u.LastName) LIKE @UserName ";
                    cmd.Parameters.AddWithValue("@UserName", '%' + parameters.UserName + '%');
                }

                query += " GROUP BY u.FirstName, u.LastName ORDER BY TotalSales DESC ";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport row = new SalesReport();

                        row.UserName = dr["UserName"].ToString();
                        row.TotalSales = (decimal)dr["TotalSales"];
                        row.TotalVehicles = (int)dr["TotalVehicles"];

                        purchases.Add(row);
                    }
                }
            }
            return purchases;
        }

        public void Create(VehicleSales sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSalesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SaleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VIN", sale.VIN);
                cmd.Parameters.AddWithValue("@UserId", sale.UserId);
                cmd.Parameters.AddWithValue("@BuyerId", sale.BuyerId);
                cmd.Parameters.AddWithValue("@PurchasePrice", sale.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseType", sale.PurchaseType);
                cmd.Parameters.AddWithValue("@SaleDate", DateTime.Today);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
