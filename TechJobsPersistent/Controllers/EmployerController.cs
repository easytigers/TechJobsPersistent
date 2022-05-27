using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context; // Set up a private DbContext variable 

        public EmployerController(JobDbContext dbContext) // Pass it into a EmployerController constructor
        {
            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList(); //passes all of the Employer objects in the database to the view
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel(); //Create an instance of AddEmployerViewModel
            return View(addEmployerViewModel); //pass the instance into the View() return method
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel) //process form submissions
        {
            if (ModelState.IsValid)
            {
                context.Employers.Add(addEmployerViewModel);
                context.SaveChanges();
                return Redirect("/Employer");
            }

        return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Find(id); //passing an Employer object to the view 
            return View(employer);
        }
    }
}
