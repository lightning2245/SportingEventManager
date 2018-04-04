using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class SportsController : Controller
    {
        private ApplicationDbContext _context;

        public SportsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            
            var viewModel = new SportFormViewModel
            {
                Sport = new Sport(),
				Coaches = _context.Coaches.ToList()

			};

            return View("SportForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Sport sport)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SportFormViewModel
                {
                    Sport = sport,
					Coaches = _context.Coaches.ToList()

				};

                return View("SportForm", viewModel);
            }

            if (sport.Id == 0)
                _context.Sports.Add(sport);
            else
            {
                var sportInDb = _context.Sports.Single(c => c.Id == sport.Id);
                sportInDb.Name = sport.Name;
                sportInDb.Coaches = sport.Coaches;
                sportInDb.CoachesIds = sport.CoachesIds;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Sports");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var sport = _context.Sports.SingleOrDefault(c => c.Id == id);

            if (sport == null)
                return HttpNotFound();

            return View(sport);
        }

        public ActionResult Edit(int id)
        {
            var sport = _context.Sports.SingleOrDefault(c => c.Id == id);

            if (sport == null)
                return HttpNotFound();

            var viewModel = new SportFormViewModel
            {
                Sport = sport,
				Coaches = _context.Coaches.ToList()

			};

            return View("SportForm", viewModel);
        }
    }
}