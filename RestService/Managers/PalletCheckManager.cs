using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PalletCheck = Models.PalletCheck;

namespace RestService.Managers
{
    public class PalletCheckManager
    {
        //queries
        private const string GET_ONE = "SELECT * FROM PalleCheck WHERE ProcessOrderNR = @ProcessOrderNR AND TimeOfTest = @TimeOfTest";
        private const string GET_BY_PROCESSORDER = "SELECT * FROM PalleCheck WHERE ProcessOrderNR = @ProcessOrderNR";
        private const string GET_ALL = "SELECT * FROM PalleCheck";
        private const string INSERT = "INSERT INTO PalleCheck values (@ProcessOrderNR, @TimeOfTest, @Pallet, @WorkerID)";
        private const string UPDATE = "UPDATE PalleCheck " +
                                      "SET Pallet = @Pallet " +
                                      "TimeOfTest = @TimeOfTest " +
                                      "WokerID = @WorkerID " +
                                      "WHERE ProcessOrderNR = @ProcessOrderNR ";
        private const string DELETE_BY_PROCESSNR = "DELETE FROM PalleCheck WHERE ProcessOrderNR = @ID ";
        private const string DELETE_ONE = "SELECT FROM PalleCheck WHERE ProcessOrderNR = @ID AND TimeOfTest = @TimeOfTest";

        public PalletCheck Get(int ProcessOrderNR, TimeSpan TimeOfTest)
        {
            // creating an empty palletcheck object
            PalletCheck pallet = null;

            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", ProcessOrderNR);
                cmd.Parameters.AddWithValue("@TimeOfTest", TimeOfTest);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pallet = new PalletCheck()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        TimeOfTest = reader.GetTimeSpan(1),
                        Pallet = reader.GetString(2),
                        WorkerID = reader.GetInt32(3)
                    };
                }
                reader.Close();
            }
            return pallet;
        }
        public List<PalletCheck> Get(int ProcessOrderNR)
        {
            List<PalletCheck> entries = new List<PalletCheck>();

            using (SqlCommand cmd = new SqlCommand(GET_BY_PROCESSORDER, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", ProcessOrderNR);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entries.Add(new PalletCheck()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        TimeOfTest = reader.GetTimeSpan(1),
                        Pallet = reader.GetString(2),
                        WorkerID = reader.GetInt32(3)
                    });
                }
                reader.Close();
            }
            return entries;
        }
        public List<PalletCheck> Get()
        {
            List<PalletCheck> entries = new List<PalletCheck>();

            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entries.Add(new PalletCheck()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        TimeOfTest = reader.GetTimeSpan(1),
                        Pallet = reader.GetString(2),
                        WorkerID = reader.GetInt32(3)
                    });
                }
                reader.Close();
            }
            return entries;
        }
        public bool Post(PalletCheck palletCheck)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ProcessOrderNR", palletCheck.ProcessOrderNR);
            cmd.Parameters.AddWithValue("@TimeOfTest", palletCheck.TimeOfTest);
            cmd.Parameters.AddWithValue("@Pallet", palletCheck.Pallet);
            cmd.Parameters.AddWithValue("@WorkerID", palletCheck.WorkerID);
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }
        public bool Put(int id, PalletCheck palletCheck)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@Pallet ", palletCheck.Pallet);
            cmd.Parameters.AddWithValue("@TimeOfTest", palletCheck.TimeOfTest);
            cmd.Parameters.AddWithValue("@WorkerID", palletCheck.WorkerID);
            cmd.Parameters.AddWithValue("@ProcessOrderNR ", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE_BY_PROCESSNR, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID ", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        public bool Delete(int id, TimeSpan TimeOfTest)
        {
            SqlCommand cmd = new SqlCommand(DELETE_BY_PROCESSNR, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID ", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
    }
}