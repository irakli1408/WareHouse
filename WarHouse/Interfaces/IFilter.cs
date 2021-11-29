using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseLibrary.Entities;

namespace WarHouse.Interfaces
{
   public interface IFilter
    {
        IQueryable<ExportModel> exportModel(FilterModel model);
    }
}
