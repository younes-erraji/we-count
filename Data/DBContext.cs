using System;
using Microsoft.EntityFrameworkCore;

using WeCount.Models;

namespace WeCount.Data
{
    public class _DBContext : DbContext
    {
        public _DBContext() { }
        public _DBContext(DbContextOptions<_DBContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    Id = 1,
                    FirstName = "Younes",
                    LastName = "ERRAJI",
                    Slag = $"younes-erraji-{DateTime.Now.GetHashCode()}",
                    Mail = "younes-erraji@mail.com",
                    Phone = "0651656799",
                    StudyLevel = "Bac+2",
                    YearsOfExperinces = 1,
                    LastJob = "Software Enginner at Concepment S.a.r.l.",
                    Resume = null
                }
            );
        }
    }
}
