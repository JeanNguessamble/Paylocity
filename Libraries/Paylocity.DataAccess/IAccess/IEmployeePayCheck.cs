using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.IAccess
{
   public interface IEmployeePayCheck
    {
        Entity.response GetByCompany(int id);
        Entity.response GetByEmployee(int id);

        void Add(ref Entity.pay_check param);
        Entity.status Update(Entity.pay_check param);
        Entity.status Delete(int id);
    }
}
