using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using Paylocity.Logic.IStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.Structure
{
   public class EmployeeContribution: IEmployeeContribution
    {
        IEmployee employee;
        IEmployeePayCheck employeePayCheck;

        public EmployeeContribution(IEmployee _employee, IEmployeePayCheck _employeePayCheck)
        {
            employee = _employee;
            employeePayCheck = _employeePayCheck;
        }
        /// <summary>
        /// List of all paid employees based on the company
        /// </summary>
        /// <param name="company id"></param>
        /// <returns></returns>
        public List<Entity.pay_check> GetPayChecks(int id)
        {
            var response = employeePayCheck.GetByCompany(id);
            return response == null || response.count == 0 ? null : (List<Entity.pay_check>)response.data;
        }

        public void LogContribution(int employe_id, decimal gross_pay, decimal contribution)
        {
            employee.AddContributionDeduction(new Entity.log.contribution
            {
                amount = Math.Round(contribution, 2),
                pay_check = new Entity.log.pay_check
                {
                    amount = Math.Round(gross_pay - contribution, 2),
                    employee = new Entity.employee { id = employe_id }
                }
            });
        }

    }
}
