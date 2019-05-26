using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;
using ProcessActivity = Models.ProcessActivity;


namespace RestService.Managers
{
    public class ProcessActivityManager
    {
        //queries
        private const string GET_ONE = "SELECT * FROM ProcessActivity WHERE ProcessOrderNR = @ProcessOrderNR";
        private const string GET_ALL = "SELECT * FROM ProcessActivity";
        private const string INSERT = "INSERT INTO ProcessActivity VALUES (@ActivityID, @ProcessOrderNR)";
        private const string DELETE = "DELETE FROM ProcessActivity WHERE ProcessOrderNR = @ID AND ActivityID = @ActivityID";

        public ProcessActivity Get(int ProcessOrderNR)
        {
            ProcessActivity processActivity = null;
        
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", ProcessOrderNR);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    processActivity = new ProcessActivity()
                    {
                        ActivityID = reader.GetInt32(0),
                        ProcessOrderNR = reader.GetInt32(1)
                    };
                }
                reader.Close();
            }

            return processActivity;

        }
        public List<ProcessActivity> Get()
        {
            List<ProcessActivity> processActivities = new List<ProcessActivity>();

            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    processActivities.Add(new ProcessActivity()
                    {
                        ActivityID = reader.GetInt32(0),
                        ProcessOrderNR = reader.GetInt32(1)
                    });
                }
            }
            return processActivities;
        }
        public bool Post(ProcessActivity processActivity)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ActivityID ", processActivity.ActivityID);
            cmd.Parameters.AddWithValue("@ProcessOrderNR ", processActivity.ProcessOrderNR);
            
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool Delete(int id, int ActivityID)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@ActivityID", ActivityID);

            int rowsAffected = cmd.ExecuteNonQuery();
            
            return rowsAffected > 0;
        }
    }
}