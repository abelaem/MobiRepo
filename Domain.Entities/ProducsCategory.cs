using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProducsCategory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
    }
}
