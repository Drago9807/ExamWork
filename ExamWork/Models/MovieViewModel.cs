using ExamWork.DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamWork.Models
{
    public class MovieViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required(ErrorMessage = "Movie ID is required")]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Name of the movie is required")]
        [Display(Name = "Name of the movie")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Price of the movie is required")]
        [Display(Name = "Movie price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double? MoviePrice { get; set; }

        [Required]
        public int GenreID { get; set; }
        public virtual GenreViewModel Genre { get; set; }

        [Required]
        public int DirectorID { get; set; }
        public virtual DirectorViewModel Director { get; set; }
    }
}