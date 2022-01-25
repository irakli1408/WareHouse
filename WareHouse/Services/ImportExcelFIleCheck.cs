
using System;
using WareHouse.Interfaces;
using WareHouseDB.Entities;

namespace WareHouse.Services
{
    public class ImportExcelFIleCheck : IExcelFileCheck
    {
        ImportFailSuccsessDublicate failSuccsessDublicate = new ImportFailSuccsessDublicate();

        double Double= 0;
        int Integer = 0;
        DateTime dateTime;

        public bool ImportFileCheck(string startPrice, string sellPrice, string quantity, string dateTime1)
        {
            if (!double.TryParse(startPrice, out Double) ||
                           !double.TryParse(sellPrice, out Double) ||
                           !int.TryParse(quantity, out Integer) ||
                           !DateTime.TryParse(dateTime1, out dateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
