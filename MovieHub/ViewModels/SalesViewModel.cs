using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MovieHub.ViewModels
{
    public class SalesViewModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string CreatedBy { get; set; }
        [Required]
        public Partner Partner { get; set; }
        public int PartnerId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        public float SalesTotal { get; set; }
        [Required]
        public IEnumerable<SalesOrderLine> SalesOrderLine { get; set; }

        public SalesViewModel()
        {

            CreatedDate = DateTime.Now;
            CreatedBy = "";

        }
    }
}