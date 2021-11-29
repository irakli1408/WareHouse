using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseLibrary.Entities;
using WareHouseLibrary.WareHouseContext;
using PagedList;
using AutoMapper;
using WarHouse.Interfaces;

namespace WarHouse.Repositories
{
    public class FilterRepository
    {
        private readonly WHDBContext context;
        private readonly IFilter filt;

        public FilterRepository(WHDBContext context, IFilter filt)
        {
            this.context = context;
            this.filt = filt;
        }


        public ExportModelForFront DataFiltering(FilterModel model) 
        {

           var res =  filt.exportModel(model);

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




