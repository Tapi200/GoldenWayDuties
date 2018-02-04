using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.Dtos
{
    public class OwnerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Owner name")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min20YearsIfParent]
        public DateTime? DateOfBirth { get; set; }

        public bool IsHouseResident { get; set; }

        public byte ResidentTypeId { get; set; }

        public ResidentTypeDto ResidentType { get; set; }
    }
}