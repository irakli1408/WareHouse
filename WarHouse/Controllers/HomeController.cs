using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WareHouse.Interfaces;
using WareHouseLibrary.Entities;
using WareHouseLibrary.WareHouseContext;
using WarHouse.Interfaces;
using WarHouse.Repositories;
using WarHouse.Services;

namespace WareHouse.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly WHDBContext context;
        private readonly IFilter filt;
        private readonly IExcelFileCheck iExcelFileCheck;
     //   private readonly BackgroundJob backgroundJob;

        public HomeController(WHDBContext context, IFilter filt, IExcelFileCheck iExcelFileCheck)
        { 
            this.context = context;
            this.filt = filt;
            this.iExcelFileCheck = iExcelFileCheck;
          //  this.backgroundJob = backgroundJob;
        }

        [HttpPost]
        [Route("GetGrid")]
        public ActionResult GetGrid([FromBody] FilterModel model)
        {
            var repos = new FilterRepository(context, filt);

            return Ok(repos.DataFiltering(model));
        }

        [HttpPost]
        [Route("Export")]
        public FileResult ExportToExcel([FromBody] FilterModel model)
        {
            var res = new ExportToExcelService(context, filt);

            return res.ExportToExcelMethod(model);
        }

        [HttpPost]
        [Route("Import")]
        public void ImportToExcel(IFormFile file)
        {
            var res = new ImportToExcelService(context, iExcelFileCheck);
            res.ImportToExcelMethod(file);
        }
    }
}
