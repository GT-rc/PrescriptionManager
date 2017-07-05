using Microsoft.AspNetCore.Mvc.Rendering;
using PrescriptionManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrescriptionManager.ViewModels
{
    public class AddMedViewModel
    {
        [Required]
        [Display(Name ="Medication Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Dosage")]
        public int Dosage { get; set; }

        public int PillsPerDose { get; set; }
        /*
        [Required]
        [Display(Name = "Number of Times per Day Taken")]
        public int TimesXDay { get; set; }
        */
        public string Notes { get; set; }

        public int RefillRate { get; set; }

        public string Description { get; set; }

        public string PrescribingDoctor { get; set; }

        public int ScripNumber { get; set; }

        public string Pharmacy { get; set; }

        [Required]
        [Display(Name = "Time of Day Taken")]
        public int ToDID { get; set; }

        public List<SelectListItem> ToDay { get; set; }

        public ToD SelectedTime { get; set; }

        public AddMedViewModel() : base() { }

        public AddMedViewModel(IEnumerable<ToD> times)
        {
            ToDay = new List<SelectListItem>();

            foreach(ToD time in times)
            {
                ToDay.Add(new SelectListItem
                {
                    Value = time.ToString(),
                    Text = time.ToString()
                });
            }
        }
    }
}
