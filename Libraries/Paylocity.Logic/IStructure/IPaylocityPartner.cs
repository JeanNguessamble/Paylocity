using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.IStructure
{
   public interface IPaylocityPartner
    {
        List<Entity.company> GetPartners();
        List<Entity.deduction> GetBenefitInfo(int id);
        decimal NameBasedDiscount(decimal deduction, int rate, int pay_frequency, string letterName, Entity.name name);
    }
}
