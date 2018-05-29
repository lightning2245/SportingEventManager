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
    public class GendersController : ApiController
    {
        private ApplicationDbContext _context;

        public GendersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/genders
        public IHttpActionResult GetGenders(string query = null)
        {
			var gendersQuery = _context.Genders.ToList();
                //.Include(c => c.Coaches);
                
            if (!String.IsNullOrWhiteSpace(query))
                gendersQuery = gendersQuery.Where(c => c.Name.Contains(query)).ToList();

            var genderDtos = gendersQuery
                .ToList()
                .Select(Mapper.Map<Gender, GenderDto>);

            return Ok(genderDtos);
        }

        // GET /api/genders/1
        public IHttpActionResult GetGender(int id)
        {
            var gender = _context.Genders.SingleOrDefault(c => c.Id == id);

            if (gender == null)
                return NotFound();

            return Ok(Mapper.Map<Gender, GenderDto>(gender));
        }

        // POST /api/genders
        [HttpPost]
        public IHttpActionResult CreateGender(GenderDto genderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gender = Mapper.Map<GenderDto, Gender>(genderDto);
            _context.Genders.Add(gender);
            _context.SaveChanges();

            genderDto.Id = gender.Id;
            return Created(new Uri(Request.RequestUri + "/" + gender.Id), genderDto);
        }

        // PUT /api/genders/1
        [HttpPut]
        public IHttpActionResult UpdateGender(int id, GenderDto genderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genderInDb = _context.Genders.SingleOrDefault(c => c.Id == id);

            if (genderInDb == null)
                return NotFound();

            Mapper.Map(genderDto, genderInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/genders/1
        [HttpDelete]
        public IHttpActionResult DeleteGender(int id)
        {
            var genderInDb = _context.Genders.SingleOrDefault(c => c.Id == id);

            if (genderInDb == null)
                return NotFound();

            _context.Genders.Remove(genderInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
