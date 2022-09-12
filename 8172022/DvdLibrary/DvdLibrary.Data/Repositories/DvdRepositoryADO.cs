using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data.Repositories.Interfaces;
using DvdLibrary.Data.Models;
using System.Data.SqlClient;
using System.Data;
using DvdLibrary.Models;

namespace DvdLibrary.Data.Repositories
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Add(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }


        public void Delete(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Edit(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdsId", dvd.DvdId);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return (IEnumerable<Dvd>)dvds;
        }

        public IEnumerable<Dvd> GetAllByDirector(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAllByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return (IEnumerable<Dvd>)dvds;
        }

        public IEnumerable<Dvd> GetAllByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAllByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return (IEnumerable<Dvd>)dvds;
        }

        public IEnumerable<Dvd> GetAllByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAllByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return (IEnumerable<Dvd>)dvds;
        }

        public IEnumerable<Dvd> GetAllByYear(string year)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAllByYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return (IEnumerable<Dvd>)dvds;
        }

        public Dvd GetById(int dvdId)
        {
            Dvd dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating= dr["Rating"].ToString();
                    }
                }
            }

            return dvd;
        }


        
    }


}
