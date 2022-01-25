using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Interfaces;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseDB.Entities;

namespace WareHouse.Repositories
{
    public class FIlterService
    {
        
        private readonly IFilter filt;

        public FIlterService(IFilter filt)
        {           
            this.filt = filt;
        }


        public ExportModelForFront DataFiltering(FilterModel model) 
        {

           var res =  filt.ExportModel(model);

            int pageNumber = 1;

            int pageSize = 10;

            var result = res.ToPagedList(pageNumber, pageSize);


            ExportModelForFront exportModelForFront = new ExportModelForFront()
            {
                Total = result.TotalItemCount,
                PageSize = result.PageSize,
                PageCount = result.PageCount,
                Page = result.PageNumber,

                Items = result
            };

            return exportModelForFront;
        }

      

    }

}




