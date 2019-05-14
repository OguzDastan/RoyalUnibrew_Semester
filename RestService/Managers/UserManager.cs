using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Models;

namespace RestService.Managers
{
    public class UserManager
    {

        private const string GET_ONE = "SELECT * FROM users WHERE Uname = @Uname";

        public User Get(string Uname)
        {
            User u = new User();

            using(SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@Uname", Uname);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    u.UserName = reader.GetSqlString(0).ToString();
                    u.Password = reader.GetSqlString(1).ToString();
                    u.AccessLevel = reader.GetInt32(2);
                }
                reader.Close();
            }

            Debug.WriteLine($"searching for {Uname}");
            return u;
        }
    }
}