using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class LocationsController : Controller
    {
        private ApplicationDbContext _context;

        public LocationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            
            var viewModel = new LocationFormViewModel
            {
                Location = new Location(),
				Coaches = _context.Coaches.ToList(),
				SportsEvents = _context.SportsEvents.ToList()

			};

            return View("LocationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
				var viewModel = new LocationFormViewModel
				{
					Location = location,
					Coaches = _context.Coaches.ToList(),
					SportsEvents = _context.SportsEvents.ToList()
                    
                };

                return View("LocationForm", viewModel);
            }

            if (location.Id == 0)
                _context.Locations.Add(location);
            else
            {
                var locationInDb = _context.Locations.Single(c => c.Id == location.Id);
                locationInDb.City = location.City;
                locationInDb.Name = location.Name;
                locationInDb.State = location.State;
                locationInDb.Street = location.Street;
                locationInDb.Zip = location.Zip;
                //locationInDb.Coaches = location.Coaches;
                locationInDb.CoachesIds = location.CoachesIds;
                //locationInDb.SportsEvents = location.SportsEvents;
                locationInDb.SportsEventsIds = location.SportsEventsIds;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Locations");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (location == null)
                return HttpNotFound();

            return View(location);
        }

        public ActionResult Edit(int id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (location == null)
                return HttpNotFound();

            var viewModel = new LocationFormViewModel
            {
                Location = location,
				Coaches = _context.Coaches.ToList(),
				SportsEvents = _context.SportsEvents.ToList()

			};

            return View("LocationForm", viewModel);
        }
    }
}