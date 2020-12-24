using System;
using System.Collections.Generic;

namespace RaidBugTracker.Models
{
    public class ProjectUser
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        // Property determines what permissions user has on project
        public bool IsCreator { get; set; }
    }
}
