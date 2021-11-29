using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseLibrary.Entities;

namespace WarHouse.Interfaces
{
   public interface IMport
    {
        public ImportFailSuccsessDublicate ImportToExcelMethod(IFormFile file);
    }
}
