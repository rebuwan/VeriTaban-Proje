using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities;
public sealed class StaffCourseRelationship : Entity
{
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public string StaffId { get; set; }
    public Staff Staff { get; set; }
    public ICollection<StudentCourseRelationship> StudentCourseRels { get; set; }

}
