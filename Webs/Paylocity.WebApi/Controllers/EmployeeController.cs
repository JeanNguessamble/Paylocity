using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess.IAccess;

namespace Paylocity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private IDependent dependent;
        private IEmployee employee;
        private IEmployeePayCheck employeePayCheck;

        public EmployeeController(ILogger<EmployeeController> _logger
            , IEmployee _employee, IDependent _dependent, IEmployeePayCheck _employeePayCheck)
        {
            logger = _logger;
            employee = _employee;
            dependent = _dependent;
            employeePayCheck = _employeePayCheck;
        }
        [HttpGet]
        public string Get(int id)
        {
            return Conversion.TypeToJson(employee.GetById(id));
        }
        [HttpGet("Company")]
        public string GetByCompany(int id)
        {
            return Conversion.TypeToJson(employee.GetByCompany(id));
        }
        [HttpGet("Dependents")]
        public string GetDependentsByCompany(int id)
        {
            return Conversion.TypeToJson(dependent.GetByCompany(id));
        }
        [HttpGet("PayChecks")]
        public string GetPayChecksByCompany(int id)
        {
            return Conversion.TypeToJson(employeePayCheck.GetByCompany(id));
        }
        [HttpPost("LogContribution")]
        public void AddContributionDeduction([FromBody]string value)
        {
             employee.AddContributionDeduction(Conversion.JsonToType<Entity.log.contribution>(value));
        }
    }
}
