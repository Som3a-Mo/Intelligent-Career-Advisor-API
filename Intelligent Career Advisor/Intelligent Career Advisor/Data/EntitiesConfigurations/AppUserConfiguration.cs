using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent_Career_Advisor.Data.EntitiesConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.Property(x => x.Gender).HasConversion<string>();
        builder.OwnsMany(x => x.RefreshTokens)
            .ToTable("RefreshTokens")
            .WithOwner()
            .HasForeignKey("UserId");

        builder.Property(x => x.FullName).HasMaxLength(100);

        builder
                  .HasOne(u => u.Profile)
                  .WithOne(p => p.ApplicationUser)
                  .HasForeignKey<UserProfile>(p => p.ApplicationUserId)
                  .IsRequired();


        // Relationship for JobApplication
        builder
               .HasMany(u => u.JobApplications)
               .WithOne(j => j.ApplicationUser)
               .HasForeignKey(j => j.ApplicationUserId);


    }
}
