using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Paylocity.Common;
using Paylocity.DataAccess.IAccess;

namespace Paylocity.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ICompany company;
        private IBenefitDeduction deduction;

        public IndexModel(ILogger<IndexModel> logger, ICompany _company, IBenefitDeduction _deduction)
        {
            _logger = logger;
            company = _company;
            deduction = _deduction;
        }

        public void OnGet()
        {
            ViewData["Paylocity.Partners"] = company.Get();
            ViewData["Paylocity.Partners.Deductions"] = deduction.GetAll();
        }
        public void Contributions()
        {
            //TODO export pdf of the pay period
        }
    }
}
