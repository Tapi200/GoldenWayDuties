using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GoldenWayDuties.Models;

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

        public ActionResult Index()
        {
            var owners = _context.Owners.Include(c => c.ResidentType).ToList();
            return View(owners);
        }

        public ActionResult Details(int id)
        {
            var owner = _context.Owners.Include(c => c.ResidentType).SingleOrDefault(c => c.Id == id);

            if (owner == null)
                return HttpNotFound();

            return View(owner);
        }
    }
}