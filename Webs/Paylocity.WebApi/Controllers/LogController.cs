using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess.ILog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> logger;
        private IBenefitContribution benefitContribution;
        private IEmployeePaidCheck employeePaidCheck;

        public LogController(ILogger<LogController> _logger, IBenefitContribution _benefitContribution,
            IEmployeePaidCheck _employeePaidCheck)
        {
            logger = _logger;
            benefitContribution = _benefitContribution;
            employeePaidCheck = _employeePaidCheck;
        }
    }
}
