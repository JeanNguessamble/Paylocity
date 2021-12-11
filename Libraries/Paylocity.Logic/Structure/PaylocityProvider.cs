using Paylocity.Common;
using Paylocity.Logic.IStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.Structure
{
    public class PaylocityProvider : IPaylocityProvider
    {
        IEmployeeContribution employeeContribution;
        IEmployeeDependent employeeDependent;
        IPaylocityPartner paylocityPartner;

        int discountRate;
        string nameRate;
        public PaylocityProvider(IEmployeeContribution _employeeContribution, IEmployeeDependent _employeeDependent, IPaylocityPartner _paylocityPartner)
        {
            employeeContribution = _employeeContribution;
            employeeDependent = _employeeDependent;
            paylocityPartner = _paylocityPartner;
             discountRate = Convert.ToInt32(Config.Configuration["ConnectionStrings:BenefitDiscountPercent"]);
             nameRate = Config.Configuration["ConnectionStrings:BenefitDiscountNameBase"];
        }
        public void ExecuteBenefitContribution()
        {


            var dataCompanies = paylocityPartner.GetPartners();
            if (dataCompanies == null)
            {
                return;
            }
            var companies = dataCompanies.Where(w => w.active);
            foreach (var company in companies)
            {
                var dataBenefits = paylocityPartner.GetBenefitInfo(company.id);
                var dataPaidEmployees = employeeContribution.GetPayChecks(company.id);
                var dataEmployeeDependents = employeeDependent.GetByCompany(company.id);
                int payFreq = (int)company.pay_frequency;

                if (dataBenefits == null || dataPaidEmployees == null || dataEmployeeDependents == null) continue;

                var companyBenefits = dataBenefits.Where(w => w.company.active);
                var paidEmployees = dataPaidEmployees.Where(w => w.employee.active);
                var employeeDependents = dataEmployeeDependents.Where(w => w.employee.active);

                foreach (var companyBenefit in companyBenefits)
                {
                    foreach (var paidEmployee in paidEmployees)
                    {
                        var employee_reduction = paylocityPartner.NameBasedDiscount(companyBenefit.employee, discountRate, payFreq, nameRate, paidEmployee.employee.name);
                        var employeePaidDepents = employeeDependents.Where(w => w.employee.id == paidEmployee.id);

                        decimal dependent_reduction = 0;
                        foreach (var employeeDependent in employeePaidDepents)
                        {
                            dependent_reduction += paylocityPartner.NameBasedDiscount(companyBenefit.dependent, discountRate, payFreq, nameRate, employeeDependent.name);
                        }

                        employeeContribution.LogContribution(paidEmployee.id, paidEmployee.amount, employee_reduction + dependent_reduction);
                    }
                }
            }
        }
        public void ExecuteBenefitContribution(Entity.log.contribution param)
        {

            var employee_reduction = paylocityPartner.NameBasedDiscount(param.deduction.employee,  discountRate, (int)param.deduction.company.pay_frequency, nameRate, param.pay_check.employee.name);
            var employeePaidDepents = employeeDependent.GetByEmployee(param.pay_check.employee.id);

            decimal dependent_reduction = 0;
            foreach (var employeeDependent in employeePaidDepents)
            {
                dependent_reduction += paylocityPartner.NameBasedDiscount(param.deduction.dependent, discountRate, (int)param.deduction.company.pay_frequency, nameRate, employeeDependent.name);
            }

            employeeContribution.LogContribution(param.pay_check.employee.id, param.pay_check.amount, employee_reduction + dependent_reduction);
        }
    }

}