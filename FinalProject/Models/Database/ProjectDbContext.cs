using FinalProject.Models.Entities;
using FinalProject.Models.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
namespace FinalProject.Models.Database
{
    public sealed class ProjectDbContext : DbContext
    {
        #region StandardTask
        public DbSet<User> Users { get; set; }
        public DbSet<LoginHistory> Logins { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        #endregion
        #region ManyToMany
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        #endregion
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
            //ChangeTracker.AutoDetectChangesEnabled = false;
            //Database.AutoTransactionsEnabled = false;
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);


            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
