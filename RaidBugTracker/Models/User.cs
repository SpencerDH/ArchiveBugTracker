using System;
using System.Collections.Generic;

namespace RaidBugTracker.Models
{
    public class User
    {
        // Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        // Navigation properties
        public IEnumerable<UserBugPage> UserBugPages { get; set; }
        public IEnumerable<ProjectUser> ProjectUsers { get; set; }
    }
}
