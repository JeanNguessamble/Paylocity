using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Paylocity.Common;

namespace Paylocity.DataAccess
{
    public class NonQueryAccess
    {
        protected string Command;
        protected string ConnectionString;
        protected Entity.response response;
        protected List<SqlParameter> SQLParams;
        public NonQueryAccess()
        {
            response = new Entity.response();
        }
        protected Entity.status NonQuery()
        {
            var status = new Entity.status { };
            #region SqlConnection
            ConnectionString = Config.Configuration.GetConnectionString("DefaultConnectionString");
            if (string.IsNullOrEmpty(ConnectionString))
            {
                return new Entity.status { code = Enums.status.Error, detail = "SQL error command text is empty." };
            }

            using (var sqlConnect = new SqlConnection(ConnectionString))
            {
                #region SqlCommand
                using (var sqlCommand = new SqlCommand(Command, sqlConnect))
                {
                    sqlCommand.Parameters.Clear();
                    try
                    {
                        if (sqlConnect.State != ConnectionState.Open)
                        {
                            // I do the Async call here 
                            sqlConnect.OpenAsync().Wait();
                        }
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (SQLParams != null && SQLParams.Count > 0) sqlCommand.Parameters.AddRange(SQLParams.ToArray());
                        status = new Entity.status { code = Enums.status.Success, detail = sqlCommand.ExecuteNonQuery().ToString() };


                        Command = String.Empty;
                    }
                    catch (Exception ex) { status = new Entity.status { code = Enums.status.Error, detail = ex.StackTrace }; }
                    finally { sqlConnect.Close(); }
                }
                #endregion
            }
            #endregion
            return status;
        }
    }
}
