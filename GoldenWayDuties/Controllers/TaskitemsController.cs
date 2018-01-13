using GoldenWayDuties.Models;
using GoldenWayDuties.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenWayDuties.Controllers
{
    public class TaskitemsController : Controller
    {
        private ApplicationDbContext _context;

        public TaskitemsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Tasks/Random
        public ActionResult Index()
        {
            var taskitem = _context.Taskitems.Include(c => c.Genre).ToList();
            return View(taskitem);
        }

        public ActionResult Details(int id)
        {
            var taskitem = _context.Taskitems.Include(c=> c.Genre).SingleOrDefault(i => i.Id == id);

            if (taskitem == null)
                return HttpNotFound();

            return View(taskitem);
        }

        //public IEnumerable<Taskitem> GetTaskitems()
        //{
        //    return new List<Taskitem>
        //    {
        //        new Taskitem{Name ="Gardening", Id = 1},
        //        new Taskitem{Name ="Cooking", Id = 2},
        //        new Taskitem{Name ="Floor cleaning", Id = 3},
        //        new Taskitem{Name ="Washing", Id = 4},
        //        new Taskitem{Name = "Other", Id = 5}
        //    };
        //}

        public ActionResult Random()
        {
            var taskitem = new Taskitem() { Name = "Gardening" };

            var owners = _context.Owners.ToList();
            //var owners = new List<Owner> {
            //    new Owner {Name = "Tapiwa"},
            //    new Owner {Name = "Memory"},
            //    new Owner {Name = "Monalisa"},
            //    new Owner {Name = "Tapson"},
            //    new Owner {Name = "Melissa"}
            //};

            var viewModel = new RandomTaskitemViewModel
            {
                Taskitem = taskitem,
                Owners = owners
            };

            return View(viewModel);
        }

    }
}