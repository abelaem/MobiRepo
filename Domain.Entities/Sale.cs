using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Sale
    { 
        [Required]
        public int Id { get; set; }
        public string Reference { get; set; }
        public string  CreatedBy { get; set; }       
        public Partner Partner { get; set; }
        [Required]
        public int PartnerId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public float SalesTotal { get; set; }
        public IEnumerable<SalesOrderLine> SalesOrderLine { get; set; }
        
        
    }
}
