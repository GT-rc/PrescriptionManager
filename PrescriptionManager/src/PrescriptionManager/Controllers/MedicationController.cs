﻿using System;
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
        // TODO: set up db context
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

            IList<Medication> userMeds = userLoggedIn.AllMeds;

            return View(userMeds);
        }

        // To Add a new medication to your list.
        public IActionResult Add()
        {
            // TODO: List<ToD> times = query for the list of ToD's and pass into the view model
            IEnumerable<ToD> times = (ToD[])Enum.GetValues(typeof(ToD));
            
            AddMedViewModel addMedViewModel = new AddMedViewModel(times);

            return View(addMedViewModel);
        }
        
        [HttpPost]
        public IActionResult Add(AddMedViewModel addMedViewModel)
        {
            string user = User.Identity.Name;
            ApplicationUser userLoggedIn = context.Users.Single(c => c.UserName == user);

            //var time = addMedViewModel.ToDID;
            //ToD chosenTime = ;

            if (ModelState.IsValid)
            {
                Medication newMed = new Medication
                {
                    Name = addMedViewModel.Name,
                    Dosage = addMedViewModel.Dosage,
                    TimesXDay = addMedViewModel.TimesXDay,
                    Notes = addMedViewModel.Notes,
                    TimeOfDay = addMedViewModel.ToDID,
                    // TODO: will need to look up value of tod id
                    Description = addMedViewModel.Description,
                    RefillRate = addMedViewModel.RefillRate
                };

                // TODO: add to db and user list
                context.Medication.Add(newMed);
                userLoggedIn.AllMeds.Add(newMed);
                // TODO: save changes
                context.SaveChanges();

                return Redirect("/Medication/Index");
            }

            return View(addMedViewModel);
        }
        /*
        public IActionResult Remove()
        {
            ViewBag.meds = 0;
            // TODO: query db for list of all users meds, pass into ViewBag
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] medIds)
        {
            foreach (int id in medIds)
            {
                // TODO: find med in list
                // TODO: remove med from list
            }

            // TODO: save changes

            return Redirect("Medication/Index");
        }

        public IActionResult Edit(int id)
        {
            Medication med = context.Medication.Single(c => c.MedID == id);
            
            EditMedViewModel editMedViewModel = new EditMedViewModel(med);
            return View(editMedViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int medId, EditMedViewModel editMedViewModel)
        {
            Medication editedMed = context.Medication.Single(c => c.MedID == medId);

            editedMed.Name = editMedViewModel.Med.Name;
            editedMed.Dosage = editMedViewModel.Med.Dosage;
            editedMed.Notes = editMedViewModel.Med.Notes;
            editedMed.TimesXDay = editMedViewModel.Med.TimesXDay;
            editedMed.TimeOfDay = editMedViewModel.Med.TimeOfDay;
            editedMed.Description = editMedViewModel.Med.Description;
            editedMed.RefillRate = editMedViewModel.Med.RefillRate;

            // TODO: update change and save to db

            return Redirect("Medication/Index");
        }
        */
        // TODO: Create methods and logic for printing out list of meds.
    }
}
