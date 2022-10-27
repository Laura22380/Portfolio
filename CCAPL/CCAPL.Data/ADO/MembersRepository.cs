using CCAPL.Data.Interfaces;
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
    public class MembersRepository : IMembersRepository
    {
        public List<Members> GetAll()
        {
            List<Members> members = new List<Members>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MembersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Members currentRow = new Members();
                        currentRow.MemberId = (int)dr["MemberId"];
                        currentRow.MemberFirstName = dr["MemberFirstName"].ToString();
                        currentRow.MemberLastName = dr["MemberLastName"].ToString();
                        currentRow.MemberPhone = dr["MemberPhone"].ToString();
                        currentRow.MemberEmail = dr["MemberEmail"].ToString();

                        members.Add(currentRow);
                    }
                }
            }

            return members;
        }

        public Members GetById(int memberId)
        {
            Members member = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MembersSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MemberId", memberId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        member = new Members();
                        member.MemberId = (int)dr["MemberId"];
                        member.MemberFirstName = dr["MemberFirstName"].ToString();
                        member.MemberLastName = dr["MemberLastName"].ToString();
                        member.MemberPhone = dr["MemberPhone"].ToString();
                        member.MemberEmail = dr["MemberEmail"].ToString();

                    }
                }
            }
            return member;
        }

        public void Edit(Members member)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MembersUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                cmd.Parameters.AddWithValue("@FirstName", member.MemberFirstName);
                cmd.Parameters.AddWithValue("@LastName", member.MemberLastName);
                cmd.Parameters.AddWithValue("@Email", member.MemberEmail);
                cmd.Parameters.AddWithValue("@UserRole", member.MemberPhone);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

            public void Create(Members member)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MembersInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MemberId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@FirstName", member.MemberFirstName);
                cmd.Parameters.AddWithValue("@LastName", member.MemberLastName);
                cmd.Parameters.AddWithValue("@Email", member.MemberEmail);
                cmd.Parameters.AddWithValue("@UserRole", member.MemberPhone);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
