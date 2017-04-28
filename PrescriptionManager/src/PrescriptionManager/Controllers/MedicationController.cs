using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrescriptionManager.ViewModels;
using PrescriptionManager.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PrescriptionManager.Controllers
{
    public class MedicationController : Controller
    {
        // TODO: set up db context

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            // TODO: List<ToD> times = query for the list of ToD's and pass into the view model
            AddMedViewModel addMedViewModel = new AddMedViewModel();

            return View(addMedViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMedViewModel addMedViewModel)
        {
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
                    Description = addMedViewModel.Description
                };

                // TODO: add to db
                // TODO: save changes

                return Redirect("/Medication/Index");
            }

            return View(addMedViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.meds = 0;
            // TODO: query db for list of all users meds
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
    }
}
