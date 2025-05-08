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

        // Relationship for UserCertification
        builder
               .HasMany(u => u.Certifications)
               .WithOne(c => c.ApplicationUser)
               .HasForeignKey(c => c.ApplicationUserId);

        // Relationship for JobApplication
        builder
               .HasMany(u => u.JobApplications)
               .WithOne(j => j.ApplicationUser)
               .HasForeignKey(j => j.ApplicationUserId);

        // Relationship for SavedJobRecommendation
        builder
               .HasMany(u => u.SavedJobRecommendations)
               .WithOne(r => r.ApplicationUser)
               .HasForeignKey(r => r.ApplicationUserId);

        // Relationship for ResumeFeedback
        builder
               .HasMany(u => u.ResumeFeedbacks)
               .WithOne(f => f.ApplicationUser)
               .HasForeignKey(f => f.ApplicationUserId);

        // Relationship for InterviewSessionFeedback
        builder
               .HasMany(u => u.InterviewSessionFeedbacks)
               .WithOne(i => i.ApplicationUser)
               .HasForeignKey(i => i.ApplicationUserId);
    }
}
