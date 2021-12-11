using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using Paylocity.Logic.IStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.WebApp.Pages
{
    public class ContributionModel : PageModel
    {
        private readonly ILogger<ContributionModel> _logger;
        private IEmployee employee;
        private IPaylocityProvider paylocityProvider;
        private DataAccess.ILog.IBenefitContribution logBenefitContribution;
        private DataAccess.ILog.IEmployeePaidCheck logEmployeePaidCheck;

        public ContributionModel(ILogger<ContributionModel> logger, IPaylocityProvider _paylocityProvider, IEmployee _employee,
            DataAccess.ILog.IBenefitContribution _logBenefitContribution, DataAccess.ILog.IEmployeePaidCheck _logEmployeePaidCheck)
        {
            _logger = logger;
            employee = _employee;
            paylocityProvider = _paylocityProvider;
            logBenefitContribution = _logBenefitContribution;
            logEmployeePaidCheck = _logEmployeePaidCheck;
        }

        public void OnGet()
        {
        }
    }
}
