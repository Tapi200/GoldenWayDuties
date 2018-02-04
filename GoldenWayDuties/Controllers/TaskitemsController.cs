using GoldenWayDuties.Models;
using GoldenWayDuties.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

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
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new TaskitemFormViewModel()
            {
                Genres = genre
            };

            return View("TaskitemForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var taskitem = _context.Taskitems.SingleOrDefault(i => i.Id == id);

            if (taskitem == null)
                return HttpNotFound();

            var viewModel = new TaskitemFormViewModel(taskitem)
            {
                Genres = _context.Genre.ToList()
            };

            return View("TaskitemForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var taskitem = _context.Taskitems.Include(c=> c.Genre).SingleOrDefault(i => i.Id == id);

            if (taskitem == null)
                return HttpNotFound();

            return View(taskitem);
        }

        //GET: Taskitems/Random
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Taskitem taskitem)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TaskitemFormViewModel(taskitem)
                {
                    Genres = _context.Genre.ToList()
                };
                return View("TaskitemForm", viewModel);
            }

            if(taskitem.Id == 0)
                _context.Taskitems.Add(taskitem);
            else
            {
                var taskitemInDb = _context.Taskitems.Single(i => i.Id == taskitem.Id);
                taskitemInDb.Name = taskitem.Name;
                taskitemInDb.StartDate = taskitem.StartDate;
                taskitemInDb.DateAdded = taskitem.DateAdded;
                taskitemInDb.Genre = taskitem.Genre;
            }

            try
            {
                _context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Taskitems");
        }

    }
}