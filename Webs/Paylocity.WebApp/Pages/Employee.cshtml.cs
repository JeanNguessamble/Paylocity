using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.WebApp.Pages
{
    public class EmployeeModel : PageModel
    {
        private readonly ILogger<EmployeeModel> _logger;
        private IDependent dependent;
        private IEmployee employee;
        private IEmployeePayCheck employeePayCheck;
        private ICompany company;

        public EmployeeModel(ILogger<EmployeeModel> logger, ICompany _company
            , IEmployee _employee, IDependent _dependent, IEmployeePayCheck _employeePayCheck)
        {
            _logger = logger;
            employee = _employee;
            company = _company;
            dependent = _dependent;
            employeePayCheck = _employeePayCheck;
        }

        public void OnGet(int? id = null)
        {
            if (id > 0)
            {
                ViewData["Paylocity.Partner"] = company.Get(id.Value);
                ViewData["Paylocity.CompanyEmployees"] = employee.GetByCompany(id.Value);
                ViewData["Paylocity.CompanyEmployees.Dependents"] = dependent.GetByCompany(id.Value);
                ViewData["Paylocity.CompanyEmployees.PayChecks"] = employeePayCheck.GetByCompany(id.Value);
            }
            else
            { 
                ViewData["Paylocity.Partners"] = company.Get();
            }
        }

        public void Dependents(int id)
        {
            if (id > 0) ViewData["Paylocity.CompanyEmployees.Dependents"] = dependent.GetByCompany(id);
        }
        public void PayChecks(int id)
        {
            if (id > 0) ViewData["Paylocity.CompanyEmployees.PayChecks"] = employeePayCheck.GetByCompany(id);
        }
        public void LogContribution([FromBody] string value)
        {
            employee.AddContributionDeduction(Conversion.JsonToType<Entity.log.contribution>(value));
        }
        [HttpPost]
        public void OnAdd([FromForm] string value)
        {
            var request = Conversion.JsonToType<Entity.pay_check>(value);
            employee.Add(ref request.employee);
            employeePayCheck.Add(ref request);
        }
    }
}
