using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.Entities
{
    public partial class Movie
    {
        [Key]
        [Required(ErrorMessage = "Movie ID is required")]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Name of the movie is required")]
        [Display(Name = "Name of the movie")]
        [StringLength(50)]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Price of the movie is required")]
        [Display(Name = "Movie price")]
        public double MoviePrice { get; set; }

        [Required]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }

        [Required]
        public int DirectorID { get; set; }
        public virtual Director Director { get; set; }
    }
}
