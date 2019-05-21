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
                                       "WHERE processOrderNR = @processOrdreNr " +
                                       "AND timeOfTest = @timeOfTest";
        private const string GET_BY_ProcessOrderNR = "SELECT * FROM Labeling "
                                                       + "WHERE processOrderNR = @processOrdreNr";
        private const string GET_ALL = "SELECT * FROM Labeling";
        private const string UPDATE = "UPDATE Labeling "
            + "SET LabelNR = @LabelNR "
            + "ExpireyDate = @ExpireyDate "
            + "WorkerToSign = @WorkerToSign "
            + "WHERE ProcessOrderNR = @ProcessOrderNR "
            + "AND TimeOfTest = @TimeOfTest";
        private const string INSERT = "INSERT INTO Labeling VALUES "
            + "(@ProcessOrderNR, @TimeOfTest, @LabelNR, @ExpireyDate, @WorkerToSign)";
        private const string DELETE_BY_PONUMBER = "DELETE FROM Labeling WHERE ProcessOrderNR = @ProcessOrderNR";
        private const string DELETE_ENTRY = "DELETE FROM Labeling WHERE ProcessOrderNR = @ProcessOrderNR AND TimeOfTest = @TimeOfTest";

        public bool Delete(int ProcessOrderNR, TimeSpan TimeOfTest)
        {
            using (SqlCommand cmd = new SqlCommand(DELETE_BY_PONUMBER, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", ProcessOrderNR);
                cmd.Parameters.AddWithValue("@TimeOfTest", TimeOfTest);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
        public bool Delete(int ProcessOrderNR)
        {
            using (SqlCommand cmd = new SqlCommand(DELETE_BY_PONUMBER, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", ProcessOrderNR);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        public bool Post(Labeling l)
        {
            using (SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@TimeOfTest", l.TimeOfTest);
                cmd.Parameters.AddWithValue("@LabelNR", l.LableNR);
                cmd.Parameters.AddWithValue("@ExpireyDate", l.ExpireyDate);
                cmd.Parameters.AddWithValue("@WorkerToSign", l.WorkerToSign);
                cmd.Parameters.AddWithValue("@ProcessOrderNR", l.ProcessOrderNR);

                int noRowsAffected = cmd.ExecuteNonQuery();

                return noRowsAffected == 1;
            }
        }
        public bool Put(int processOrderNr, Labeling l)
        {
            using(SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@TimeOfTest", l.TimeOfTest);
                cmd.Parameters.AddWithValue("@LabelNR", l.LableNR);
                cmd.Parameters.AddWithValue("@ExpireyDate", l.ExpireyDate);
                cmd.Parameters.AddWithValue("@WorkerToSign", l.WorkerToSign);
                cmd.Parameters.AddWithValue("@ProcessOrderNR", l.ProcessOrderNR);

                int noRowsAffected = cmd.ExecuteNonQuery();

                return noRowsAffected == 1;
            }
        }
        public List<Labeling> Get()
        {
            List<Labeling> entries = new List<Labeling>();

            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entries.Add(new Labeling()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        TimeOfTest = reader.GetTimeSpan(1),
                        LableNR = reader.GetInt32(2),
                        ExpireyDate = reader.GetDateTime(3),
                        WorkerToSign = reader.GetInt32(4)
                    });
                }
                reader.Close();
            }
            return entries;
        }
        public List<Labeling> Get(int ProcessOrderNR)
        {
            List<Labeling> entries = new List<Labeling>();

            using (SqlCommand cmd = new SqlCommand(GET_BY_ProcessOrderNR, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@processOrdreNr", ProcessOrderNR);
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    Labeling entry = new Labeling()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        TimeOfTest = reader.GetTimeSpan(1),
                        LableNR = reader.GetInt32(2),
                        ExpireyDate = reader.GetDateTime(3),
                        WorkerToSign = reader.GetInt32(4)
                    };
                    entries.Add(entry);
                }
                //the IO stream of data, comming from database is closed
                reader.Close();
            }

            return entries;
        }
        public Labeling Get(int processOrderNR, TimeSpan timeOfTest)
        {
            //create empty user object
            Labeling l = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@processOrdreNr", processOrderNR);
                cmd.Parameters.AddWithValue("@timeOfTest", timeOfTest);
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    l = new Labeling(){
                        ProcessOrderNR = reader.GetInt32(0),
                        TimeOfTest = reader.GetTimeSpan(1),
                        LableNR = reader.GetInt32(2),
                        ExpireyDate = reader.GetDateTime(3),
                        WorkerToSign = reader.GetInt32(4)
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