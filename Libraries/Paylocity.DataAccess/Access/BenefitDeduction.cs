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
    public class BenefitDeduction : QueryAccess, IBenefitDeduction
    {
        public Entity.response GetAll()
        {
            Command = "sprGetAllCompanyBenefits";
            return Grid<Entity.deduction>();
        }
        public Entity.response GetByCompany(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprCompaniesBenefitGetSetup";
            return Grid<Entity.deduction>();
        }
        public void Add(ref Entity.deduction param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "companyId", Value = param.company.id },
                new SqlParameter { ParameterName = "employeeContribution", Value = param.employee },
                new SqlParameter { ParameterName = "dependentContribution", Value = param.dependent }
            };
            Command = "sprCompaniesBenefitAdd";
            var record = Row<Entity.deduction>(Grid<Entity.deduction>());
            if (record != null)
            {
                record.company = param.company;
                param = record;
            }
        }
        public Entity.status Update(Entity.deduction param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id },
                new SqlParameter { ParameterName = "employeeContribution", Value = param.employee },
                new SqlParameter { ParameterName = "dependentContribution", Value = param.dependent }
            };
            Command = "sprCompaniesBenefitUpdate";
            return NonQuery();
        }
        public Entity.status Delete(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprCompaniesBenefitDelete";
            return NonQuery();
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.deduction
            {
                id = Convert.ToInt32(row["BenefitContributionId"]),
                company = new Entity.company
                {
                    id = Convert.ToInt32(row["CompanyId"]),
                    name = row["CompanyName"].ToString(),
                    pay_frequency = Conversion.ToEnum<Enums.PayFrequency>(row["CompanyPayFreq"]),
                    date = row["CompanyCreatedDate"]?.ToString() == "" ? null : Convert.ToDateTime(row["CompanyCreatedDate"]),
                    active = Convert.ToBoolean(row["CompanyIsActive"])
                },
                employee = row["EmployeeContributionAmount"]?.ToString() == "" ? 0 : Convert.ToDecimal(row["EmployeeContributionAmount"]),
                dependent = row["DependentContributionAmount"]?.ToString() == "" ? 0 : Convert.ToDecimal(row["DependentContributionAmount"])
            };
        }
    }
}
