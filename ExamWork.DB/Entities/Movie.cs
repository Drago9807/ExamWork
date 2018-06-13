using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.Entities
{
    public class Movie : MovieContext

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("Genre")]
        [Required]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }

        [ForeignKey("Director")]
        [Required]
        public int DirectorID { get; set; }
        public virtual Director Director { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
