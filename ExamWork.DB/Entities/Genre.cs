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
    public class Genre : MovieContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Genre ID is required")]
        [Key]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Genre type is required")]
        [Display(Name = "Genre type")]
        public string GenreType { get; set; }

        //public virtual ICollection<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
