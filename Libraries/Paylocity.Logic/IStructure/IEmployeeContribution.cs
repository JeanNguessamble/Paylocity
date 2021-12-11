using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.IStructure
{
   public interface IEmployeeContribution
    {
        List<Entity.pay_check> GetPayChecks(int id);
        void LogContribution(int employe_id, decimal gross_pay, decimal contribution);
    }
}
