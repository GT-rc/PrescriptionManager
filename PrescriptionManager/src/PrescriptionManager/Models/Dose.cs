using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class Dose
    {
        [Key]
        public int DoseID { get; set; }
        [Required]
        public ToD TimeOfDose { get; set; }
        [Required]
        public UserMeds UserMed { get; set; }
        [Required]
        public int PillsXDose { get; set; }
    }
}
