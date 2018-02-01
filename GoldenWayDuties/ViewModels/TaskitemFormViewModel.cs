using GoldenWayDuties.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.ViewModels
{
    public class TaskitemFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0? "Edit Taskitem": "New Taskitem";
            }
        }

        public TaskitemFormViewModel()
        {
            Id = 0;
        }
        public TaskitemFormViewModel(Taskitem taskitem)
        {
            Id = taskitem.Id;
            Name = taskitem.Name;
            StartDate = taskitem.StartDate;
            GenreId = taskitem.GenreId;
        }
    }
}