using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Interfaces
{
    public interface IExcelFileCheck
    {
        public bool ImportFileCheck(string startPrice, string sellPrice, string quantity, string dateTime1);
    }
}
