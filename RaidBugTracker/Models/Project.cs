using System;
using System.Collections.Generic;

namespace RaidBugTracker.Models
{
    public class Project
    {
        // Properties
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public IEnumerable<ProjectUser> ProjectUsers { get; set; }
        public IEnumerable<ProjectBugPage> ProjectBugPages { get; set; }
    }
}
