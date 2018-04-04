using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    public class SportsEventsController : ApiController
    {
        private ApplicationDbContext _context;

        public SportsEventsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/sportsEvents
        public IHttpActionResult GetSportsEvents(string query = null)
        {
            var sportsEventsQuery = _context.SportsEvents
                .Include(c=> c.AgeRange)
                //.Include(c=> c.Coaches)
                .Include(c=> c.Gender)
                .Include(c=> c.Location)
                .Include(c=> c.Organizer)
                //.Include(c=> c.Players)
                .Include(c=> c.Schedule)
                .Include(c=> c.Sport);

            if (!String.IsNullOrWhiteSpace(query))
                sportsEventsQuery = sportsEventsQuery.Where(c => c.Name.Contains(query));

            var sportsEventDtos = sportsEventsQuery
                .ToList()
                .Select(Mapper.Map<SportsEvent, SportsEventDto>);

            return Ok(sportsEventDtos);
        }

        // GET /api/sportsEvents/1
        public IHttpActionResult GetSportsEvent(int id)
        {
            var sportsEvent = _context.SportsEvents.SingleOrDefault(c => c.Id == id);

            if (sportsEvent == null)
                return NotFound();

            return Ok(Mapper.Map<SportsEvent, SportsEventDto>(sportsEvent));
        }

        // POST /api/sportsEvents
        [HttpPost]
        public IHttpActionResult CreateSportsEvent(SportsEventDto sportsEventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sportsEvent = Mapper.Map<SportsEventDto, SportsEvent>(sportsEventDto);
            _context.SportsEvents.Add(sportsEvent);
            _context.SaveChanges();

            sportsEventDto.Id = sportsEvent.Id;
            return Created(new Uri(Request.RequestUri + "/" + sportsEvent.Id), sportsEventDto);
        }

        // PUT /api/sportsEvents/1
        [HttpPut]
        public IHttpActionResult UpdateSportsEvent(int id, SportsEventDto sportsEventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sportsEventInDb = _context.SportsEvents.SingleOrDefault(c => c.Id == id);

            if (sportsEventInDb == null)
                return NotFound();

            Mapper.Map(sportsEventDto, sportsEventInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/sportsEvents/1
        [HttpDelete]
        public IHttpActionResult DeleteSportsEvent(int id)
        {
            var sportsEventInDb = _context.SportsEvents.SingleOrDefault(c => c.Id == id);

            if (sportsEventInDb == null)
                return NotFound();

            _context.SportsEvents.Remove(sportsEventInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
