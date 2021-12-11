using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Paylocity.DataAccess.Access
{
    public class Dependent : QueryAccess, IDependent
    {
        public Entity.response GetByCompany(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetEmployeeDependents";
            return Grid<Entity.dependent>();
        }
        public Entity.response GetByEmployee(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetEmployeeDependentsByEmployee";
            return Grid<Entity.dependent>();
        }
        public void Add(ref Entity.dependent param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "firstName", Value = param.name.first },
                new SqlParameter { ParameterName = "lastName", Value = param.name.last },
                new SqlParameter { ParameterName = "employeeId", Value = param.employee.id },
                new SqlParameter { ParameterName = "relationship", Value = param.relationship.ToString() },
            };
            Command = "sprCompanyEmployeeDependentAdd";
            var record = Row<Entity.dependent>(Grid<Entity.dependent>());
            if (record != null)
            {
                record.employee = param.employee;
                param = record;
            }
        }
        public Entity.status Update(Entity.dependent param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id },
                new SqlParameter { ParameterName = "firstName", Value = param.name.first },
                new SqlParameter { ParameterName = "lastName", Value = param.name.last },
                new SqlParameter { ParameterName = "relationship", Value = param.relationship.ToString() },
            };
            Command = "sprCompanyEmployeeDependentUpdate";
            return NonQuery();
        }
        public Entity.status Delete(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprCompanyEmployeeDependentDelete";
            return NonQuery();
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.dependent
            {
                id = row["EmployeeDependentId"].ToString() == "" ? null : Convert.ToInt32(row["EmployeeDependentId"]),
                relationship = row["DependentRelationship"]?.ToString() == "" ? null : Conversion.ToEnum<Enums.relationship>(row["DependentRelationship"]),
                name = new Entity.name
                {
                    last = row["DependentLastName"].ToString(),
                    first = row["DependentFirstName"].ToString()
                },
                employee = new Entity.employee
                {
                    id = Convert.ToInt32(row["EmployeeId"]),
                    name = new Entity.name
                    {
                        last = row["EmployeeLastName"].ToString(),
                        first = row["EmployeeFirstName"].ToString()
                    },
                    active = Convert.ToBoolean(row["EmployeeIsActive"]),

                }
            };
        }
    }
}
