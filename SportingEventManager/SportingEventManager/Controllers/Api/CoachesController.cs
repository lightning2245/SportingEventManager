using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    public class CoachesController : ApiController
    {
        private ApplicationDbContext _context;

        public CoachesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/coaches
        public IHttpActionResult GetCoaches(string query = null)
        {
			var coachesQuery = _context.Coaches.ToList();
                //.Include(c => c.AgeRanges)
                //.Include(c => c.Genders)
                //.Include(c => c.Locations)
                //.Include(c => c.Schedules)
                //.Include(c => c.Sports)
                //.Include(c => c.SportsEvents);
                

            if (!String.IsNullOrWhiteSpace(query))
                coachesQuery = coachesQuery.Where(c => c.FirstName + " " + c.LastName == query).ToList();

            var coachDtos = coachesQuery
                .ToList()
                .Select(Mapper.Map<Coach, CoachDto>);

            return Ok(coachDtos);
        }

        // GET /api/coaches/1
        public IHttpActionResult GetCoach(int id)
        {
            var coach = _context.Coaches.SingleOrDefault(c => c.Id == id);

            if (coach == null)
                return NotFound();

            return Ok(Mapper.Map<Coach, CoachDto>(coach));
        }

        // POST /api/coaches
        [HttpPost]
        public IHttpActionResult CreateCoach(CoachDto coachDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coach = Mapper.Map<CoachDto, Coach>(coachDto);
            _context.Coaches.Add(coach);
            _context.SaveChanges();

            coachDto.Id = coach.Id;
            return Created(new Uri(Request.RequestUri + "/" + coach.Id), coachDto);
        }

        // PUT /api/coaches/1
        [HttpPut]
        public IHttpActionResult UpdateCoach(int id, CoachDto coachDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coachInDb = _context.Coaches.SingleOrDefault(c => c.Id == id);

            if (coachInDb == null)
                return NotFound();

            Mapper.Map(coachDto, coachInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/coaches/1
        [HttpDelete]
        public IHttpActionResult DeleteCoach(int id)
        {
            var coachInDb = _context.Coaches.SingleOrDefault(c => c.Id == id);

            if (coachInDb == null)
                return NotFound();

            _context.Coaches.Remove(coachInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
