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