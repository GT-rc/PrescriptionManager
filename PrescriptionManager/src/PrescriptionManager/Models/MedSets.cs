using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class MedSets
    {
        public int ID { get; set; }

        public int SetID { get; set; }
        public Set MedSet { get; set; }

        public int UserID { get; set; }
        public ApplicationUser User { get; set; }

    }
}
