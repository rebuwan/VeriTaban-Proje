using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configurations;
public sealed class MainRoleAndRoleRelasionshipConfiguration : IEntityTypeConfiguration<MainRoleAndRoleRelationship>
{
    public void Configure(EntityTypeBuilder<MainRoleAndRoleRelationship> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("MainRoleAndRoleRelationships");
    }
}
