using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    public class LocationsController : ApiController
    {
        private ApplicationDbContext _context;

        public LocationsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/locations
        public IHttpActionResult GetLocations(string query = null)
        {
			var locationsQuery = _context.Locations.ToList();
                //.Include(c => c.Coaches)
                //.Include(c => c.SportsEvents);
                
            if (!String.IsNullOrWhiteSpace(query))
                locationsQuery = locationsQuery.Where(c => c.City + ", " + c.State == query).ToList();

            var locationDtos = locationsQuery
                .ToList()
                .Select(Mapper.Map<Location, LocationDto>);

            return Ok(locationDtos);
        }

        // GET /api/locations/1
        public IHttpActionResult GetLocation(int id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (location == null)
                return NotFound();

            return Ok(Mapper.Map<Location, LocationDto>(location));
        }

        // POST /api/locations
        [HttpPost]
        public IHttpActionResult CreateLocation(LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var location = Mapper.Map<LocationDto, Location>(locationDto);
            _context.Locations.Add(location);
            _context.SaveChanges();

            locationDto.Id = location.Id;
            return Created(new Uri(Request.RequestUri + "/" + location.Id), locationDto);
        }

        // PUT /api/locations/1
        [HttpPut]
        public IHttpActionResult UpdateLocation(int id, LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var locationInDb = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (locationInDb == null)
                return NotFound();

            Mapper.Map(locationDto, locationInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/locations/1
        [HttpDelete]
        public IHttpActionResult DeleteLocation(int id)
        {
            var locationInDb = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (locationInDb == null)
                return NotFound();

            _context.Locations.Remove(locationInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
