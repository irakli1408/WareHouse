using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarHouse.Interfaces
{
    public interface IExcelFileCheck
    {
        public bool importFileCheck(string startPrice, string sellPrice, string quantity, string dateTime1);
    }
}
