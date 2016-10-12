using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{
    /// <summary>
    /// USING LIST AS DB. IN MEMORY ONLY
    /// </summary>
    /*class ContactController : IContactController
    {
        List<Contact> db = new List<Contact>();

        public ContactController()
        {
            Contact newContact = new Contact();
            newContact.Id = 1;
            newContact.Name = "Benjie";
            newContact.Number =1430000;

            Contact newContact2 = new Contact();
            newContact2.Id = 2;
            newContact2.Name = "Jerlyn";
            newContact2.Number = 1234567;

            this.Add(newContact);
            this.Add(newContact2);
        }

        public void Add(Contact contact)
        {
            try
            {
                //VALIDATION HERE

                //SANITIZE DATA HERE

                //SAVE DB.
                db.Add(contact);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Int32 id)
        {
            try
            {
                db.Remove(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Edit(Contact contact)
        {
            try
            {
                Contact record = db.Where(c => c.Id == contact.Id).SingleOrDefault();

                if(record != null)
                {
                    //update data
                    record.Name = contact.Name;
                    record.Number = contact.Number;
                }

                throw new Exception("contact does not exist");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Contact Get(Int32 id)
        {
            try
            {
                return db.Where(contact => contact.Id == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Contact> GetAll()
        {
            try
            {
                return db;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }*/

    //WILL USE SQL SERVER , UGMA
    class ContactControllerSQLDB : IContactController
    {
        String connStr = ConfigurationManager.ConnectionStrings["MSConnectionString"].ConnectionString;
        public void Add(Contact contact)
        {
            try
            {
                string sql = @"INSERT INTO contacts(name, number) Values(@name, @number)";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name",contact.Name);
                        cmd.Parameters.AddWithValue("@number", contact.Number);
                        cmd.ExecuteNonQuery();
                    }                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Contact contact)
        {
            try
            {
                string sql = @"DELETE FROM contacts WHERE id = @id";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", contact.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Edit(Contact contact)
        {
            try
            {
                string sql = @"UPDATE contacts SET name = @name, number = @number WHERE id = @id";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", contact.Name);
                        cmd.Parameters.AddWithValue("@number", contact.Number);
                        cmd.Parameters.AddWithValue("@id", contact.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Contact Get(int id)
        {
            try
            {
                string sql = @"SELECT TOP 1 * FROM contacts WHERE id=@id";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        
                        using (var rs = cmd.ExecuteReader())
                        {
                            if (rs.HasRows)
                            {
                                rs.Read();
                                Contact contact = new Contact();
                                contact.Id = Int32.Parse(rs["id"].ToString());
                                contact.Name = rs["name"].ToString();
                                contact.Number = Int32.Parse(rs["number"].ToString());
                                return contact;
                            }
                            return null;                            
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Contact> GetAll()
        {
            try
            {
                List<Contact> contactList = new List<Contact>();
                string sql = @"SELECT * FROM contacts";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {

                        using (var rs = cmd.ExecuteReader())
                        {
                            if (rs.HasRows)
                            {
                                while (rs.Read())
                                {
                                    Contact contact = new Contact();
                                    contact.Id = Int32.Parse(rs["id"].ToString());
                                    contact.Name = rs["name"].ToString();
                                    contact.Number = Int32.Parse(rs["number"].ToString());
                                    contactList.Add(contact);
                                }
                            }
                        }
                    }
                }
                return contactList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}
