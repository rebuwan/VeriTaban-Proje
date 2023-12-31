using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class Staff : Entity

{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }
    public string StaffNo { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public string Photo { get; set; }

    public ICollection<StaffCourseRelationship> Courses { get; set; }
}
