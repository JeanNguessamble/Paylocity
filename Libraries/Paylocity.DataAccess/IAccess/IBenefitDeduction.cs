using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.IAccess
{
    public interface IBenefitDeduction
    {
        Entity.response GetAll();
        Entity.response GetByCompany(int id);
        void Add(ref Entity.deduction param);
        Entity.status Update(Entity.deduction param);
        Entity.status Delete(int id);
    }
}
