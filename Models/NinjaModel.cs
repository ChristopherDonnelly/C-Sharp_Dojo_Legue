using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dojo_League.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Level is required!")]
        [Display(Name = "Ninja Level (1 -10): ")]
        [Range(1, 10, ErrorMessage = "Level is required!")]
        public int Level { get; set; }

        [Display(Name = "Optional Description: ")]
        public string Description { get; set; }

        [Display(Name = "Assigned Dojo: ")]
        public int DojoId { get; set; }
        public Dojo Dojo { get; set; }
 
    }
}