using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

public class CleanArchitectureUseCaseConfiguration : IEntityTypeConfiguration<CleanArchitectureUseCase>
{
    public void Configure(EntityTypeBuilder<CleanArchitectureUseCase> builder)
    {
        builder.Property(t => t.Id)
            .IsRequired();
    }
}


