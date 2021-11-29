using System;
using System.Collections.Generic;
using System.Text;
using PagedList;


namespace WareHouseLibrary.Entities
{
   public class ExportModelForFront 
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }

        public IPagedList<ExportModel> Items { get; set; }

        //public string PartId { get; set; }
        ////public string Name { get; set; }
        //public double? StartPrice { get; set; }
        //public double? SellPrice { get; set; }
        //public string Warehouse { get; set; }
        //public string Brand { get; set; }
        //public string Number { get; set; }
        //public string VehicleDesc { get; set; }
        //public string VehicleType { get; set; }
        //public string Description { get; set; }

    }
}
