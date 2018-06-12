﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Genre ID is required")]
        [Key]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Genre type is required")]
        [Display(Name = "Genre type")]
        public string GenreType { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
