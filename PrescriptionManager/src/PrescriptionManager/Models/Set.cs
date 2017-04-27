using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class Set
    {
        public int ID { get; set; }
        public List<Medication> MedList { get; set; }
        public ToD TimeOfDay { get; set; }

    }
}
