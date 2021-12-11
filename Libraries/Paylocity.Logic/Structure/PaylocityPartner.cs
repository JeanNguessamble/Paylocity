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
   public class PaylocityPartner: IPaylocityPartner
    {
        ICompany company;
        IBenefitDeduction benefitDeduction;
        public PaylocityPartner(ICompany _company, IBenefitDeduction _benefitDeduction)
        {
            company = _company;
            benefitDeduction = _benefitDeduction;
        }
        public List<Entity.company> GetPartners()
        {
            var response = company.Get();
            return response == null || response.count == 0 ? null : (List<Entity.company>)response.data;
        }
        public List<Entity.deduction> GetBenefitInfo(int id)
        {
            var response = benefitDeduction.GetByCompany(id);
            return response == null || response.count == 0 ? null : (List<Entity.deduction>)response.data;
        }
        public decimal NameBasedDiscount(decimal deduction, int rate, int pay_frequency, string letterName, Entity.name name)
        {
            decimal _deduction = deduction;
            if (rate == 0 || string.IsNullOrEmpty(letterName)) return _deduction;

            if (name.first.StartsWith(letterName) || name.last.StartsWith(letterName))
            {
                _deduction = deduction * Convert.ToDecimal((100.0 - rate) / 100.0);// applying reduction
            }
            return _deduction / pay_frequency;
        }
    }
}
