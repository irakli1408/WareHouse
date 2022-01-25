using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.IO;
using WareHouse.Interfaces;
using WareHouseDb.Entities;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseDB.Entities;
using System.Linq;

namespace WareHouse.Services
{
    public class ImportExcelService : IMport
    {
        private readonly WareHouseDBContext context;
        private readonly IExcelFileCheck iExcelFileCheck;
        public ImportExcelService(WareHouseDBContext context, IExcelFileCheck iExcelFileCheck)
        {
            this.context = context;
            this.iExcelFileCheck = iExcelFileCheck;
        }

        public ImportFailSuccsessDublicate ImportExcelMethod(IFormFile file)
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

                        try
                        {
                            if (products.Any(x => x.ProductCode.Equals(worksheet.Cells[i, 1].Value.ToString().Trim())))
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
