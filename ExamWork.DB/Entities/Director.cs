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
    public class Director : MovieContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        [Required(ErrorMessage = "Director ID is required")]
        [Key]
        public int DirectorID { get; set; }

        [Required(ErrorMessage = "Name of the director is required")]
        [Display(Name = "Director name")]
        public string DirectorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
