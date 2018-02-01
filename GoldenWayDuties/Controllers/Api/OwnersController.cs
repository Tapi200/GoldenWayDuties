using AutoMapper;
using GoldenWayDuties.Dtos;
using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoldenWayDuties.Controllers.Api
{
    public class OwnersController : ApiController
    {
        private ApplicationDbContext _context;

        public OwnersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/owners
        public IHttpActionResult GetOwners()
        {
            var ownerDtos = _context.Owners.ToList().Select(Mapper.Map<Owner, OwnerDto>);

            return Ok(ownerDtos);
        } 

        // GET /api/owners/1

        public IHttpActionResult GetOwner(int id)
        {
            var owner = _context.Owners.SingleOrDefault(o => o.Id == id);

            if (owner == null)
                return NotFound();

            return Ok(Mapper.Map<Owner, OwnerDto>(owner));
        }

        // POST /api/owner
        [HttpPost]
        public IHttpActionResult CreateOwner(OwnerDto ownerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var owner = Mapper.Map<OwnerDto, Owner>(ownerDto);
            _context.Owners.Add(owner);
            _context.SaveChanges();

            ownerDto.Id = owner.Id;
            return Created(new Uri(Request.RequestUri + "/" + owner.Id),ownerDto); //return the url
        }

        // PUT /api/owners/1
        [HttpPut]
        public IHttpActionResult UpdateOwner(int id, OwnerDto ownerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ownerInDb = _context.Owners.SingleOrDefault(o => o.Id == id);

            if (ownerInDb == null)
               return NotFound();

            Mapper.Map(ownerDto, ownerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/owner/1
        [HttpDelete]
        public IHttpActionResult DeleteOwner(int id)
        {
            var ownerInDb = _context.Owners.SingleOrDefault(o => o.Id == id);

            if (ownerInDb == null)
                return NotFound();

            _context.Owners.Remove(ownerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
