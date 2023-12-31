using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStudend;
public sealed record CreateStudendCommand (
       string Name,
       string LastName,
       string DepartmentId,
       IFormFile Photo,
       DateTime Birthdate, 
       DateTime EnrollmentDate 
    ): ICommand<MessageResponse>;

