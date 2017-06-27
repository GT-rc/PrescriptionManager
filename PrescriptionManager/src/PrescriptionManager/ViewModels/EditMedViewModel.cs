using PrescriptionManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.ViewModels
{
    public class EditMedViewModel
    {
        [Required]
        public int MedId { get; set; }

        public Medication Med { get; set; }

        public EditMedViewModel() : base() { }

        public EditMedViewModel(Medication med)
        {
            Med = med;
        }
    }
}
