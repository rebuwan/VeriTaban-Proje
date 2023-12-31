using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class Course : Entity
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public int Credit {  get; set; }

    [ForeignKey("Department")]
    public string DepartmentId { get; set; }
    public Department Department { get; set; }
    public ICollection<StaffCourseRelationship> Staffs { get; set; }
}
