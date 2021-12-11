using Paylocity.Common;
using Paylocity.DataAccess.ILog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.Log
{
    public class EmployeePaidCheck : QueryAccess, IEmployeePaidCheck
    {
        public Entity.response GetByCompany(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetLogEmployeePaidCheckByCompany";
            return Grid<Entity.log.pay_check>();
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.log.pay_check
            {
                id = Convert.ToInt32(row["LogPaidChecksAmountId"]),
                employee = new Entity.employee
                {
                    id = Convert.ToInt32(row["EmployeeId"]),
                    name = new Entity.name
                    {
                        last = row["EmployeeFirstName"].ToString(),
                        first = row["EmployeeLastName"].ToString()
                    },
                    active = Convert.ToBoolean(row["EmployeeIsActive"]),
                    date = Convert.ToDateTime(row["EmployeeUpdatedDate"])
                },
                date = row["PaidCheckCreatedDate"]?.ToString() == "" ? null : Convert.ToDateTime(row["PaidCheckCreatedDate"]),
                amount = row["EmployeePaidCheckAmount"]?.ToString() == "" ? 0 : Convert.ToDecimal(row["EmployeePaidCheckAmount"])
            };
        }
    }
}
