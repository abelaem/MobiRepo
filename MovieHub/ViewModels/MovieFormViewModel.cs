using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieHub.ViewModels
{
    public class MovieFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ValidDate]
        public string ReleaseDate { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0}", ReleaseDate));
        }

    }
}