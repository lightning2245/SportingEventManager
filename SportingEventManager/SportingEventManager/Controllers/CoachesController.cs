using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;
using System;

namespace SportingEventManager.Controllers
{
    public class CoachesController : Controller
    {
        private ApplicationDbContext _context;

        public CoachesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {			
			var locations = _context.Locations.ToList();
			var sports = _context.Sports.ToList();
			var genders = _context.Genders.ToList();
			var ageRanges = _context.AgeRanges.ToList();
			var schedules = _context.Schedules.ToList();
			var sportsEvents = _context.SportsEvents.ToList();


			var viewModel = new CoachFormViewModel
            {
                Coach = new Coach(),
				Locations = locations,
				Sports = sports,
				Genders = genders,
				AgeRanges = ageRanges,
				Schedules = schedules,
				SportsEvents = sportsEvents				

			};

			
            return View("CoachForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Coach coach)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CoachFormViewModel
                {
					Coach = coach,
					Locations = _context.Locations.ToList(),
					Sports = _context.Sports.ToList(),
					Genders = _context.Genders.ToList(),
					AgeRanges = _context.AgeRanges.ToList(),
					Schedules = _context.Schedules.ToList(),
					SportsEvents = _context.SportsEvents.ToList(),
				};

				Console.WriteLine(
				viewModel.Locations.First().Name + "," +
				viewModel.Sports.First().Name + "," +
				viewModel.Genders.First().Name + "," +
				viewModel.AgeRanges.First().Name + "," +
				viewModel.Schedules.First().Name + "," +
				viewModel.SportsEvents.First().Name
				);

				return View("CoachForm", viewModel);
            }
			else
			{
				Console.WriteLine("ModelState is NOT Valid");
			}

            if (coach.Id == 0)
                _context.Coaches.Add(coach);
            else
            {
                var coachInDb = _context.Coaches.Single(c => c.Id == coach.Id);
                coachInDb.City = coach.City;
				coachInDb.State = coach.State;
				coachInDb.Street = coach.Street;
				coachInDb.Zip = coach.Zip;
				coachInDb.FirstName = coach.FirstName;
                coachInDb.LastName = coach.LastName;
                //coachInDb.AgeRanges = coach.AgeRanges;
                coachInDb.AgeRangesIds = coach.AgeRangesIds;
                //coachInDb.Genders = coach.Genders;
                coachInDb.GendersIds = coach.GendersIds;
                //coachInDb.Locations = coach.Locations;
                coachInDb.LocationsIds = coach.LocationsIds;
                //coachInDb.Schedules = coach.Schedules;
                coachInDb.SchedulesIds = coach.SchedulesIds;
                //coachInDb.Sports = coach.Sports;
                coachInDb.SportsIds = coach.SportsIds;
                coachInDb.SportsEventsIds = coach.SportsEventsIds;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Coaches");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var coach = _context.Coaches.SingleOrDefault(c => c.Id == id);

            if (coach == null)
                return HttpNotFound();

            return View(coach);
        }

        public ActionResult Edit(int id)
        {
            var coach = _context.Coaches.SingleOrDefault(c => c.Id == id);

            if (coach == null)
                return HttpNotFound();

            var viewModel = new CoachFormViewModel
            {
                Coach = coach,
				Locations = _context.Locations.ToList(),
				Sports = _context.Sports.ToList(),
				Genders = _context.Genders.ToList(),
				AgeRanges = _context.AgeRanges.ToList(),
				Schedules = _context.Schedules.ToList(),
				SportsEvents = _context.SportsEvents.ToList(),

			};

            return View("CoachForm", viewModel);
        }
    }
}