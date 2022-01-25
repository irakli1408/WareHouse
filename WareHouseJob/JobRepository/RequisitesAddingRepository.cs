using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using WareHouseDb.Entities;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseJob.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WareHouseJob.JobConfigurationFile;

namespace WareHouseJob.JobService
{
  
    public class RequisitesAddingRepository : IRequisitesAddingRepositorye
    {
        private readonly ILogger<RequisitesAddingRepository> _logger;

        private readonly IConfiguration _Configuration;

        private readonly WareHouseDBContext _context;
        public RequisitesAddingRepository(WareHouseDBContext context, ILogger<RequisitesAddingRepository> logger, IConfiguration Configuration)
        {
            _context = context;
            _logger = logger;
            _Configuration = Configuration;
        }
        public void AddingRequisites()
        {
            RequisiteStatus requisiteStatus = new RequisiteStatus(_Configuration);

            requisiteStatus.Fail = _Configuration.GetValue<int>("RequisiteStatusEnum:Fail");

            requisiteStatus.Success = _Configuration.GetValue<int>("RequisiteStatusEnum:Success");



            var product = _context.Products.Include(x => x.Requisites)
                .Where(x => x.Requisites.StatusId != requisiteStatus.Success
                && x.Requisites.Count < 3 || x.Requisites.Count == null);

            
            foreach (var item in product)
            {
                try
                {
                    var returnedData = GetDataFromOuterEndPoint(item);

                    if (returnedData != null)
                    {
                        _context.Requisites.Add(returnedData);
                        item.Requisites.StatusId = requisiteStatus.Success;
                        continue;
                    }
                    else
                    {
                        global.CountForTesting++;
                        ItemFailCounter(item);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    ItemFailCounter(item);
                    _logger.LogError(ex.Message);
                }
            }        
        }


        private void ItemFailCounter(Product product)
        {

            RequisiteStatus requisiteStatus = new RequisiteStatus(_Configuration);

            requisiteStatus.Fail = _Configuration.GetValue<int>("RequisiteStatusEnum:Fail");

            if (product.Requisites == null)
            {
                _context.Requisites.Add(new Requisite
                {
                    Count = 1,
                    ProductId = product.Id,
                    StatusId = requisiteStatus.Fail,
                    DateCreated = DateTime.Now
                });

                global.CountForTesting++;
            }
            else
            {
                product.Requisites.Count++; 
                global.CountForTesting++;
            }
        }

        private Requisite GetDataFromOuterEndPoint(Product product)
        {
            MaxJobCount maxJobCount = new MaxJobCount(_Configuration);
          
            _context.AmountCount.FirstOrDefault(x => x.CurrentDate.Date == DateTime.Now.Date && x.CountDailyAmount < maxJobCount.MaxJobCountPerDay()).CountDailyAmount++;
                  
            if (global.CountForTesting == 0)
                {
                    var returnedData = new Requisite()
                    {
                        ProductId = product.Id,
                        Brand = "armani",
                        Number = "Gucci",
                        VehicleDescription = "Smucci",
                        VehicleType = "Rolandooo",
                        Description = "Shmessii",
                        DateCreated = new DateTime()
                    };
                    global.CountForTesting++;
                    return returnedData;
                }
                else if (global.CountForTesting == 1)
                {
                    return null;
                }
                else
                {
                    Exception ex = new Exception();
                    throw ex;
                }
          
        }
    }
}

