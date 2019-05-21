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
        private const string INSERT = "INSERT INTO PalleCheck values (@ProcessOrderNR)";
        private const string UPDATE = "UPDATE Activities " +
                                      "SET ActivityName = @ActivityName " +
                                      "WHERE ActivityID = @ActivityID ";
        private const string DELETE = "DELETE FROM Activities WHERE ActivityID = @ID ";

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
                        TimeOfTest = reader.GetDateTime(1),
                        Pallet = reader.GetString(2),
                        WorkerID = reader.GetInt32(3)
                    };
                }
                reader.Close();    
            }
            return pallet;
        }

        public bool Post(PalletCheck palletCheck)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ProcessOrderNR", palletCheck.ProcessOrderNR);
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }
    }
}