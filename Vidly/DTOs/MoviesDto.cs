using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Models.Validations;

namespace Vidly.DTOs
{
    public class MoviesDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
  
        public int GenreId { get; set; }

        public DateTime ReleasedDate { get; set; }
        public DateTime AddedDate { get; set; }
   
        public int Stock { get; set; }
        public GenresDto Genre { get; set; }
    }
}