using System;
namespace RaidBugTracker.Models
{
    public class UserBugPage
    {
        public int UserID { get; set; }
        public int BugPageID { get; set; }
        public User User { get; set; }
        public BugPage BugPage { get; set; }

        // Property determines what permissions user has on bug
        public bool IsCreator { get; set; }
    }
}
