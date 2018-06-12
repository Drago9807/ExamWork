using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamWork.Models
{
    public class DirectorViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required(ErrorMessage = "Director ID is required")]
        public int DirectorID { get; set; }

        [Required(ErrorMessage = "Name of the director is required")]
        [Display(Name = "Director name")]
        public string DirectorName { get; set; }

        public DirectorViewModel()
        {
        }
        public virtual ICollection<DirectorViewModel> Movies { get; set; }
    }
}