using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities;
public sealed class Department : Entity
{
    public string DepartmentName { get; set; }
    public int DepatmentCode { get; set; }
}
