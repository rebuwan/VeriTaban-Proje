using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class MainRole : Entity
{
    public MainRole() { }

    public MainRole(string title, string departmentId = null) 
    {
        Title = title;
        DepartmentId = departmentId;
    }

    public string Title { get; set; }

    [ForeignKey("Department")]
    public string DepartmentId { get; set; }
    public Department Department { get; set; }
}
