using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using Paylocity.DataAccess.ILog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Paylocity.DataAccess.Log
{
    public class BenefitContribution : QueryAccess, IBenefitContribution
    {
        public Entity.response GetByCompany(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetLogBenefitContributionsByCompany";
            return Grid<Entity.log.contribution>();
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.log.contribution
            {
                id = Convert.ToInt32(row["LogCompanyBenefitContributionId"]),
                pay_check = new Entity.log.pay_check
                {
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
                    }
                },
                date = row["CompanyBenefitContributionDate"]?.ToString() == "" ? null : Convert.ToDateTime(row["CompanyBenefitContributionDate"]),
                amount = row["EmployeeBenefitContribution"]?.ToString() == "" ? 0 : Convert.ToDecimal(row["EmployeeBenefitContribution"])
            };
        }
    }
}
