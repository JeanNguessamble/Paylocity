using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.IAccess
{
    public interface IEmployee
    {
        Entity.response GetByCompany(int id);
        Entity.response GetById(int id);
        void Add(ref Entity.employee param);
        Entity.status Update(Entity.employee param);
        Entity.status Delete(int id);
        Entity.status AddContributionDeduction(Entity.log.contribution param);
        Entity.status DeleteContributionDeduction(int id);


    }
}
