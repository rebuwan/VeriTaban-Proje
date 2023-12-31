using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class Student : Entity
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public string StudentPhoto { get; set; }
    public User User { get; set; }
    public string StudentNo { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public ICollection<StudentCourseRelationship> StudentCourses { get; set; }

}
