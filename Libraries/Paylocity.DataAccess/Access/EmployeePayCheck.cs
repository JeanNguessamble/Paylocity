using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Paylocity.DataAccess.Access
{
    public class EmployeePayCheck : QueryAccess, IEmployeePayCheck
    {
        public void Add(ref Entity.pay_check param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "amount", Value = param.amount },
                new SqlParameter { ParameterName = "employeeId", Value = param.employee.id },
            };
            Command = "sprEmployeePayCheckAdd";
            var record = Row<Entity.pay_check>(Grid<Entity.pay_check>());
            if (record != null)
            {
                record.employee = param.employee;
                param = record;
            }
        }
        public Entity.status Update(Entity.pay_check param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id },
                new SqlParameter { ParameterName = "amount", Value = param.amount },
            };
            Command = "sprEmployeePayCheckUpdate";
            return NonQuery();
        }
        public Entity.status Delete(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprEmployeePayCheckDelete";
            return NonQuery();
        }
        public Entity.response GetByCompany(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetEmployeePayChecks";
            return Grid<Entity.pay_check>();
        }
        public Entity.response GetByEmployee(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetEmployeePayCheckByEmployee";
            return Grid<Entity.pay_check>();
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.pay_check
            {
                id = Convert.ToInt32(row["PaycheckId"]),
                amount = Convert.ToDecimal(row["EmployeePaycheckAmount"]),
                date = Convert.ToDateTime(row["PaycheckUpdatedDate"]),
                employee = new Entity.employee
                {
                    id = Convert.ToInt32(row["EmployeeId"]),
                    name = new Entity.name
                    {
                        last = row["EmployeeLastName"].ToString(),
                        first = row["EmployeeFirstName"].ToString()
                    },
                    active = Convert.ToBoolean(row["EmployeeIsActive"])
                }
            };
        }
    }
}
