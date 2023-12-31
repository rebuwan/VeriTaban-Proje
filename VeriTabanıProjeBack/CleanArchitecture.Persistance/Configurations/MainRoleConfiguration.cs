using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configurations;
public sealed class MainRoleConfiguration : IEntityTypeConfiguration<MainRole>
{
    public void Configure(EntityTypeBuilder<MainRole> builder)
    {
        builder.Property(x => x.Title).IsRequired();

        builder.HasKey(x => x.Id);
        builder.ToTable("MainRoles");
    }
}
