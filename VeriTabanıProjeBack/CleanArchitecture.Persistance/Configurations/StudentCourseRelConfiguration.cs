using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configurations;
public sealed class StudentCourseRelConfiguration : IEntityTypeConfiguration<StudentCourseRelationship>
{
    public void Configure(EntityTypeBuilder<StudentCourseRelationship> builder)
    {
        builder.Property(p => p.StaffCourseId).IsRequired();
        builder.Property(p => p.StudentId).IsRequired();

        builder.HasOne(p => p.StaffCourses).WithMany(p => p.StudentCourseRels).HasForeignKey(p => p.StaffCourseId);
        builder.HasOne(p => p.Student).WithMany(p => p.StudentCourses).HasForeignKey(p => p.StudentId);

        builder.HasKey(p => p.Id);
        builder.ToTable("StudentAndCourseRelationships");
    }
}
