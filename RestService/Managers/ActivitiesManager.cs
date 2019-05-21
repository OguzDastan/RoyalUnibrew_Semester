using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Activity = Models.Activity;

namespace RestService.Managers
{
    public class ActivitiesManager
    {
        //queries
        private const string GET_ONE = "SELECT * FROM Activities WHERE ActivityID = @ActivityID";
        private const string INSERT = "INSERT INTO Activities values (@ActivityName)";
        private const string UPDATE = "UPDATE Activities " + 
                                      "SET ActivityName = @ActivityName " +
                                      "WHERE ActivityID = @ActivityID ";
        private const string DELETE = "DELETE FROM Activities WHERE ActivityID = @ID ";

        //Look up activity by ActivityID
        public Activity Get(int ActivityID)
        {
            //create empty activity object
            Activity a = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@ActivityID", ActivityID);

                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    a = new Activity()
                    {
                        ActivityID = reader.GetInt32(0),
                        ActivityName = reader.GetString(1).ToString()                                         
                    };
                }
                //the IO stream of data, coming from database is closed
                reader.Close();
            }
            //Return the activity from database, or "null" if no user what Activity = ActivityID
            return a;
        }

        public bool Post(Activity activity)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue(" @ActivityName", activity.ActivityName);
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool Put(int id, Activity activity)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ActivityName ", activity.ActivityName);
            cmd.Parameters.AddWithValue("@ActivityID ", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;

        }

    }

}
