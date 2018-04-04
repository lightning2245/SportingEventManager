using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class AgeRangesController : Controller
    {
        private ApplicationDbContext _context;

        public AgeRangesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {           
            var viewModel = new AgeRangeFormViewModel
            {
                AgeRange = new AgeRange(),
                
            };

            return View("AgeRangeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AgeRange ageRange)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AgeRangeFormViewModel
                {
                    AgeRange = ageRange,
                    
                };

                return View("AgeRangeForm", viewModel);
            }

            if (ageRange.Id == 0)
                _context.AgeRanges.Add(ageRange);
            else
            {
                var ageRangeInDb = _context.AgeRanges.Single(c => c.Id == ageRange.Id);
                ageRangeInDb.Min = ageRange.Min;
                ageRangeInDb.Max = ageRange.Max;
                ageRangeInDb.SportsEvents = ageRange.SportsEvents;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "AgeRanges");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var ageRange = _context.AgeRanges.SingleOrDefault(c => c.Id == id);

            if (ageRange == null)
                return HttpNotFound();

            return View(ageRange);
        }

        public ActionResult Edit(int id)
        {
            var ageRange = _context.AgeRanges.SingleOrDefault(c => c.Id == id);

            if (ageRange == null)
                return HttpNotFound();

            var viewModel = new AgeRangeFormViewModel
            {
                AgeRange = ageRange
            };

            return View("AgeRangeForm", viewModel);
        }
    }
}