using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseJob.Interfaces;
using WareHouseJob.JobService;
using WareHouseJob.Repositories;

namespace WareHouseJob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(c => c
                          .UseSqlServerStorage(Configuration.GetConnectionString("WRHH"), new SqlServerStorageOptions
                          {
                              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                              QueuePollInterval = TimeSpan.Zero,
                              UseRecommendedIsolationLevel = true,
                              DisableGlobalLocks = true
                          }));


            services.AddHangfireServer();

            services.AddDbContext<WareHouseDBContext>(option =>
              option.UseSqlServer(Configuration.GetConnectionString("WRHH")));

           

            services.AddScoped<IReccuringJobService, ReccuringJobService>();

            services.AddScoped<IRequisitesAddingRepositorye, RequisitesAddingRepository>();

            services.AddMemoryCache();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider,
            WareHouseDBContext context
            )
        {

            app.UseHangfireDashboard();

            serviceProvider.GetService<IReccuringJobService>().EntryToJob();


            context.SaveChanges();
        
        }
    }
}
