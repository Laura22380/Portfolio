using EmailAppV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAppV2.Data
{
    public class EmailRepository
    {
        public void Create(EmailLog email)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("EmailLogInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@EmailId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@SenderEmail", email.SenderEmail);
                cmd.Parameters.AddWithValue("@Recipient", email.Recipient);
                cmd.Parameters.AddWithValue("@EmailSubject", email.EmailSubject);
                cmd.Parameters.AddWithValue("@Body", email.Body);
                cmd.Parameters.AddWithValue("@SendDate", email.SendDate);
                cmd.Parameters.AddWithValue("@SendStatus", email.SendStatus);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
