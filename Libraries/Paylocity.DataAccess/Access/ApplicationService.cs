using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.Access
{
    public class ApplicationService : QueryAccess, IApplicationService
    {
        public Entity.response Get()
        {
            SQLParams = null;
            #region SqlParameter
            Command = "sprApplicationServices";
            #endregion
            return Grid<Entity.app_service>();
        }
        public Entity.response UpdateStatus(Entity.app_service param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id},
                new SqlParameter { ParameterName = "status", Value = param.status }
            };
            Command = "sprApplicationService_UpdateStatus";
            return new Entity.response { data = param, status = NonQuery() };
        }
        public Entity.response UpdateCompletion(Entity.app_service param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id, DbType = DbType.Int32 },
                new SqlParameter { ParameterName = "status", Value = param.status },
                new SqlParameter { ParameterName = "lastRun", Value = DateTime.Now, DbType = DbType.DateTime },
                new SqlParameter { ParameterName = "nextRun", Value = param.next_run, DbType = DbType.DateTime },
            };
            Command = "sprApplicationService_Update";
            return new Entity.response { data = param, status = NonQuery() };
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.app_service
            {
                id = Convert.ToInt32(row["PaylocityServiceId"]),
                name = row["PaylocityServiceName"].ToString(),
                status = row["PaylocityServiceStatus"]?.ToString() == "" ? null : Conversion.ToEnum<Enums.status>(row["PaylocityServiceStatus"]),
                last_run = row["PaylocityServiceLastRun"].ToString() == "" ? null : Convert.ToDateTime(row["PaylocityServiceLastRun"]),
                next_run = row["PaylocityServiceNextRun"].ToString() == "" ? null : Convert.ToDateTime(row["PaylocityServiceNextRun"]),
                active = Convert.ToBoolean(row["PaylocityServiceIsActive"])
            };
        }
    }
}
