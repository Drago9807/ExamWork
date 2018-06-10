using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Required(ErrorMessage = "Genre ID is required")]
        [Key]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Genre type is required")]
        [Display(Name = "Game type")]
        public string GenreType { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
