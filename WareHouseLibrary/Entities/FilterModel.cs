using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouseLibrary.Entities
{
    public class FilterModel
    {
        public string Description { get; set; }
        public int? StartPrice { get; set; }
        public int? EndPrice { get; set; }
        public int? SellStartPrice { get; set; }
        public int? SellEndPrice { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
