using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WareHouseLibrary.Entities
{
    public class DateTimeForJobsAmountCounter
    {
        [Key]
        public int id { get; set; }
        public int RequisiteId { get; set; }
        public DateTime dateTime { get; set; }
        public int CountDailyAmount { get; set; }
        public Requisite Requisites { get; set; }
    }
}
