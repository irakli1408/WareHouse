using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using WareHouseLibrary.Entities;
using System.Linq;
using WareHouseLibrary.WareHouseContext;
using WarHouse.Interfaces;

namespace WarHouse.Services
{
    public class ImportToExcelService : IMport
    {
        private readonly WHDBContext context;
        private readonly IExcelFileCheck iExcelFileCheck;
        public ImportToExcelService(WHDBContext context, IExcelFileCheck iExcelFileCheck)
        {
            this.context = context;
            this.iExcelFileCheck = iExcelFileCheck;
        }

        public ImportFailSuccsessDublicate ImportToExcelMethod(IFormFile file)
        {

            ImportFailSuccsessDublicate failSuccsessDublicate = new ImportFailSuccsessDublicate();

            var quary = from p in context.Products
                        select p;

            var products = quary.ToList();


            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    var rowcount = worksheet.Dimension.Rows;

             
 
                    for (int i = 2; i <= rowcount; i++)
                    {
                        //string a = worksheet.Cells[i, 1].Value.ToString().Trim();
                        //var startPrice = worksheet.Cells[i, 3].Value.ToString().Trim();
                        //var sellPrice = worksheet.Cells[i, 4].Value.ToString().Trim();
                        //var quantity = worksheet.Cells[i, 5].Value.ToString().Trim();
                        //var dataTime = worksheet.Cells[i, 6].Value.ToString().Trim();


                        //if (products.Any(x => x.ProductCode.Equals(a)))
                        //{
                        //    failSuccsessDublicate.Dublicate++;
                        //    continue;
                        //}
                        //else
                        //{

                        //    if (iExcelFileCheck.importFileCheck(startPrice, sellPrice, quantity, dataTime))
                        //    {
                        //        failSuccsessDublicate.Fail++;
                        //        continue;
                        //    }

                        //    context.Products.Add(new Product
                        //    {
                        //        ProductCode = a,
                        //        Warehouse = worksheet.Cells[i, 2].Value.ToString().Trim(),
                        //        StartPrice = double.Parse(startPrice),
                        //        SellPrice = double.Parse(sellPrice),
                        //        Quantity = int.Parse(quantity),
                        //        DateCreated = DateTime.Parse(dataTime)
                        //    });
                        //}
                        //failSuccsessDublicate.Success++;



                        try
                        {                           
                           if( products.Any(x => x.ProductCode.Equals(worksheet.Cells[i, 1].Value.ToString().Trim())))
                            {
                                failSuccsessDublicate.Dublicate++;
                                continue;
                            }                 

                            context.Products.Add(new Product
                            {
                                ProductCode = worksheet.Cells[i, 1].Value.ToString().Trim(),
                                Warehouse = worksheet.Cells[i, 2].Value.ToString().Trim(),
                                StartPrice = double.Parse(worksheet.Cells[i, 3].Value.ToString().Trim()),
                                SellPrice = double.Parse(worksheet.Cells[i, 4].Value.ToString().Trim()),
                                Quantity = int.Parse(worksheet.Cells[i, 5].Value.ToString().Trim()),
                                DateCreated = DateTime.Parse(worksheet.Cells[i, 6].Value.ToString().Trim()),

                            });

                            failSuccsessDublicate.Success++;
                        }
                        catch
                        {
                            failSuccsessDublicate.Fail++;
                            continue;
                        }
                    }

                    context.SaveChanges();

                    return failSuccsessDublicate;

                }
            }

        }
    }
}
