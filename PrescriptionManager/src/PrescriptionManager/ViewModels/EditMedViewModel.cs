﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
        /*
        public int ScripNumber { get; set; }

        public int PillsPerDose { get; set; }

        public string PrescribingDoctor { get; set; }

        public string Pharmacy { get; set; }
        */
        public List<SelectListItem> Times { get; set; }

        public ToD SelectedTime { get; set; }

        public EditMedViewModel() : base() { }

        public EditMedViewModel(Medication med, IEnumerable<ToD> times)
        {
            Med = med;

            Times = new List<SelectListItem>();

            foreach (ToD time in times)
            {
                Times.Add(new SelectListItem
                {
                    Value = time.ToString(),
                    Text = time.ToString()
                });
            }
        }
    }
}
