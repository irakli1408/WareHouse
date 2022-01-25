using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WareHouse.Interfaces;
using WareHouse.Repositories;
using WareHouse.Services;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseDB.Entities;

namespace WareHouse.Controllers
{
    public class WareHouseController : ControllerBase
    {
        private readonly WareHouseDBContext context;
        private readonly IFilter filt;
        private readonly IExcelFileCheck iExcelFileCheck;

        public WareHouseController(WareHouseDBContext context, IFilter filt, IExcelFileCheck iExcelFileCheck)
        {
            this.context = context;
            this.filt = filt;
            this.iExcelFileCheck = iExcelFileCheck;
        }

        [HttpPost]
        [Route("GetGrid")]
        public ActionResult GetGrid([FromBody] FilterModel model)
        {
            var result = new FIlterService(filt);

            return Ok(result.DataFiltering(model));
        }

        [HttpPost]
        [Route("Export")]
        public FileResult ExportToExcel([FromBody] FilterModel model)
        {
            var result = new ExportToExcelService(context, filt);

            return result.ExportToExcelMethod(model);
        }

        [HttpPost]
        [Route("Import")]
        public ActionResult ImportExcel(IFormFile file)
        {
            var result = new ImportExcelService(context, iExcelFileCheck);
            result.ImportExcelMethod(file);
            return Ok(new { success = true });
        }
    }
}
