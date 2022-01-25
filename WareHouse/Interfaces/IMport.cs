using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseDB.Entities;

namespace WareHouse.Interfaces
{
   public interface IMport
    {
        public ImportFailSuccsessDublicate ImportExcelMethod(IFormFile file);
    }
}
