using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    [Authorize]
    public class SportsController : ApiController
    {
        private ApplicationDbContext _context;

        public SportsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/sports
        public IHttpActionResult GetSports(string query = null)
        {
			var sportsQuery = _context.Sports.ToList();
                //.Include(c => c.Coaches);
                

            if (!String.IsNullOrWhiteSpace(query))
                sportsQuery = sportsQuery.Where(c => c.Name.Contains(query)).ToList();

            var sportDtos = sportsQuery
                .ToList()
                .Select(Mapper.Map<Sport, SportDto>);

            return Ok(sportDtos);
        }

        // GET /api/sports/1
        public IHttpActionResult GetSport(int id)
        {
            var sport = _context.Sports.SingleOrDefault(c => c.Id == id);

            if (sport == null)
                return NotFound();

            return Ok(Mapper.Map<Sport, SportDto>(sport));
        }

        // POST /api/sports
        [HttpPost]
        public IHttpActionResult CreateSport(SportDto sportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sport = Mapper.Map<SportDto, Sport>(sportDto);
            _context.Sports.Add(sport);
            _context.SaveChanges();

            sportDto.Id = sport.Id;
            return Created(new Uri(Request.RequestUri + "/" + sport.Id), sportDto);
        }

        // PUT /api/sports/1
        [HttpPut]
        public IHttpActionResult UpdateSport(int id, SportDto sportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sportInDb = _context.Sports.SingleOrDefault(c => c.Id == id);

            if (sportInDb == null)
                return NotFound();

            Mapper.Map(sportDto, sportInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/sports/1
        [HttpDelete]
        public IHttpActionResult DeleteSport(int id)
        {
            var sportInDb = _context.Sports.SingleOrDefault(c => c.Id == id);

            if (sportInDb == null)
                return NotFound();

            _context.Sports.Remove(sportInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
