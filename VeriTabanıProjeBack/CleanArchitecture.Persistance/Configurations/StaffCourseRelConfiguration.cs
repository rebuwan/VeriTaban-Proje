using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configurations;
public sealed class StaffCourseRelConfiguration : IEntityTypeConfiguration<StaffCourseRelationship>
{
    public void Configure(EntityTypeBuilder<StaffCourseRelationship> builder)
    {
        builder.Property(p => p.CourseId).IsRequired();
        builder.Property(p => p.StaffId).IsRequired();

        builder.HasOne(p => p.Course).WithMany(p => p.Staffs).HasForeignKey(p => p.CourseId);
        builder.HasOne(p => p.Staff).WithMany(p => p.Courses).HasForeignKey(p => p.StaffId);

        builder.HasKey(p => p.Id);
        builder.ToTable("StaffAndCourseRelationships");
    }
}