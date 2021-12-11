using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.IStructure
{
    public interface IPaylocityProvider
    {
        void ExecuteBenefitContribution();
        void ExecuteBenefitContribution(Entity.log.contribution param);
    }
}
