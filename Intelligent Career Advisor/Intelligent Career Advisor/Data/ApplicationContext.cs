
using System.Reflection;

namespace Intelligent_Career_Advisor.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<JobApplication> JobApplications { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        //builder.Entity<ApplicationUser>(entity =>
        //{
        //    entity.ToTable("Users");
        //});
    }
}
