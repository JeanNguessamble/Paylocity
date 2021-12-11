using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.IAccess
{
    public interface IDependent
    {
        Entity.response GetByCompany(int id);
        void Add(ref Entity.dependent param);
        Entity.status Update(Entity.dependent param);
        Entity.status Delete(int id);
        Entity.response GetByEmployee(int id);
        
    }
}
