using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.DataAccess.ILog
{
    public interface IBenefitContribution
    {
        Entity.response GetByCompany(int id);
    }
}
