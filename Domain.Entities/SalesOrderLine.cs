using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesOrderLine
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public Product Product{ get; set; }
        public int ProductId { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float UnitPrice { get; set; }
        public ProducsCategory ProducsCategory { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public Sale Sale { get; set; }

        [Required]
        public int SaleId { get; set; }

    }
}
