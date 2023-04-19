using FinalMission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMission.Controllers
{
    public class HomeController : Controller
    {
        private IAgencyRepository repo;
        public HomeController(IAgencyRepository temp)
        {
            repo = temp;
        }

        //Pulls data from the data base using the repository pattern, displays it to an Entertainers View
        public IActionResult Entertainers()
        {
            var entertainers = repo.Entertainers.ToList();

            return View(entertainers);
        }

        //Home page
        public IActionResult Index()
        {
            return View();
        }

        //Grabs the details of a specific Entertainer to display all their info!
        public IActionResult Details(long id)
        {
            var entertainer = repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        //Displays the create view, to add an entertainer into the database!
        public IActionResult Add()
        {
            return View();
        }

        // the post method of the create view to send in the newEntertainer
        [HttpPost]
        public IActionResult Add(Entertainers newEntertainer)
        {
            if (ModelState.IsValid)
            {
                repo.AddEntertainer(newEntertainer);
                return RedirectToAction("Entertainers");
            }

            return View(newEntertainer);
        }

        //You probably get what this is by know, kinda similar to the previous "Details" action except this is more than just looking potentially (it's gotta post!)
        public IActionResult Edit(long id)
        {
            var entertainer = repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        // THE ACTUAL updating
        [HttpPost]
        public IActionResult Edit(long id, Entertainers updatedEntertainer)
        {
            if (ModelState.IsValid)
            {
                // Update the project in the database
                repo.UpdateEntertainer(updatedEntertainer);
                //this includes the ID so you can view the details page after editing it
                return RedirectToAction("Details", new { id = updatedEntertainer.EntertainerId });
            }

            return View(updatedEntertainer);
        }

        
        public IActionResult Delete(long id)
        {
            var entertainer = repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        [HttpPost]
        public IActionResult Delete(long id, Entertainers entertainerToDelete)
        {
            repo.DeleteEntertainer(id);
            return RedirectToAction("Entertainers");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
