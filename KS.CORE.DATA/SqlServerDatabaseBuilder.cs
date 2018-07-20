﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KS.CORE.DATA
{
    public class SqlServerDatabaseBuilder : IDatabaseBuilder
    {
        private Database _Database;

        public SqlServerDatabaseBuilder()
        {
            _Database = new SqlServerDatabase();
        }

        public void BuildConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
            _Database.Connection = new SqlConnection(connectionString);
        }

        public void BuildCommand(string sStoredProcedure)
        {
            _Database.Command = new SqlCommand(sStoredProcedure);
            _Database.Command.Connection = _Database.Connection;
        }

        public void SetSettings()
        {
            _Database.Command.CommandTimeout = 360;
            _Database.Command.CommandType = CommandType.StoredProcedure;
        }

        public void AddParameters(params object[] arrobjParameters)
        {
            _Database.Connection.Open();
            int intIndexParam = 0;
            SqlCommandBuilder.DeriveParameters((SqlCommand)_Database.Command);
            foreach (SqlParameter sqlParameter in _Database.Command.Parameters)
            {
                if (sqlParameter.Direction == ParameterDirection.Input)
                {
                    if (arrobjParameters[intIndexParam] != null && arrobjParameters[intIndexParam].GetType() == typeof(DataTable))
                    {
                        sqlParameter.TypeName = sqlParameter.TypeName.Split('.').Last();
                        sqlParameter.SqlDbType = SqlDbType.Structured;

                    }

                    sqlParameter.SqlValue = arrobjParameters[intIndexParam] ?? DBNull.Value;
                    intIndexParam += 1;
                }
                else if (sqlParameter.Direction == ParameterDirection.InputOutput)
                {
                    sqlParameter.Direction = ParameterDirection.Output;
                }


            }
        }

        public void GetDataReader()
        {
            _Database.DataReader = _Database.Command.ExecuteReader();
        }



        public Database Database
        {
            get { return _Database; }
        }
    }
}

