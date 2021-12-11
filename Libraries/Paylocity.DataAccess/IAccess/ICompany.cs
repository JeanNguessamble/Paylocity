using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.IAccess
{
    public interface ICompany
    {
        Entity.response Get();
        Entity.response Get(int id);
        void Add(ref Entity.company param);
        Entity.status Update(Entity.company param);
        Entity.status Delete(int id);
    }
}
