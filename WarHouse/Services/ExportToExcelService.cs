using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouseLibrary.Entities;
using WareHouseLibrary.WareHouseContext;
using WarHouse.Interfaces;

namespace WarHouse.Services
{
    public class ExportToExcelService : ControllerBase
    {

        private readonly WHDBContext context;
        private readonly IFilter filt;
        public ExportToExcelService(WHDBContext context, IFilter filt)
        {
            this.filt = filt;
            this.context = context;
        }
        public FileResult ExportToExcelMethod(FilterModel model)
        {
            var result = filt.exportModel(model);
           
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ExportModel");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "PartId";
                    worksheet.Cell(currentRow, 2).Value = "StartPrice";
                    worksheet.Cell(currentRow, 3).Value = "SellPrice";
                    worksheet.Cell(currentRow, 4).Value = "Warehouse";
                    worksheet.Cell(currentRow, 5).Value = "Brand";
                    worksheet.Cell(currentRow, 6).Value = "Number";
                    worksheet.Cell(currentRow, 7).Value = "VehicleDesc";
                    worksheet.Cell(currentRow, 8).Value = "VehicleType";

                    foreach (var item in result)
                    {
                        currentRow++;

                        worksheet.Cell(currentRow, 1).Value = item.PartId;
                        worksheet.Cell(currentRow, 2).Value = item.StartPrice;
                        worksheet.Cell(currentRow, 3).Value = item.SellPrice;
                        worksheet.Cell(currentRow, 4).Value = item.Warehouse;
                        worksheet.Cell(currentRow, 5).Value = item.Brand;
                        worksheet.Cell(currentRow, 6).Value = item.Number;
                        worksheet.Cell(currentRow, 7).Value = item.VehicleDesc;
                        worksheet.Cell(currentRow, 8).Value = item.VehicleType;
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();

                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "expMod.xlsx");
                    }
                }
            }  

        }

    }




   