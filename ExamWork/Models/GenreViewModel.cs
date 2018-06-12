using ExamWork.DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamWork.Models
{
    public class GenreViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required(ErrorMessage = "Genre ID is required")]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Genre type is required")]
        [Display(Name = "Genre type")]
        public string GenreType { get; set; }

        public GenreViewModel()
        {
        }
        public virtual ICollection<MovieViewModel> Movies { get; set; }
    }
}