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
    public class AgeRangesController : ApiController
    {
        private ApplicationDbContext _context;

        public AgeRangesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/ageRanges
        public IHttpActionResult GetAgeRanges(string query = null)
        {
			var ageRangesQuery = _context.AgeRanges.ToList();
				//.Include(m => m.Coaches)
				//.Include(m => m.SportsEvents);

			if (!String.IsNullOrWhiteSpace(query))
                ageRangesQuery = ageRangesQuery.Where(c => c.Min.ToString() + " to " + c.Max.ToString() == query).ToList();

            var ageRangeDtos = ageRangesQuery
                .ToList()
                .Select(Mapper.Map<AgeRange, AgeRangeDto>);

            return Ok(ageRangeDtos);
        }

        // GET /api/ageRanges/1
        public IHttpActionResult GetAgeRange(int id)
        {
            var ageRange = _context.AgeRanges.SingleOrDefault(c => c.Id == id);

            if (ageRange == null)
                return NotFound();

            return Ok(Mapper.Map<AgeRange, AgeRangeDto>(ageRange));
        }

        // POST /api/ageRanges
        [HttpPost]
        public IHttpActionResult CreateAgeRange(AgeRangeDto ageRangeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ageRange = Mapper.Map<AgeRangeDto, AgeRange>(ageRangeDto);
            _context.AgeRanges.Add(ageRange);
            _context.SaveChanges();

            ageRangeDto.Id = ageRange.Id;
            return Created(new Uri(Request.RequestUri + "/" + ageRange.Id), ageRangeDto);
        }

        // PUT /api/ageRanges/1
        [HttpPut]
        public IHttpActionResult UpdateAgeRange(int id, AgeRangeDto ageRangeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ageRangeInDb = _context.AgeRanges.SingleOrDefault(c => c.Id == id);

            if (ageRangeInDb == null)
                return NotFound();

            Mapper.Map(ageRangeDto, ageRangeInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/ageRanges/1
        [HttpDelete]
        public IHttpActionResult DeleteAgeRange(int id)
        {
            var ageRangeInDb = _context.AgeRanges.SingleOrDefault(c => c.Id == id);

            if (ageRangeInDb == null)
                return NotFound();

            _context.AgeRanges.Remove(ageRangeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
