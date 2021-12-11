using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paylocity.Common;
using Paylocity.DataAccess.Access;
using Paylocity.DataAccess.IAccess;
using Paylocity.Logic.IStructure;
using Paylocity.Logic.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.TestConsole
{
    public class AppProcess
    {
        DataAccess.ILog.IBenefitContribution logBenefitContribution;
        DataAccess.ILog.IEmployeePaidCheck logEmployeePaidCheck;

        ICompany company;
        IBenefitDeduction benefitDeduction;
        IDependent dependent;
        IEmployee employee;
        IEmployeePayCheck employeePayCheck;
        IEmployeeContribution employeeContribution;
        IEmployeeDependent employeeDependent;
        IPaylocityPartner paylocityPartner;
        IPaylocityProvider paylocityProvider;


        public AppProcess()
        {
            #region DataAccess
            company = new Company();
            benefitDeduction = new BenefitDeduction();
            dependent = new Dependent();
            employee = new Employee();
            employeePayCheck = new EmployeePayCheck();
            #endregion

            #region Structure
            paylocityPartner = new PaylocityPartner(company, benefitDeduction);
            employeeDependent = new EmployeeDependent(dependent);
            employeeContribution = new EmployeeContribution(employee, employeePayCheck);
            paylocityProvider = new PaylocityProvider(employeeContribution, employeeDependent, paylocityPartner);
            #endregion

            #region Log
            logBenefitContribution = new DataAccess.Log.BenefitContribution();
            logEmployeePaidCheck = new DataAccess.Log.EmployeePaidCheck();
            #endregion

        }
        public void Process()
        {
            paylocityProvider.ExecuteBenefitContribution();
            //Company();
            //Employee();
            //Dependent();
            //EmployeePayCheck();
            //ComapanyDeductions();
            //ContributionDeduction();
            
            //Delete();
        }

        public void Company()
        {
            Variables._Company = new Entity.company 
            {
                name = "Test Business Partner",
                pay_frequency = Enums.PayFrequency.Biweekly
            };
            company.Add(ref Variables._Company);

            Variables._Company.name = "Updated to New Test Business Name";
            company.Update(Variables._Company);
        }
        public void Employee()
        {
            Variables._Employee = new Entity.employee
            {
                company = Variables._Company,
                name = new Entity.name { first = "John", last = "Doe" }
            };
            employee.Add(ref Variables._Employee);

            Variables._Employee.name.first = "Jane";
            employee.Update(Variables._Employee);
        }
        public void Dependent()
        {
            Variables._Dependent = new Entity.dependent
            {
                employee = Variables._Employee,
                relationship = Enums.relationship.Son,
                name = new Entity.name { first = "Julian", last = "Doe" }
            };
            dependent.Add(ref Variables._Dependent);

            Variables._Dependent.relationship = Enums.relationship.Husband;
            dependent.Update(Variables._Dependent);
        }
        public void EmployeePayCheck()
        {
            Variables._PayCheck = new Entity.pay_check
            {
                employee = Variables._Employee,
                amount = 2500
            };
            employeePayCheck.Add(ref Variables._PayCheck);

            Variables._PayCheck.amount = 2300;
            employeePayCheck.Update(Variables._PayCheck);
        }
        public void ComapanyDeductions()
        {
            Variables._Deduction = new Entity.deduction
            {
                company = Variables._Company,
                employee = 1500,
                dependent = 1000
            };
            benefitDeduction.Add(ref Variables._Deduction);

            Variables._Deduction.dependent = 750;
            benefitDeduction.Update(Variables._Deduction);
        }
        public void ContributionDeduction()
        {
            Variables._LogContribution = new Entity.log.contribution
            {
                deduction = Variables._Deduction,
                pay_check = new Entity.log.pay_check { employee = Variables._Employee, amount = Variables._PayCheck.amount }
            };
            paylocityProvider.ExecuteBenefitContribution(Variables._LogContribution);
        }

        public void Delete()
        {
            employee.DeleteContributionDeduction(Variables._Employee.id);
            benefitDeduction.Delete(Variables._Deduction.id);
            employeePayCheck.Delete(Variables._PayCheck.id);
            if (Variables._Dependent.id.HasValue) dependent.Delete(Variables._Dependent.id.Value);
            employee.Delete(Variables._Employee.id);
            company.Delete(Variables._Company.id);
        }
    }
}
