using System;
using RaidBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace RaidBugTracker.Data
{
    public class RaidContext : DbContext
    {
        public RaidContext(DbContextOptions<RaidContext> options) : base(options)
        {
        }

        public DbSet<BugPage> BugPage { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBugPage> UserBugPage { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectUser> ProjectUser { get; set; }
        public DbSet<ProjectBugPage> ProjectBugPage { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectBugPage>()
                .HasKey(pbp => new { pbp.ProjectID, pbp.BugPageID });

            modelBuilder.Entity<UserBugPage>()
                .HasKey(ubp => new { ubp.UserID, ubp.BugPageID });

            modelBuilder.Entity<ProjectUser>()
                .HasKey(pu => new { pu.ProjectID, pu.UserID });
        }
    }
}
