using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using Paylocity.Logic.IStructure;

namespace Paylocity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitDeductionController : ControllerBase
    {
        private readonly ILogger<BenefitDeductionController> logger;
        private IBenefitDeduction benefitDeduction;
        private IPaylocityProvider paylocityProvider;

        public BenefitDeductionController(ILogger<BenefitDeductionController> _logger, 
            IBenefitDeduction _benefitDeduction, IPaylocityProvider _paylocityProvider)
        {
            logger = _logger;
            benefitDeduction = _benefitDeduction;
            paylocityProvider = _paylocityProvider;
        }
        [HttpGet("Companies")]
        public string GetAll()
        {
            return Conversion.TypeToJson(benefitDeduction.GetAll());
        }
        [HttpGet("Company")]
        public string GetCompany(int id)
        {
            return Conversion.TypeToJson(benefitDeduction.GetByCompany(id));
        }

        [HttpPost("Add")]
        public void AddContributionDeduction(string value)
        {
            paylocityProvider.ExecuteBenefitContribution(Conversion.JsonToType<Entity.log.contribution>(value));
        }
        [HttpGet("Batch")]
        public void ContributionDeduction()
        {
            paylocityProvider.ExecuteBenefitContribution();
        }
    }
}
