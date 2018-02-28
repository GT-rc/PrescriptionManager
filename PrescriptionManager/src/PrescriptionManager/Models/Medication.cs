using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrescriptionManager.Models
{
    public class Medication
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(minimum:0, maximum:5000)]
        public int Dosage { get; set; }

        public string Notes { get; set; }
        
        public int TimesXDay { get; set; }

        [Range(minimum: 0, maximum: 300)]
        public int RefillRate { get; set; }  // number of pills in the bottle

        [Required]
        public string UserID { get; set; }

        /*  -- refactoring out into another model
        [Range(minimum: 0, maximum: 100)]
        public int PillsPerDose { get; set; }

        public ToD TimeOfDay { get; set; }
        */
        // public string Description { get; set; } -- removing

        /*
        public string PrescribingDoctor { get; set; }
        
        public string ScripNumber { get; set; }
          --- move to other model ---
        public string Pharmacy { get; set; }
        */

        /*
        public override string ToString()
        {
            System.Text.StringBuilder medString = new System.Text.StringBuilder();
            
            medString.Append($"\r\tName: {Name}" + Environment.NewLine);
            medString.Append(Environment.NewLine);
            medString.Append($"\r\tDosage: {Dosage}\r\n" + Environment.NewLine);
            medString.AppendLine($"\r\tPills in Dose: {PillsPerDose}\r\n");
            medString.Append("<br />");
            medString.Append($"\r\tTime of Day Taken: {TimeOfDay}\r\n");
            medString.Append($"\r\tPrescribing Doctor: {PrescribingDoctor}\r\n");
            medString.Append($"\r\tPharmacy: {Pharmacy}\r\n");
            medString.Append($"\r\tPrescription Number: {ScripNumber}\r\n");
            medString.Append($"\r\tDescription: {Description}\r\n");
            medString.Append($"\r\tNotes: {Notes}\r\n");

            string myString = medString.ToString();

            return myString;
        }  */
    }
}
