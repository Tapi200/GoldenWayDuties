using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GoldenWayDuties.Models;
using System.Web.Http;
using System.Net;
using GoldenWayDuties.Dtos;
using AutoMapper;

namespace GoldenWayDuties.Controllers.Api
{
    public class TaskitemsController : ApiController
    {
        private ApplicationDbContext _context;

        public TaskitemsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /Api/taskitems
        public IHttpActionResult GetTaskitems()
        {
            var taskitemDtos = _context.Taskitems.ToList().Select(Mapper.Map<Taskitem, TaskitemDto>);

            return Ok(taskitemDtos);
        }
        
        // GET /api/taskitem/1
        public IHttpActionResult GetTaskitem(int id)
        {
            var taskitem = _context.Taskitems.SingleOrDefault(i => i.Id == id);

            if (taskitem == null)
                return NotFound();

            return Ok(Mapper.Map<Taskitem, TaskitemDto>(taskitem));
        }

        // POST /api/taskitems
        [HttpPost]
        public IHttpActionResult CreateTaskItem(TaskitemDto taskitemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var taskitem = Mapper.Map<TaskitemDto, Taskitem>(taskitemDto);
            _context.Taskitems.Add(taskitem);
            _context.SaveChanges();

            taskitemDto.Id = taskitem.Id;

            return Created(new Uri(Request.RequestUri + "/" + taskitem.Id), taskitemDto);
        }

        // PUT /api/taskitems/id==1
        [HttpPut]
        public IHttpActionResult UpdateTaskitem(int id, TaskitemDto taskitemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var taskitemInDb = _context.Taskitems.SingleOrDefault(i => i.Id == id);

            if (taskitemInDb == null)
                return NotFound();

            Mapper.Map(taskitemDto, taskitemInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        //DELETE /api/taskitems/id==1
        public IHttpActionResult DeleteTaskitem(int id)
        {
            var taskitemInDb = _context.Taskitems.SingleOrDefault(t => t.Id == id);

            if (taskitemInDb == null)
                return NotFound();

            _context.Taskitems.Remove(taskitemInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}