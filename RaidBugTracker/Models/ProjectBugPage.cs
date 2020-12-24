using System;
namespace RaidBugTracker.Models
{
    public class ProjectBugPage
    {
        public int ProjectID { get; set; }
        public int BugPageID { get; set; }
        public Project Project { get; set; }
        public BugPage BugPage { get; set; }
    }
}
