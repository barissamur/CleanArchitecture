using NewPrj.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewPrj.Infrastructure.Data.Configurations;

public class CleanArchitectureUseCaseConfiguration : IEntityTypeConfiguration<CleanArchitectureUseCase>
{
    public void Configure(EntityTypeBuilder<CleanArchitectureUseCase> builder)
    {
        builder.Property(t => t.Id)
            .IsRequired();
    }
}


