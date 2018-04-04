using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class GuardiansController : Controller
    {
        private ApplicationDbContext _context;

        public GuardiansController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {

			var viewModel = new GuardianFormViewModel
			{
				Guardian = new Guardian(),
				Players = _context.Players.ToList()
                
            };

            return View("GuardianForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Guardian guardian)
        {
            if (!ModelState.IsValid)
            {
				var viewModel = new GuardianFormViewModel
				{
					Guardian = guardian,
					Players = _context.Players.ToList()
                    
                };

                return View("GuardianForm", viewModel);
            }

            if (guardian.Id == 0)
                _context.Guardians.Add(guardian);
            else
            {
                var guardianInDb = _context.Guardians.Single(c => c.Id == guardian.Id);
                guardianInDb.City = guardian.City;
				guardianInDb.Zip = guardianInDb.Zip;
				guardianInDb.Street = guardianInDb.Street;
				guardianInDb.FirstName = guardian.FirstName;
                guardianInDb.LastName = guardian.LastName;
                //guardianInDb.Players = guardian.Players;
                guardianInDb.PlayersIds = guardian.PlayersIds;
                guardianInDb.State = guardian.State;               
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Guardians");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var guardian = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardian == null)
                return HttpNotFound();

            return View(guardian);
        }

        public ActionResult Edit(int id)
        {
            var guardian = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardian == null)
                return HttpNotFound();

			var viewModel = new GuardianFormViewModel
			{
				Guardian = guardian,
				Players = _context.Players.ToList()
                
            };

            return View("GuardianForm", viewModel);
        }
    }
}