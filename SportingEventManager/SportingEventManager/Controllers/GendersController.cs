using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class GendersController : Controller
    {
        private ApplicationDbContext _context;

        public GendersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {

			var viewModel = new GenderFormViewModel
			{
				Gender = new Gender(),
				Coaches = _context.Coaches.ToList()
                
            };

            return View("GenderForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Gender gender)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GenderFormViewModel
                {
                    Gender = gender,
					Coaches = _context.Coaches.ToList()
                    
                };

                return View("GenderForm", viewModel);
            }

            if (gender.Id == 0)
                _context.Genders.Add(gender);
            else
            {
                var genderInDb = _context.Genders.Single(c => c.Id == gender.Id);
                genderInDb.Name = gender.Name;
                genderInDb.Coaches = gender.Coaches;
                genderInDb.CoachesIds = gender.CoachesIds;                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Genders");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var gender = _context.Genders.SingleOrDefault(c => c.Id == id);

            if (gender == null)
                return HttpNotFound();

            return View(gender);
        }

        public ActionResult Edit(int id)
        {
            var gender = _context.Genders.SingleOrDefault(c => c.Id == id);

            if (gender == null)
                return HttpNotFound();

            var viewModel = new GenderFormViewModel
            {
                Gender = gender,
				Coaches = _context.Coaches.ToList()

			};

            return View("GenderForm", viewModel);
        }
    }
}