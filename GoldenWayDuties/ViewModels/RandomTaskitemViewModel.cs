using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.ViewModels
{
    public class RandomTaskitemViewModel
    {
        public Taskitem Taskitem { get; set; }
        public List<Owner> Owners{ get; set; }

    }
}