using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess.IAccess;

namespace Paylocity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> logger;
        private ICompany company;
        public CompanyController(ILogger<CompanyController> _logger, ICompany _company)
        {
            logger = _logger;
            company = _company;
        }

        [HttpGet]
        public string Get(int? id = null)
        {
            if (id.HasValue && id.Value > 0) return Conversion.TypeToJson(company.Get(id.Value));
            return Conversion.TypeToJson(company.Get());
        }

    }
}
