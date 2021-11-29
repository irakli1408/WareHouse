using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WareHouseLibrary.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }
        [MaxLength(250)]
        public string Warehouse { get; set; }
        public double StartPrice { get; set; }
        public double SellPrice { get; set; }
        public int Quantity { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<Requisite> Requisites { get; set; }
    }
}
