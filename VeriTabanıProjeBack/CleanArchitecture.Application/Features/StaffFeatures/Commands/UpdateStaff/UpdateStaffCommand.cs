using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.UpdateStaff;
public sealed record UpdateStaffCommand(
    string Id,
    string UserId,
    string Name,
    string LastName,
    DateTime Birthdate,
    IFormFile Photo,
    string DepartmentId
    ) : ICommand<MessageResponse>;