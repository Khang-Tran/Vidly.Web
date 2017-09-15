using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
    
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }
        public DateTime AddedDate { get; set; }
        [Range(1,20)]
        [Display(Name = "Number in stock")]
        public int Stock { get; set; }
    }
}