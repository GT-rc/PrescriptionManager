using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class Medication
    {
        
        public int ID { get; set; }

        public string Name { get; set; }
        public int Dosage { get; set; }
        public string Notes { get; set; }
        public int TimesXDay { get; set; }
        public int PillsPerDose { get; set; }
        public ToD TimeOfDay { get; set; }
        public string Description { get; set; }
        public int RefillRate { get; set; }  // number of pills in the bottle
        public string PrescribingDoctor { get; set; }
        public int ScripNumber { get; set; }
        public string Pharmacy { get; set; }
        [Required]
        public string UserID { get; set; }
    }
}
