using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class StudentCourseRelationship : Entity
{
    [ForeignKey("Student")]
    public string StudentId { get; set; }
    public Student Student { get; set;}

    [ForeignKey("StaffCourseRelationship")]
    public string StaffCourseId { get; set; }
    public StaffCourseRelationship StaffCourses { get; set; }
    public bool IsApproved { get; set; } = false;
}
