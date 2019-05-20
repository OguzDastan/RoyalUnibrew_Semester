using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;

namespace RestService.Managers
{
    public class LabelingManager
    {
        private const string GET_ONE = "SELECT * FROM Labeling " +
                                       "WHERE processOrdreNr = @processOrdreNr" +
                                       "AND timeOfTest = @timeOfTest";
        public Labeling Get(int processOrdreNr, DateTime timeOfTest)
        {
            //create empty user object
            Labeling l = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@processOrdreNr", processOrdreNr);
                cmd.Parameters.AddWithValue("@timeOfTest", timeOfTest);


                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    l = new Labeling()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        CheckTime = reader.GetDateTime(1),
                        LableNR = reader.GetInt32(2),
                        ExpireDate = reader.GetDateTime(3),
                        //SignForTest = reader.GetString(4)
                    };
                }
                //the IO stream of data, comming from database is closed
                reader.Close();
            }
            //Return the User from database, or "null" if no user what Username = Uname
            return l;
        }
    }
}