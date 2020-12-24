using RaidBugTracker.Models;
using System;
using System.Linq;

namespace RaidBugTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(RaidContext context)
        {
            // Create database if it doesn't already exist
            context.Database.EnsureCreated();

            // Check to see if the database has already been
            // seeded; if it has, no need to proceed with the
            // seeding in this method.
            if (context.BugPage.Any())
            {
                return;
            }

            // Initialize bug pages
            var bugPages = new BugPage[]
            {
                new BugPage{ID = 1, Name = "MVC issues", Description = "Add MVC methods to active recall document", Priority = 3, Status = "Open"},
                new BugPage{ID = 2, Name = "Algorithms practice", Description = "Create schedule for practicing with LeetCode", Priority = 5, Status = "Open"},
                new BugPage{ID = 3, Name = "Order pull-up station", Description = "Need to order pull-up station as soon as next paycheck comes in", Priority = 2, Status = "Open"},
                new BugPage{ID = 4, Name = "Begin bug tracker", Description = "Start writing bug tracker in C#", Priority = 5, Status = "In progress"}
            };

            foreach (BugPage bp in bugPages)
            {
                context.Add(bp);
            }

            context.SaveChanges();

            // Initialize users
            var users = new User[]
            {
                new User{ID = 1, FirstName = "Spencer", LastName = "Hall", Role = "Administrator"},
                new User{ID = 2, FirstName = "Mimi", LastName = "Ackleh", Role = "Staff Engineer"},
                new User{ID = 3, FirstName = "Emily", LastName = "Dardaman", Role = "Staff Engineer"},
                new User{ID = 4, FirstName = "Eric", LastName = "Daniel", Role = "Tech Lead"},
                new User{ID = 5, FirstName = "Josh", LastName = "Maddox", Role = "Tech Lead"},
                new User{ID = 6, FirstName = "Lauren", LastName = "Ackleh", Role = "Staff Engineer"}
            };

            foreach (User user in users)
            {
                context.Add(user);
            }

            context.SaveChanges();

            // Initialize projects
            var projects = new Project[]
            {
                new Project{ID = 1, Name = "Learning C#, .NET, and MVC"},
                new Project{ID = 2, Name = "Moving to Atlanta"}
            };

            foreach (Project project in projects)
            {
                context.Add(project);
            }

            context.SaveChanges();

            // Initialize projectuser
            var projectusers = new ProjectUser[]
            {
                new ProjectUser{UserID = 1, ProjectID = 1, IsCreator = true},
                new ProjectUser{UserID = 2, ProjectID = 1, IsCreator = false}
            };

            foreach (ProjectUser projectuser in projectusers)
            {
                context.Add(projectuser);
            }

            context.SaveChanges();

            // Initialize userbugpage
            var userbugpages = new UserBugPage[]
            {
                new UserBugPage{UserID = 3, BugPageID = 4},
                new UserBugPage{UserID = 6, BugPageID = 2}
            };

            foreach (UserBugPage userbugpage in userbugpages)
            {
                context.Add(userbugpage);
            };

            context.SaveChanges();

            // Initialize projectbugpage
            var projectbugpages = new ProjectBugPage[]
            {
                new ProjectBugPage{ProjectID = 1, BugPageID = 1},
                new ProjectBugPage{ProjectID = 2, BugPageID = 2}
            };

            foreach (ProjectBugPage projectbugpage in projectbugpages)
            {
                context.Add(projectbugpage);
            }

            context.SaveChanges();
        }
    }
}
