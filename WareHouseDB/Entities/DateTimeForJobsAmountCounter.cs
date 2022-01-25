using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WareHouseDB.Entities
{
    public class DateTimeForJobsAmountCounter
    {
        [Key]
        public int id { get; set; }

        public DateTime CurrentDate{ get; set; }
        public int CountDailyAmount { get; set; }
       
    }
}
