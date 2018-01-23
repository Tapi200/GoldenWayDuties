using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.ViewModels
{
    public class TaskitemFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Taskitem Taskitem { get; set; }
        public string Title
        {
            get
            {
                if (Taskitem != null && Taskitem.Id != 0)
                    return "Edit Movie";

                return "New Moview";
            }
        }
    }
}