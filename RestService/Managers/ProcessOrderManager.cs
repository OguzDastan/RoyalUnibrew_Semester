using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;

namespace RestService.Managers
{
    public class ProcessOrderManager
    {
        //queries
        private const string GET_ALL = "SELECT * FROM ProcessOrder";
        private const string GET_ONE = "SELECT * FROM ProcessOrder WHERE ProcessOrderNR = @id";
        private const string GET_BY_DATE = "SELECT * FROM ProcessOrder WHERE ProcessDate = @date";
        private const string GET_BY_DATE_SPAN = "SELECT * FROM ProcessOrder WHERE ProcessDate < @dateHigher AND ProcessDate > @DateLower";
        private const string INSERT = "INSERT INTO ProcessOrder values (@ProcessOrderNR, @ColumnNR, @EndProductNR, @EndProductName, @ProcessDate, @Process)";
        private const string UPDATE = "UPDATE ProcessOrder SET "
            + "ColumnNR = @ColumNR "
            + "EndProductNR = @EndProductNr "
            + "EndProductName = @EndProductName "
            + "ProcessDate = @ProcessDate "
            + "Process = @Process"
            + "WHERE ProcessOrderNR = @ProcessOrderNr ";

        private const string DELETE = "DELETE FROM ProcessOrder WHERE ProcessOrderNR = @ProcessOrderNR";

        public bool Put(ProcessOrdre po)
        {
            using (SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", po.ProcessOrderNR);
                cmd.Parameters.AddWithValue("@ColumnNR", po.ColumnNR);
                cmd.Parameters.AddWithValue("@EndProductNR", po.EndproductNR);
                cmd.Parameters.AddWithValue("@EndProductName", po.EndProductName);
                cmd.Parameters.AddWithValue("@ProcessDate", po.ProcessDate);
                cmd.Parameters.AddWithValue("@Process", po.Process);

                int numRowsAffected = cmd.ExecuteNonQuery();

                return numRowsAffected == 1;
            }
        }

        public bool Delete(int ProcessOrderNR)
        {
            using (SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@ProcessOrderNR", ProcessOrderNR);

                int RowsAffected = cmd.ExecuteNonQuery();

                return RowsAffected == 1;
            }
        }

        public bool Post(ProcessOrdre po)
        {

            using (SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@Process", po.Process);
                cmd.Parameters.AddWithValue("@ProcessOrderNR", po.ProcessOrderNR);
                cmd.Parameters.AddWithValue("@ColumnNR", po.ColumnNR);
                cmd.Parameters.AddWithValue("@EndProductNR", po.EndproductNR);
                cmd.Parameters.AddWithValue("@EndProductName", po.EndProductName);
                cmd.Parameters.AddWithValue("@ProcessDate", po.ProcessDate);

                int RowsAffected = cmd.ExecuteNonQuery();

                return RowsAffected == 1;
            }
        }

        public ProcessOrdre Get(int id)
        {
            ProcessOrdre po = null;
            
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    po = new ProcessOrdre()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        ColumnNR = reader.GetInt32(1),
                        EndproductNR = reader.GetInt32(2),
                        EndProductName = reader.GetString(3).ToString(),
                        ProcessDate = reader.GetDateTime(4)
                    };
                }
                reader.Close();
            }
            return po;
        }

        public List<ProcessOrdre> Get()
        {
            List<ProcessOrdre> Orders = new List<ProcessOrdre>();

            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProcessOrdre Order = new ProcessOrdre()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        ColumnNR = reader.GetInt32(1),
                        EndproductNR = reader.GetInt32(2),
                        EndProductName = reader.GetString(3).ToString(),
                        ProcessDate = reader.GetDateTime(4)
                    };
                    Orders.Add(Order);
                }
                reader.Close();
            }
            return Orders;
        }
    }
}