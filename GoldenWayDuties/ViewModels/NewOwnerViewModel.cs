using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.ViewModels
{
    public class OwnerFormViewModel
    {
        public IEnumerable<ResidentType> ResidentTypes { get; set; }
        public Owner Owner { get; set; }

    }
}

