using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent_Career_Advisor.Data.EntitiesConfigurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.Property(x => x.Status).HasConversion<string>();

    }
}
