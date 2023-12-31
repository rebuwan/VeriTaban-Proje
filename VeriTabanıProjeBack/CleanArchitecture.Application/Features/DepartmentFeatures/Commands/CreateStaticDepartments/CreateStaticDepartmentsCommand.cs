using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateStaticDepartments;
public sealed record CreateStaticDepartmentsCommand() : ICommand<MessageResponse>;
