using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Paylocity.Common;
using System.Linq;


namespace Paylocity.DataAccess
{
    public abstract class QueryAccess : NonQueryAccess
    {
        protected Entity.response Grid<T>()
        {
            if (Command == null || string.IsNullOrEmpty(Command))
            {
                return new Entity.response { status = new Entity.status { code = Enums.status.Error, detail = "SQL error command text is empty." } };
            }
            #region SqlConnection
            ConnectionString = Config.Configuration.GetConnectionString("DefaultConnectionString");
            if (string.IsNullOrEmpty(ConnectionString))
            {
                return new Entity.response { status = new Entity.status { code = Enums.status.Error, detail = "SQL error command text is empty." } };
            }

            var result = new List<T>();
            using (var sqlConnect = new SqlConnection(ConnectionString))
            {
                #region SqlCommand
                using (var sqlCommand = new SqlCommand(Command, sqlConnect))
                {
                    sqlCommand.Parameters.Clear();
                    try
                    {
                        //sqlConnect Open();
                        if (sqlConnect.State != ConnectionState.Open)
                        {
                            // I do the Async call here 
                            sqlConnect.OpenAsync().Wait();
                        }
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (SQLParams != null && SQLParams.Count > 0) sqlCommand.Parameters.AddRange(SQLParams.ToArray());
                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var record = DataMapping(reader);
                            if (record != null) result.Add(record);
                        }
                        response = new Entity.response { count = result.Count, data = result, status = new Entity.status { code = Enums.status.Success } };

                    }
                    catch (Exception ex)
                    {
                        response = new Entity.response { count = result.Count, data = result, status = new Entity.status { code = Enums.status.Error, detail = ex.ToString() } };
                    }
                }
                #endregion
            }
            #endregion
            return response;
        }


        #region Mapping
        #region Row
        protected T Row<T>(Entity.response response)
        {
            var row = default(T);
            var data = response.data as IEnumerable<T>;
            if (data != null) row = data.FirstOrDefault();
            return row;
        }
        #endregion
        protected abstract dynamic DataMapping(SqlDataReader reader);
        #endregion

    }
}
