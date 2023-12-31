using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Commands.RemoveDepartment;
public sealed record RemoveDepartmentCommand(
    string Id) : ICommand<MessageResponse>;

