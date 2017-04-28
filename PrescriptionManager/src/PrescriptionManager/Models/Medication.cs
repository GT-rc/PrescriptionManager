﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class Medication
    {
        [Key]
        public int MedID { get; set; }
        public string Name { get; set; }
        public int Dosage { get; set; }
        public string Notes { get; set; }
        public int TimesXDay { get; set; }
        public int TimeOfDay { get; set; }
        public string Description { get; set; }

    }
}
