using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaff;
public sealed record CreateStaffCommand(
    string Name,
    string LastName,
    DateTime Birthdate,
    IFormFile Photo,
    string DepartmentId
    ) : ICommand<MessageResponse>;

