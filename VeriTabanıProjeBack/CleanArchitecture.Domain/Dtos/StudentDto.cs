namespace CleanArchitecture.Domain.Dtos;
public sealed record StudentDto(
    string UserId,
    string StudentId,
    string Name,
    string LastName,
    string DepartmentName,
    DateTime EnrollDate,
    DateTime Birthdate
    );

