using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Director()
        //{
        //    this.Movies = new HashSet<Movie>();
        //}

        [Required(ErrorMessage = "Director ID is required")]
        [Key]
        public int DirectorID { get; set; }

        [Required(ErrorMessage = "Name of the director is required")]
        [Display(Name = "Director name")]
        [StringLength(50)]
        public string DirectorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
