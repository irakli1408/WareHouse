using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouseLibrary.Entities;
using WarHouse.Interfaces;

namespace WarHouse.Services
{
    public class importExcelFIleCheck : IExcelFileCheck
    {
        ImportFailSuccsessDublicate failSuccsessDublicate = new ImportFailSuccsessDublicate();

        double Double= 0;
        int Integer = 0;
        DateTime dateTime;

        public bool importFileCheck(string startPrice, string sellPrice, string quantity, string dateTime1)
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
