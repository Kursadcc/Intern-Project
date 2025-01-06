using InternProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InternProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InternProjectDBContext _context;
        public HomeController(ILogger<HomeController> logger, InternProjectDBContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        public IActionResult Index()
        {
            var model = new EmployeeViewModel
            {
                EmployeeList = _context.tblEmployees.Include(x=> x.Skill).ToList(),
                SkillList = _context.tblSkills.ToList(),
            };
           
            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(tblEmployee model)
        {
            if (model.EmployeeID == 0)
            {
                this._context.tblEmployees.Add(model);
                this._context.SaveChanges();

                //Fetch the CustomerId returned via SCOPE IDENTITY.
                //int id = model.EmployeeID;   
            }
            else
            {
                this._context.tblEmployees.Update(model);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _context.tblEmployees.Remove(_context.tblEmployees.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");

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
