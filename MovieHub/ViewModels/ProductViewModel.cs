using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MovieHub.ViewModels
{
    public class ProductViewModel
    {
        
        public int Id { get; set; }
        [Required]

        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        public float Quantity { get; set; }

       

        [Required]
        public int ProductCategoryId { get; set; }
      
        [Required]
        public int UOMId { get; set; }
        public IEnumerable<ProducsCategory> ProducsCategories { get; set; }
        public IEnumerable<UOM> UOMs { get; set; }
    }
}