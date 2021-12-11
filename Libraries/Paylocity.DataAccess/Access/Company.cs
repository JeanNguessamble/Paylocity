using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.Access
{
    public class Company : QueryAccess, ICompany
    {
        public Entity.response Get()
        {
            SQLParams = null;
            #region SqlParameter
            Command = "sprGetPaylocityCompanies";
            #endregion
            return Grid<Entity.company>();
        }
        public Entity.response Get(int id)
        {
            SQLParams = null;
            #region SqlParameter
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprGetPaylocityCompany";
            #endregion
            return Grid<Entity.company>();
        }
        public void Add(ref Entity.company param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "name", Value = param.name },
                new SqlParameter { ParameterName = "pay_frequency", Value = param.pay_frequency }
            };
            Command = "sprPaylocityCompanyAdd";
            param = Row<Entity.company>(Grid<Entity.company>());
        }
        public Entity.status Update(Entity.company param)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = param.id },
                new SqlParameter { ParameterName = "name", Value = param.name },
                new SqlParameter { ParameterName = "pay_frequency", Value = param.pay_frequency },
                new SqlParameter { ParameterName = "active", Value = param.active }
            };
            Command = "sprPaylocityCompanyUpdate";
            return NonQuery();
        }
        public Entity.status Delete(int id)
        {
            SQLParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "id", Value = id },
            };
            Command = "sprPaylocityCompanyDelete";
            return NonQuery();
        }
        protected override dynamic DataMapping(SqlDataReader row)
        {
            return new Entity.company
            {
                id = Convert.ToInt32(row["CompanyId"]),
                name = row["CompanyName"].ToString(),
                pay_frequency = Conversion.ToEnum<Enums.PayFrequency>(row["CompanyPayFreq"]),
                date = Convert.ToDateTime(row["CompanyCreatedDate"]),
                active = Convert.ToBoolean(row["CompanyIsActive"])
            };
        }

    }
}
