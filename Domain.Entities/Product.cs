using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [System.Runtime.Serialization.DataContractAttribute(Name = "Product")]
    public class Product
    {
        [Required]
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id  { get; set; }
        [Required]
        [StringLength(255)]
        [System.Runtime.Serialization.DataMemberAttribute()]
        public String Name { get; set; }
        [Required]
        [System.Runtime.Serialization.DataMemberAttribute()]
        public  float Quantity { get; set; }

        public ProducsCategory ProducsCategory { get; set; }

        [Required]
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductCategoryId { get; set; }
     
        public UOM UOM { get; set; }

        [Required]
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UOMId { get; set; }
    }

}
