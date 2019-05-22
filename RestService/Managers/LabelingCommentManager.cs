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
        private const string GET_ONE = "SELECT * FROM LabelingComment WHERE ProcessOrderNr = @ProcessOrderNr";
        private const string GET_ALL = "SELECT * FROM LabelingComment";
        private const string INSERT = "INSERT INTO LabelingComment values (@WorkerID, @Comment) WHERE @ProcessOrderNr = ProcessOrderNr";
        private const string UPDATE = "UPDATE LabelingComment" +
                                      "SET WorkerID = @WorkerID" +
                                      "AND Comment = @Comment" +
                                      "WHERE ProcessOrderNr = @ProcessOrderNr";
        private const string DELETE = "DELETE FROM LabelingComment WHERE ProcessOrderNr = @ProcessOrderNr";

        //Look up labelingComment by ProcessOrdreNr
        public List<LabelingComment> Get()
        {
            List<LabelingComment> comments = new List<LabelingComment>();

            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {

                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    comments.Add(new LabelingComment()
                    {
                        ProcessOrderNR = reader.GetInt32(0),
                        WorkerID = reader.GetInt32(1),
                        Comment = reader.GetString(2).ToString()
                    });
                }
                //the IO stream of data, coming from database is closed
                reader.Close();
            }

            return comments;
        }

        public LabelingComment Get(int ProcessOrderNr)
        {
            //create empty labelingComment object
            LabelingComment a = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@ProcessOrderNr", ProcessOrderNr);

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

        public bool Post(LabelingComment labelingComment)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ProcessOrderNr", labelingComment.ProcessOrderNR);
            cmd.Parameters.AddWithValue("@WorkerID", labelingComment.WorkerID);
            cmd.Parameters.AddWithValue("@Comment", labelingComment.Comment);
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool Put(int id, LabelingComment labelingComment)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ProcessOrderNr", labelingComment.ProcessOrderNR);
            cmd.Parameters.AddWithValue("@WorkerID", labelingComment.WorkerID);
            cmd.Parameters.AddWithValue("@Comment", labelingComment.Comment);

            int noOfRows = cmd.ExecuteNonQuery();
            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ProcessOrderNr", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;

        }
    }
}