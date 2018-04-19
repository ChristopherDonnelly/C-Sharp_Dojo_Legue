using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dojo_League.Models
{
    public class Dojo : BaseEntity
    {
        [Key]
        public int DojoId { get; set; }

        [Required(ErrorMessage = "Dojo Location is required!")]
        [Display(Name = "Dojo Location: ")]
        public string Location { get; set; }
        

        [Display(Name = "Additional Information: ")]
        public string Info { get; set; }

        public List<Ninja> Ninjas { get; set; }
 
        public Dojo()
        {
            Ninjas = new List<Ninja>();
        }
    }
}