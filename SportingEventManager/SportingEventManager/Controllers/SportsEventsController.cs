using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class SportsEventsController : Controller
    {
        private ApplicationDbContext _context;

        public SportsEventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
			var ageRanges = _context.AgeRanges.ToList();
			var genders = _context.Genders.ToList();
			var locations = _context.Locations.ToList();
			var organizers = _context.Organizers.ToList();
			var schedules = _context.Schedules.ToList();
			var sports = _context.Sports.ToList();
			var players = _context.Players.ToList();
			var coaches = _context.Coaches.ToList();			

			var viewModel = new SportsEventFormViewModel
			{
				SportsEvent = new SportsEvent(),
				AgeRanges = ageRanges,
				Genders = genders,
				Locations = locations,
				Organizers = organizers,
				Schedules = schedules,
				Sports = sports,
				Players = players,
				Coaches = coaches				
			};

			return View("SportsEventForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SportsEvent sportsEvent)
        {
			if (!ModelState.IsValid)
            {
				var viewModel = new SportsEventFormViewModel
                {
					SportsEvent = sportsEvent,
					AgeRanges = _context.AgeRanges.ToList(),
					Genders = _context.Genders.ToList(),
					Locations = _context.Locations.ToList(),
					Organizers = _context.Organizers.ToList(),
					Schedules = _context.Schedules.ToList(),
					Sports = _context.Sports.ToList(),
					Players = _context.Players.ToList(),
					Coaches = _context.Coaches.ToList()					
				};

                return View("SportsEventForm", viewModel);
            }

			if (sportsEvent.Id == 0)
			{
				//int locId = sportsEvent.Location.Id;
				//string locName = sportsEvent.Location.Name;
				//int genId = sportsEvent.Gender.Id;
				//string genName = sportsEvent.Gender.Name;

				//int test = 0;

				_context.SportsEvents.Add(sportsEvent);
			}
			else
			{
				var sportsEventInDb = _context.SportsEvents.Single(c => c.Id == sportsEvent.Id);
				//sportsEventInDb.Location = sportsEvent.Location;
				sportsEventInDb.LocationId = sportsEvent.LocationId;
				sportsEventInDb.Name = sportsEvent.Name;
				//sportsEventInDb.Organizer = sportsEvent.Organizer;
				sportsEventInDb.OrganizerId = sportsEvent.OrganizerId;
				//sportsEventInDb.Players = sportsEvent.Players;
				sportsEventInDb.PlayersIds = sportsEvent.PlayersIds;
				//sportsEventInDb.Schedule = sportsEvent.Schedule;
				sportsEventInDb.ScheduleId = sportsEvent.ScheduleId;
				//sportsEventInDb.Sport = sportsEvent.Sport;
				sportsEventInDb.SportId = sportsEvent.SportId;
				//sportsEventInDb.AgeRange = sportsEvent.AgeRange;
				sportsEventInDb.AgeRangeId = sportsEvent.AgeRangeId;
				//sportsEventInDb.Coaches = sportsEvent.Coaches;
				sportsEventInDb.CoachesIds = sportsEvent.CoachesIds;
				//sportsEventInDb.Gender = sportsEvent.Gender;
				sportsEventInDb.GenderId = sportsEvent.GenderId;
			}
						
			_context.SaveChanges();

            return RedirectToAction("Index", "SportsEvents");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var sportsEvent = _context.SportsEvents
				.Include(c => c.AgeRange)
				//.Include(c => c.Coaches)
				.Include(c => c.Gender)
				.Include(c => c.Location)
				.Include(c => c.Organizer)
				//.Include(c => c.Players)
				.Include(c => c.Schedule)
				.Include(c => c.Sport)
				.SingleOrDefault(c => c.Id == id);

            if (sportsEvent == null)
                return HttpNotFound();

            return View(sportsEvent);
        }

        public ActionResult Edit(int id)
        {
            var sportsEvent = _context.SportsEvents.SingleOrDefault(c => c.Id == id);


            if (sportsEvent == null)
                return HttpNotFound();

            var viewModel = new SportsEventFormViewModel
            {
                SportsEvent = sportsEvent,
				AgeRanges = _context.AgeRanges.ToList(),
				Genders = _context.Genders.ToList(),
				Locations = _context.Locations.ToList(),
				Organizers = _context.Organizers.ToList(),
				Schedules = _context.Schedules.ToList(),
				Sports = _context.Sports.ToList(),
				Players = _context.Players.ToList(),
				Coaches = _context.Coaches.ToList()
			};

            return View("SportsEventForm", viewModel);
        }
    }
}