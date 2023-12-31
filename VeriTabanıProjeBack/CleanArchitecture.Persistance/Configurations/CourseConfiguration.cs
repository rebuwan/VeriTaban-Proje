using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace CleanArchitecture.Persistance.Configurations;
public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(p=>p.CourseCode).IsRequired();
        builder.Property(p => p.CourseName).IsRequired();

        builder.HasKey(p => p.Id);
        builder.ToTable("Courses");
    }
}

