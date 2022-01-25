using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WareHouseDb.Entities
{
   public class Status
    {
        [Key]
        public int Id { get; set; }
        public string СurrentStatus { get; set; }       

        public ICollection<Requisite> Requisites { get; set; }

    }
}
