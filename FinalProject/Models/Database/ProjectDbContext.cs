using FinalProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace FinalProject.Models.Database
{
    public sealed class ProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginHistory> Logins { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
            //ChangeTracker.AutoDetectChangesEnabled = false;
            //Database.AutoTransactionsEnabled = false;
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
