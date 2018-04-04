using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SportingEventManager.Models;
using SportingEventManager.ViewModels;

namespace SportingEventManager.Controllers
{
    public class SchedulesController : Controller
    {
        private ApplicationDbContext _context;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            
            var viewModel = new ScheduleFormViewModel
            {
                Schedule = new Schedule(),
				Coaches = _context.Coaches.ToList()
                
            };

            return View("ScheduleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ScheduleFormViewModel
                {
                    Schedule = schedule,
					Coaches = _context.Coaches.ToList()

				};

                return View("ScheduleForm", viewModel);
            }

            if (schedule.Id == 0)
                _context.Schedules.Add(schedule);
            else
            {
                var scheduleInDb = _context.Schedules.Single(c => c.Id == schedule.Id);
                scheduleInDb.Name = schedule.Name;
                scheduleInDb.Coaches = schedule.Coaches;
                scheduleInDb.CoachesIds = schedule.CoachesIds;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Schedules");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(c => c.Id == id);

            if (schedule == null)
                return HttpNotFound();

            return View(schedule);
        }

        public ActionResult Edit(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(c => c.Id == id);

            if (schedule == null)
                return HttpNotFound();

            var viewModel = new ScheduleFormViewModel
            {
                Schedule = schedule,
				Coaches = _context.Coaches.ToList()

			};

            return View("ScheduleForm", viewModel);
        }
    }
}