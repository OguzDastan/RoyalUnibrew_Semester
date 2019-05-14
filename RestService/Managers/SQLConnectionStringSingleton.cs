using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestService.Managers
{
    public class SQLConnectionSingleton
    {
        private static SQLConnectionSingleton _instance = new SQLConnectionSingleton();

        public static SQLConnectionSingleton Instance => _instance;

        private SQLConnectionSingleton()
        {
            _dbConnection = new SqlConnection(ConnString);
            _dbConnection.Open();
        }

        private SqlConnection _dbConnection;
        private const String ConnString = @"Data Source=oldbserver.database.windows.net;Initial Catalog=UnibrewDB;User ID=oldbadmin;Password=SECRET123pass;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";          
        public SqlConnection DbConnection => _dbConnection;
    }
}