using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Common
{
  public  class Enums
    {
        internal static T Convert<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public enum status
        { 
            Processing,
            Ative,
            Completed,
            Error,
            Success
        }
        public enum relationship
        { 
            Wife,
            Daughter,
            Husband,
            Son
        }
        public enum PayFrequency
        { 
            Weekly = 52,
            Biweekly = 26
        }
        public enum sqlTable
        {
            CompanyBenefitDeductions,
            CompanyCheckNumbers,
            CompanyEmployeeDependents,
            CompanyEmployees,
            EmployeePaychecks,
            LogCompanyBenefitContributions,
            LogPaylocityServices,
            PaylocityApplicationServices,
            PaylocityCompanies
        }
    }
}
