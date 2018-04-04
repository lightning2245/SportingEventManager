using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class OrganizersController : Controller
    {
        private ApplicationDbContext _context;

        public OrganizersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
			var sportsEvents = _context.SportsEvents.ToList();
            var viewModel = new OrganizerFormViewModel
            {
                Organizer = new Organizer(),
				SportsEvents = sportsEvents

			};

            return View("OrganizerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
				var viewModel = new OrganizerFormViewModel
				{
					Organizer = organizer,
					SportsEvents = _context.SportsEvents.ToList()
                    
                };

                return View("OrganizerForm", viewModel);
            }

            if (organizer.Id == 0)
                _context.Organizers.Add(organizer);
            else
            {
                var organizerInDb = _context.Organizers.Single(c => c.Id == organizer.Id);
                organizerInDb.City  = organizer.City;
				organizerInDb.Zip = organizer.Zip;
				organizerInDb.Street = organizer.Street;
				organizerInDb.FirstName = organizer.FirstName;
                organizerInDb.LastName = organizer.LastName;
                //organizerInDb.SportsEvents = organizer.SportsEvents;
                organizerInDb.SportsEventsIds = organizer.SportsEventsIds;
                organizerInDb.State = organizer.State;                  
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Organizers");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var organizer = _context.Organizers.SingleOrDefault(c => c.Id == id);

            if (organizer == null)
                return HttpNotFound();

            return View(organizer);
        }

        public ActionResult Edit(int id)
        {
            var organizer = _context.Organizers.SingleOrDefault(c => c.Id == id);

            if (organizer == null)
                return HttpNotFound();

			var viewModel = new OrganizerFormViewModel
			{
				Organizer = organizer,
				SportsEvents = _context.SportsEvents.ToList()
                
            };

            return View("OrganizerForm", viewModel);
        }
    }
}