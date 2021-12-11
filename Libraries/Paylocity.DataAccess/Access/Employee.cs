using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Paylocity.DataAccess.Access
{
    public class Employee : QueryAccess, IEmployee
    {
        public Entity.response GetById(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetEmployeeById";
            return Grid<Entity.employee>();
        }
        public Entity.response GetByCompany(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetEmployees";
            return Grid<Entity.employee>();
        }
        public void Add(ref Entity.employee param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "firstName", Value = param.name.first },
                new SqlParameter { ParameterName = "lastName", Value = param.name.last },
                new SqlParameter { ParameterName = "companyId", Value = param.company.id }
            };
            Command = "sprCompanyEmployeeAdd";
            var record = Row<Entity.employee>(Grid<Entity.employee>());
            if (record != null)
            {
                record.company = param.company;
                param = record;
            }
        }
        public Entity.status Update(Entity.employee param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id },
                new SqlParameter { ParameterName = "firstName", Value = param.name.first },
                new SqlParameter { ParameterName = "lastName", Value = param.name.last },
                new SqlParameter { ParameterName = "active", Value = param.active }
            };
            Command = "sprCompanyEmployeeUpdate";
            return NonQuery();
        }
        public Entity.status Delete(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprCompanyEmployeeDelete";
            return NonQuery();
        }
        public Entity.status AddContributionDeduction(Entity.log.contribution param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "employeeId", Value = param.pay_check.employee.id },
                new SqlParameter { ParameterName = "payCheck", Value = param.pay_check.amount },
                new SqlParameter { ParameterName = "payContribution", Value = param.amount },
            };
            Command = "sprEmployeeContributionDeductionAdd";
            return NonQuery();
        }
        public Entity.status DeleteContributionDeduction(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprCompanyEmployeeContributionDelete";
            return NonQuery();
        }
        
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.employee
            {
                id = Convert.ToInt32(row["EmployeeId"]),
                name = new Entity.name
                {
                    last = row["EmployeeLastName"].ToString(),
                    first = row["EmployeeFirstName"].ToString()
                },
                active = row["EmployeeIsActive"]?.ToString() == "" ? true : Convert.ToBoolean(row["EmployeeIsActive"].ToString()),
                date = row["EmployeeUpdatedDate"]?.ToString() == "" ? null : Convert.ToDateTime(row["EmployeeUpdatedDate"].ToString()),
            };
        }
    }
}
