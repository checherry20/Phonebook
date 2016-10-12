using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.Controllers
{
    /*class UserController : IUserController
    {
        public User GetUser(string username, string password)
        {
            return new User() { ID = 1,Username= "benjie",Password = "pogiako"};
        }
    }*/

    class UserControllerSQL : IUserController
    {
        public User GetUser(string username, string password)
        {
            String connStr = ConfigurationManager.ConnectionStrings["MSConnectionString"].ConnectionString;
            try
            {
                string sql = @"SELECT TOP 1 * FROM tbluser WHERE username = @username and password = @password";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var rs = cmd.ExecuteReader())
                        {
                            if (rs.HasRows)
                            {
                                rs.Read();
                                User user = new User();
                                user.ID = int.Parse(rs["userID"].ToString());
                                user.Username = rs["username"].ToString();
                                user.Firstname = rs["firstName"].ToString();
                                user.Lastname = rs["lastname"].ToString();
                                return user;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
