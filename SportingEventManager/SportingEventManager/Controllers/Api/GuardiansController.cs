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
    public class GuardiansController : ApiController
    {
        private ApplicationDbContext _context;

        public GuardiansController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/guardians
        public IHttpActionResult GetGuardians(string query = null)
        {
			var guardiansQuery = _context.Guardians.ToList();
                //.Include(c => c.Players);                

            if (!String.IsNullOrWhiteSpace(query))
                guardiansQuery = guardiansQuery.Where(c => c.FirstName + " " + c.LastName == query).ToList();
			
            var guardianDtos = guardiansQuery
                .ToList()
                .Select(Mapper.Map<Guardian, GuardianDto>);

            return Ok(guardianDtos);
        }

        // GET /api/guardians/1
        public IHttpActionResult GetGuardian(int id)
        {
            var guardian = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardian == null)
                return NotFound();

            return Ok(Mapper.Map<Guardian, GuardianDto>(guardian));
        }

        // POST /api/guardians
        [HttpPost]
        public IHttpActionResult CreateGuardian(GuardianDto guardianDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guardian = Mapper.Map<GuardianDto, Guardian>(guardianDto);
            _context.Guardians.Add(guardian);
            _context.SaveChanges();

            guardianDto.Id = guardian.Id;
            return Created(new Uri(Request.RequestUri + "/" + guardian.Id), guardianDto);
        }

        // PUT /api/guardians/1
        [HttpPut]
        public IHttpActionResult UpdateGuardian(int id, GuardianDto guardianDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guardianInDb = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardianInDb == null)
                return NotFound();

            Mapper.Map(guardianDto, guardianInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/guardians/1
        [HttpDelete]
        public IHttpActionResult DeleteGuardian(int id)
        {
            var guardianInDb = _context.Guardians.SingleOrDefault(c => c.Id == id);

            if (guardianInDb == null)
                return NotFound();

            _context.Guardians.Remove(guardianInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
