using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouseJob.JobConfigurationFile
{
    public  class RequisiteStatus
    {
        private readonly IConfiguration Configuration;

        public RequisiteStatus(IConfiguration Configuration) => this.Configuration = Configuration;

        public int Fail { get; set; } 
        public int Success { get; set; }
    }
}
