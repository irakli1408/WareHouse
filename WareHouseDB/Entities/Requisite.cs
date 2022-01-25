using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WareHouseDb.Entities
{
   public class Requisite
    {
        [Key]      
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Number { get; set; }
        public string VehicleDescription { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public int StatusId { get; set; }
        public int? Count { get; set; }
        public Status Status { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
