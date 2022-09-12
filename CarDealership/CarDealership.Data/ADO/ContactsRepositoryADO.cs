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
    public class ContactsRepositoryADO : IContactsRepository
    {
        public void AddContact(Contacts contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                if (string.IsNullOrEmpty(contact.ContactEmail))
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", DBNull.Value); 
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", contact.ContactEmail);
                }
                if (string.IsNullOrEmpty(contact.ContactPhone))
                {
                    cmd.Parameters.AddWithValue("@ContactPhone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactPhone", contact.ContactPhone);
                }
                if (string.IsNullOrEmpty(contact.ContactMessage))
                {
                    cmd.Parameters.AddWithValue("@ContactMessage", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
