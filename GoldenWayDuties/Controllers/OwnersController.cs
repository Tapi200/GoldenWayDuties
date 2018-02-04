using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GoldenWayDuties.Models;
using GoldenWayDuties.ViewModels;

namespace GoldenWayDuties.Controllers
{
    public class OwnersController : Controller
    {
        private ApplicationDbContext _context;

        public OwnersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }

        public ActionResult New()
        {
            var residentTypes = _context.ResidentTypes.ToList();
            var viewModel = new OwnerFormViewModel
            {
                Owner = new Owner(),
                ResidentTypes = residentTypes
            };
            
            return View("OwnerForm",viewModel);
        }

        [HttpPost] //since Action is to modify data, this ensure it's not accessible via HttpGet
        [ValidateAntiForgeryToken]
        public ActionResult Save(Owner owner)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new OwnerFormViewModel
                {
                    Owner = owner,
                    ResidentTypes = _context.ResidentTypes.ToList()
                };

                return View("OwnerForm", viewModel);
            }

            if (owner.Id == 0)
                _context.Owners.Add(owner);
            else
            {
                var ownerInDb = _context.Owners.Single(o => o.Id == owner.Id);

                ownerInDb.Name = owner.Name;
                ownerInDb.DateOfBirth = owner.DateOfBirth;
                ownerInDb.ResidentTypeId = owner.ResidentTypeId;
                ownerInDb.IsHouseResident = owner.IsHouseResident;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Owners");

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var owner = _context.Owners.Include(c => c.ResidentType).SingleOrDefault(c => c.Id == id);

            if (owner == null)
                return HttpNotFound();

            return View(owner);
        }

        public ActionResult Edit(int id)
        {
            var owner = _context.Owners.SingleOrDefault(o => o.Id == id);

            if (owner == null)
                return HttpNotFound();

            var viewModel = new OwnerFormViewModel
            {
                Owner = owner,
                ResidentTypes = _context.ResidentTypes.ToList()
            };
            return View("OwnerForm", viewModel);
        }
    }
}