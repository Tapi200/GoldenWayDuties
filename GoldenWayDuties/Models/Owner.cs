using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsHouseResident { get; set; }
        public ResidentType ResidentType { get; set; } //navigation property. Allows us to navigate from one type to another
        public byte ResidentTypeId { get; set; } // foreign key. useful for optimisation when you do not need to load the entire ResidentType object
    }
}