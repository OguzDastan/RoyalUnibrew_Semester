using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;

namespace RestService.Managers
{
    public class LabelingCommentManager
    {
        //queries
        private const string GET_ONE = "SELECT * FROM LabelingComment WHERE ProcessOrdreNr = @ProcessOrdreNr";
        private const string INSERT = "INSERT INTO LabelingComment values (WorkerID, @Comment)";
        private const string UPDATE = "UPDATE LabelingComment" +
                                      "SET WorkerID = @WorkerID" +
                                      "AND Comment = @Comment" +
                                      "WHERE ProcessOrdreNr = @ProcessOrdreNr";
        private const string DELETE = "DELETE FROM LabelingComment WHERE ProcessOrdreNr = @ProcessOrdreNr";

        //Look up labelingComment by ProcessOrdreNr
        public LabelingComment Get(int ProcessOrdreNr)
        {
            //create empty labelingComment object
            LabelingComment a = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@ProcessOrdreNr", ProcessOrdreNr);

                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    a = new LabelingComment()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        WorkerID = reader.GetInt32(1),
                        Comment = reader.GetString(2).ToString()

                    };
                }
                //the IO stream of data, coming from database is closed
                reader.Close();
            }
            //Return the activity from database, or "null" if no user with LabelingComment = ProcessOrdreNr
            return a;
        }

        public bool Post(Activity activity)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ActivityName", activity.ActivityName);
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool Put(int id, Activity activity)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ActivityName", activity.ActivityName);
            cmd.Parameters.AddWithValue("@ActivityID", id);

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