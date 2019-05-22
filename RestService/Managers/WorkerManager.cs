using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;

namespace RestService.Managers
{
    public class WorkerManager
    {
        private const string GET_ALL = "SELECT * FROM Worker";
        private const string GET_ONE = "SELECT * FROM Worker WHERE WorkerID = @WorkerID";
        private const string INSERT = "INSERT INTO Worker values (@WorkerSign)";
        private const string UPDATE = "UPDATE Worker " +
                                      "SET WorkerSign = @WorkerSign " +
                                      "WHERE WorkerID = @WorkerID ";
        private const string DELETE = "DELETE FROM Worker WHERE WorkerID = @WorkerID ";

        public List<Worker> Get()
        {
            List<Worker> w = new List<Worker>();
            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {
                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    w.Add( new Worker()
                    {
                        WorkerID = reader.GetInt32(0),
                        WorkerSign = reader.GetString(1).ToString()
                    });
                }
                //the IO stream of data, coming from database is closed
                reader.Close();
            }
            //Return the activity from database, or "null" if no user what Activity = ActivityID
            return w;
        }
        public Worker Get(int WorkerID)
        {
            //create empty activity object
            Worker a = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@WorkerID", WorkerID);

                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    a = new Worker()
                    {
                        WorkerID = reader.GetInt32(0),
                        WorkerSign = reader.GetString(1).ToString()
                    };
                }
                //the IO stream of data, coming from database is closed
                reader.Close();
            }
            //Return the activity from database, or "null" if no user what Activity = ActivityID
            return a;
        }

        public bool Post(Worker w)
        {
            using (SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@WorkerSign", w.WorkerSign);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool Put(int id, Worker w)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@WorkerSign", w.WorkerSign);
            cmd.Parameters.AddWithValue("@WorkerID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@WorkerID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;

        }


    }
}