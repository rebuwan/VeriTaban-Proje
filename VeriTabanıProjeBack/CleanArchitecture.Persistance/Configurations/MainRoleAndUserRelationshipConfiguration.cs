using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configurations;
public sealed class MainRoleAndUserRelationshipConfiguration : IEntityTypeConfiguration<MainRoleAndUserRelationship>
{
    public void Configure(EntityTypeBuilder<MainRoleAndUserRelationship> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("MainRoleAndUserRelationships");
    }
}
