using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseDB.Entities;
using WareHouseJob.Interfaces;
using WareHouseJob.JobConfigurationFile;

namespace WareHouseJob.Repositories
{
    public class ReccuringJobService : IReccuringJobService
    {
        private readonly WareHouseDBContext context;
        private readonly IRequisitesAddingRepositorye service;
        private readonly IConfiguration Configuration;

        public ReccuringJobService(WareHouseDBContext context, IRequisitesAddingRepositorye service, IConfiguration Configuration)
        {
            this.context = context;
            this.service = service;
            this.Configuration = Configuration;
        }

        public void EntryToJob()
        {
            MaxJobCount maxJobobCount = new MaxJobCount(Configuration);


            if (context.AmountCount.FirstOrDefault(x => x.CurrentDate.Date == DateTime.Today && x.CountDailyAmount < maxJobobCount.MaxJobCountPerDay()) != null)
            {

                service.AddingRequisites();


                //BackgroundJob.Schedule(() => service.addingRequisites(), TimeSpan.FromSeconds(30));

                //RecurringJob.AddOrUpdate("Run every minute",
                //                () => service.AddingRequisites(),
                //"* 1 * * *");
            }
            else if (context.AmountCount.FirstOrDefault(x => x.CurrentDate.Date != DateTime.Now.Date && x.CountDailyAmount < maxJobobCount.MaxJobCountPerDay()) != null)
            {

                context.AmountCount.Add(new DateTimeForJobsAmountCounter()
                {
                    CurrentDate = Convert.ToDateTime(DateTime.Now.Date),
                    CountDailyAmount = 1
                });

                service.AddingRequisites();

                //  BackgroundJob.Schedule(() => service.addingRequisites(), TimeSpan.FromSeconds(30));

                //  RecurringJob.AddOrUpdate("Run every minute",
                //  () => service.AddingRequisites(),

                //"* * * * * *"
                // );
            }

        }

    }
}

