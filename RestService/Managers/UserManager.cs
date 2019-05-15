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
        //queries
        private const string GET_ONE = "SELECT * FROM users WHERE Uname = @Uname";

        //Look up user by Username.
        public User Get(string Uname)
        {
            //create empty user object
            User u = null;

            //query database 
            using(SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@Uname", Uname);

                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    u = new User()
                    {
                        UserName = reader.GetSqlString(0).ToString(),
                        Password = reader.GetSqlString(1).ToString(),
                        AccessLevel = reader.GetInt32(2),
                    };
                }
                //the IO stream of data, comming from database is closed
                reader.Close();
            }
            //Return the User from database, or "null" if no user what Username = Uname
            return u;
        }
    }
}