using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    public class OrganizersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrganizersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/organizers
        public IHttpActionResult GetOrganizers(string query = null)
        {
			var organizersQuery = _context.Organizers.ToList();
                //.Include(c => c.SportsEvents);
                
            if (!String.IsNullOrWhiteSpace(query))
                organizersQuery = organizersQuery.Where(c => c.FirstName + " " + c.LastName == query).ToList();            

            var organizerDtos = organizersQuery
                .ToList()
                .Select(Mapper.Map<Organizer, OrganizerDto>);

            return Ok(organizerDtos);
        }

        // GET /api/organizers/1
        public IHttpActionResult GetOrganizer(int id)
        {
            var organizer = _context.Organizers.SingleOrDefault(c => c.Id == id);

            if (organizer == null)
                return NotFound();

            return Ok(Mapper.Map<Organizer, OrganizerDto>(organizer));
        }

        // POST /api/organizers
        [HttpPost]
        public IHttpActionResult CreateOrganizer(OrganizerDto organizerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var organizer = Mapper.Map<OrganizerDto, Organizer>(organizerDto);
            _context.Organizers.Add(organizer);
            _context.SaveChanges();

            organizerDto.Id = organizer.Id;
            return Created(new Uri(Request.RequestUri + "/" + organizer.Id), organizerDto);
        }

        // PUT /api/organizers/1
        [HttpPut]
        public IHttpActionResult UpdateOrganizer(int id, OrganizerDto organizerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var organizerInDb = _context.Organizers.SingleOrDefault(c => c.Id == id);

            if (organizerInDb == null)
                return NotFound();

            Mapper.Map(organizerDto, organizerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/organizers/1
        [HttpDelete]
        public IHttpActionResult DeleteOrganizer(int id)
        {
            var organizerInDb = _context.Organizers.SingleOrDefault(c => c.Id == id);

            if (organizerInDb == null)
                return NotFound();

            _context.Organizers.Remove(organizerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
