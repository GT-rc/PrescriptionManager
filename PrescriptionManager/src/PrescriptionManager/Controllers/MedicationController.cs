using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrescriptionManager.ViewModels;
using PrescriptionManager.Models;
using PrescriptionManager.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PrescriptionManager.Controllers
{
    public class MedicationController : Controller
    {
        // set up db context
        private readonly ApplicationDbContext context;

        public MedicationController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ApplicationUser userLoggedIn;

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                userLoggedIn = context.Users.Single(c => c.UserName == userName);

            } else
            {
                return Redirect("/");
            }

            IList<Medication> userMeds = context.Medication.Where(c => c.UserID == userLoggedIn.Id).ToList();
            //IList<Medication> userMeds = userLoggedIn.AllMeds;

            return View(userMeds);
        }

        // To view a medication
        public IActionResult View(int id)
        {
            Medication medToView = context.Medication.Single(c => c.ID == id);
            ViewBag.med = medToView;

            return View();
        }

        // To Add a new medication to your list.
        public IActionResult Add()
        {
            // query for the list of ToD's and pass into the view model
            IEnumerable<ToD> times = (ToD[])Enum.GetValues(typeof(ToD));
            
            AddMedViewModel addMedViewModel = new AddMedViewModel(times);

            return View(addMedViewModel);
        }
        
        [HttpPost]
        public IActionResult Add(AddMedViewModel addMedViewModel)
        {
            string user = User.Identity.Name;
            ApplicationUser userLoggedIn = context.Users.Single(c => c.UserName == user);

            // Looked for this code for a long time, and thought I didn't use it, I wanted it written down...
            // var time = (ToD)System.Enum.Parse(typeof(ToD), addMedViewModel.SelectedTime);

            if (ModelState.IsValid)
            {
                Medication newMed = new Medication
                {
                    Name = addMedViewModel.Name,
                    Dosage = addMedViewModel.Dosage,
                    //TimesXDay = addMedViewModel.TimesXDay,
                    Notes = addMedViewModel.Notes,
                    TimeOfDay = addMedViewModel.SelectedTime,
                    Description = addMedViewModel.Description,
                    RefillRate = addMedViewModel.RefillRate,
                    PrescribingDoctor = addMedViewModel.PrescribingDoctor,
                    ScripNumber = addMedViewModel.ScripNumber,
                    Pharmacy = addMedViewModel.Pharmacy,
                    PillsPerDose = addMedViewModel.PillsPerDose,
                    UserID = userLoggedIn.Id
                };

                // add to db and user list
                context.Medication.Add(newMed);
                userLoggedIn.AllMeds.Add(newMed);
                // save changes
                context.SaveChanges();

                return Redirect("/Medication/Index");
            }

            return View(addMedViewModel);
        }
        
        public IActionResult Remove()
        {
            string user = User.Identity.Name;
            ApplicationUser userLoggedIn = context.Users.Single(c => c.UserName == user);

            // query db for list of all users meds, pass into view
            ViewBag.meds = context.Medication.Where(c => c.UserID == userLoggedIn.Id).ToList();
            
            return View();
        }
        
        [HttpPost] 
        public IActionResult Remove(int[] medIds)
        {
            string user = User.Identity.Name;
            ApplicationUser userLoggedIn = context.Users.Single(c => c.UserName == user);

            foreach (int id in medIds)
            {
                // find med
                Medication medToRemove = context.Medication.Single(c => c.ID == id);
                // delete med
                context.Medication.Remove(medToRemove);
                // save changes
                context.SaveChanges();
            }

            return Redirect("/Medication/Index");
        }
        
        public IActionResult Edit(int id)
        {
            Medication med = context.Medication.Single(c => c.ID == id);

            IEnumerable<ToD> times = (ToD[])Enum.GetValues(typeof(ToD));

            EditMedViewModel editMedViewModel = new EditMedViewModel(med, times);
            return View(editMedViewModel);
        }

        [HttpPost]
        public IActionResult EditPost(int id, EditMedViewModel editMedViewModel)
        {
            Medication editedMed = context.Medication.Single(c => c.ID == id);
            
            editedMed.Name = editMedViewModel.Med.Name;
            editedMed.Dosage = editMedViewModel.Med.Dosage;
            editedMed.Notes = editMedViewModel.Med.Notes;
            //editedMed.TimesXDay = editMedViewModel.Med.TimesXDay;
            editedMed.TimeOfDay = editMedViewModel.SelectedTime;
            editedMed.Description = editMedViewModel.Med.Description;
            editedMed.RefillRate = editMedViewModel.Med.RefillRate;
            editedMed.Pharmacy = editMedViewModel.Med.Pharmacy;
            editedMed.PrescribingDoctor = editMedViewModel.Med.PrescribingDoctor;
            editedMed.ScripNumber = editMedViewModel.Med.ScripNumber;
            editedMed.PillsPerDose = editMedViewModel.Med.PillsPerDose;

            // update change and save to db
            context.Medication.Update(editedMed);
            context.SaveChanges();

            return Redirect("/Medication/Index");
        }
        
        // TODO: Create methods and logic for printing out list of meds.
        public IActionResult Print()
        {
            ApplicationUser userLoggedIn;

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                userLoggedIn = context.Users.Single(c => c.UserName == userName);

            }
            else
            {
                return Redirect("/");
            }

            IList<Medication> userMeds = context.Medication.Where(c => c.UserID == userLoggedIn.Id).ToList();

            return View(userMeds);
        }
    }
}
