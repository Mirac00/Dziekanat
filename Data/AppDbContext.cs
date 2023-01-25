using Dziekanat.Models;
using Microsoft.EntityFrameworkCore;

namespace Dziekanat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Models.Instructor> Instructors { get; set; } = default!;
        public DbSet<Models.Enrollment> Enrollements { get; set; } = default!;
        public DbSet<Models.Course> Courses { get; set; } = default!;
        public DbSet<Models.Student> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollements)
                .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollements)
                .HasForeignKey(e => e.CourseId);

            base.OnModelCreating(modelBuilder);
        }
        /* do uzupełnienia */
    }
}
