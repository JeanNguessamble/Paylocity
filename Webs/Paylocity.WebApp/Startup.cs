using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paylocity.Common;
using Paylocity.DataAccess;
using Paylocity.DataAccess.Access;
using Paylocity.DataAccess.IAccess;
using Paylocity.Logic.IStructure;
using Paylocity.Logic.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Config.Configuration = configuration;
            Config.AppToken = Guid.NewGuid().ToString();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region DataAccess
            services.AddTransient<ICompany, Company>();
            services.AddTransient<IBenefitDeduction, BenefitDeduction>();
            services.AddTransient<IDependent, Dependent>();
            services.AddTransient<IEmployee, Employee>();
            services.AddTransient<IEmployeePayCheck, EmployeePayCheck>();

            services.AddTransient<DataAccess.ILog.IBenefitContribution, DataAccess.Log.BenefitContribution>();
            services.AddTransient<DataAccess.ILog.IEmployeePaidCheck, DataAccess.Log.EmployeePaidCheck>();
            #endregion

            #region Structure
            services.AddTransient<IEmployeeContribution, EmployeeContribution>();
            services.AddTransient<IEmployeeDependent, EmployeeDependent>();
            services.AddTransient<IPaylocityPartner, PaylocityPartner>();
            services.AddTransient<IPaylocityProvider, PaylocityProvider>();
            #endregion

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
