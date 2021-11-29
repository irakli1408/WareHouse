using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouseLibrary.Entities
{
    public class ExportModel
    {
        public string PartId { get; set; }
        //public string Name { get; set; }
        public double? StartPrice { get; set; }
        public double? SellPrice { get; set; }
        public string Warehouse { get; set; }
        public string Brand { get; set; }
        public string Number { get; set; }
        public string VehicleDesc { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }
    }
}
