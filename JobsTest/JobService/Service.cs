using Hangfire;
using JobsTest;
using JobsTest.JobService;
using JobsTest.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.JobService
{
    public class Service
    {
        //private readonly JobProductRepository context;
        //public Service(JobProductRepository context) => this.context = context;

        public void method()
        {
            using (var context = new WareHouseDataBaseEntities())
            {
                var requisites = from p in context.Products
                                 join r in context.Requisites
                                 on p.Id equals r.ProductId into req
                                 from r in req.DefaultIfEmpty()
                                 where r.StatusId != (int)RequisiteStatusEnum.Success
                                // where r.Count < 3
                                 select p;

                

                var res = requisites.ToList();

                foreach (var item in requisites)
                {

                    item.Requisites.Description;

                    // context.DateTimeForJobsAmountCounter.CountDailyAmount++
                    try
                    {
                       // Console.WriteLine(item.ProductCode);
                        var returnedData = GetDataFromOuterEndPoint(item.ProductCode);

                        if (returnedData != null)
                        {

                            context.Requisites.Add(returnedData);
                            //item.StatusId = (int)RequisiteStatusEnum.Success;
                        }
                        else
                        {
                             global.CountForTesting++;
                             //itemFailCounter(context, );                                                
                        }
                    }
                    catch (Exception ex)
                    {
                        //itemFailCounter(context, item);
                    }
                }
                //return context;
                context.SaveChanges();
            }
        }

        private void itemFailCounter(WareHouseDataBaseEntities context, Requisite item)
        {
            if (item.Count == 0)
            {
                context.Requisites.Add(new Requisite
                {                    
                    Count = 1,
                    ProductId = item.Product.Id,
                    StatusId = (int)RequisiteStatusEnum.fail,
                    DateCreated = DateTime.Now                    
                });
            }
            else
            {
                //item.Count++;
                global.CountForTesting++;
            }
        }

        private Requisite GetDataFromOuterEndPoint(string code)
        {


            if (global.CountForTesting == 0)
            {
                var returnedData = new Requisite()
                {
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


