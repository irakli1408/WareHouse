using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouseJob.JobConfigurationFile
{
    public  class MaxJobCount
    {
        private readonly IConfiguration Configuration;
        public  MaxJobCount(IConfiguration Configuration) => this.Configuration = Configuration ;

        public int MaxJobCountPerDay()
        {
            var result = Configuration.GetValue<int>("MaxJobCount:maxJobCount");

            return result;
        }
    }
}
