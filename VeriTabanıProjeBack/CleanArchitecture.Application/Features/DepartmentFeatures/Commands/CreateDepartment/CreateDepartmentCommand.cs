using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateDepartment;
public sealed record CreateDepartmentCommand(
    string DepartmentName
    ) : ICommand<MessageResponse>;

