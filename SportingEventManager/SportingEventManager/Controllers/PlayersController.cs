using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;
using System;
using System.Diagnostics;


namespace SportingEventManager.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext _context;

        public PlayersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
			var guardians = _context.Guardians.ToList();
			var genders = _context.Genders.ToList();
			var sportsEvents = _context.SportsEvents.ToList();

			var viewModel = new PlayerFormViewModel
            {
                Player = new Player(),
				Guardians = guardians,
				Genders = genders,
				SportsEvents = sportsEvents
			};

            return View("PlayerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Player player)
        {
            if (!ModelState.IsValid)
            {
				var viewModel = new PlayerFormViewModel
				{
					Player = player,
					Guardians = _context.Guardians.ToList(),
					Genders = _context.Genders.ToList(),
					SportsEvents = _context.SportsEvents.ToList()

				};

				//Console.WriteLine(
				//viewModel.Guardians.First().Name + "," +
				//viewModel.Genders.First().Name + "," +
				//viewModel.SportsEvents.First().Name
				//);

				return View("PlayerForm", viewModel);
            }

			if (player.Id == 0)
			{
				//int playId = player.Id;				

				_context.Players.Add(player);
			}
			else
			{
				var playerInDb = _context.Players.Single(c => c.Id == player.Id);
				playerInDb.Birthdate = player.Birthdate;
				playerInDb.City = player.City;
				playerInDb.Zip = player.Zip;
				playerInDb.Street = player.Street;
				playerInDb.FirstName = player.FirstName;
				//playerInDb.Guardians = player.Guardians;
				playerInDb.GuardiansIds = player.GuardiansIds;
				playerInDb.LastName = player.LastName;
				playerInDb.GenderId = player.GenderId;
				//playerInDb.SportsEvents = player.SportsEvents;
				playerInDb.SportsEventsIds = player.SportsEventsIds;
				playerInDb.State = player.State;
			}

			try
			{
				// Your code...
				// Could also be before try if you know the exception occurs in SaveChanges

				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Debug.Write("Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + " has the following validation errors:");
					foreach (var ve in eve.ValidationErrors)
					{
						Debug.Write("- Property: " + ve.PropertyName + ", Value: " + eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName) + ", Error: " + ve.ErrorMessage);							
					}
				}
				throw;
			}

			return RedirectToAction("Index", "Players");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var player = _context.Players
				.Include(c=> c.Gender).SingleOrDefault(c => c.Id == id);

            if (player == null)
                return HttpNotFound();

            return View(player);
        }

        public ActionResult Edit(int id)
        {
            var player = _context.Players.SingleOrDefault(c => c.Id == id);

            if (player == null)
                return HttpNotFound();

            var viewModel = new PlayerFormViewModel
            {
                Player = player,
				Guardians = _context.Guardians.ToList(),
				Genders = _context.Genders.ToList(),
				SportsEvents = _context.SportsEvents.ToList()

			};

            return View("PlayerForm", viewModel);
        }
    }
}