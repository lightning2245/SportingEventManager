using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    public class SchedulesController : ApiController
    {
        private ApplicationDbContext _context;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/schedules
        public IHttpActionResult GetSchedules(string query = null)
        {
			var schedulesQuery = _context.Schedules.ToList();
                //.Include(c => c.Coaches);
                
            if (!String.IsNullOrWhiteSpace(query))
                schedulesQuery = schedulesQuery.Where(c => c.Name.Contains(query)).ToList();

            var scheduleDtos = schedulesQuery
                .ToList()
                .Select(Mapper.Map<Schedule, ScheduleDto>);

            return Ok(scheduleDtos);
        }

        // GET /api/schedules/1
        public IHttpActionResult GetSchedule(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(c => c.Id == id);

            if (schedule == null)
                return NotFound();

            return Ok(Mapper.Map<Schedule, ScheduleDto>(schedule));
        }

        // POST /api/schedules
        [HttpPost]
        public IHttpActionResult CreateSchedule(ScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var schedule = Mapper.Map<ScheduleDto, Schedule>(scheduleDto);
            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            scheduleDto.Id = schedule.Id;
            return Created(new Uri(Request.RequestUri + "/" + schedule.Id), scheduleDto);
        }

        // PUT /api/schedules/1
        [HttpPut]
        public IHttpActionResult UpdateSchedule(int id, ScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var scheduleInDb = _context.Schedules.SingleOrDefault(c => c.Id == id);

            if (scheduleInDb == null)
                return NotFound();

            Mapper.Map(scheduleDto, scheduleInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/schedules/1
        [HttpDelete]
        public IHttpActionResult DeleteSchedule(int id)
        {
            var scheduleInDb = _context.Schedules.SingleOrDefault(c => c.Id == id);

            if (scheduleInDb == null)
                return NotFound();

            _context.Schedules.Remove(scheduleInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
