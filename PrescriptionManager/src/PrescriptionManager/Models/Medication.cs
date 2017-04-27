using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class Medication
    {
        public int MedID { get; set; }
        public string Name { get; set; }
        public int Dosage { get; set; }
        public string Notes { get; set; }
        public int TimesXDay { get; set; }
        public ToD TimeOfDay { get; set; }
        public string Description { get; set; }

    }
}
