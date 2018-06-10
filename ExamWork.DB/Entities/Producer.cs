using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.DB.Entities
{
    public partial class Producer
    {
        public Producer()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Required(ErrorMessage = "Producer ID is required")]
        [Key]
        public int ProducerID { get; set; }

        [Required(ErrorMessage = "Name of the producer is required")]
        [Display(Name = "Producer name")]
        [StringLength(50)]
        public string ProducerName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
