using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaidBugTracker.Models
{
    public class BugPage
    {
        // Properties
        [Display(Name = "Ticket Number")]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int Priority { get; set; }

        // Navigation properties
        public IEnumerable<UserBugPage> UserBugPages { get; set; }
        public IEnumerable<ProjectBugPage> ProjectBugPages { get; set; }
    }
}
