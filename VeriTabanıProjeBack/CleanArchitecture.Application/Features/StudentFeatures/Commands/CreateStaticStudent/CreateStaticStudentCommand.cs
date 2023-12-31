using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStaticStudent;
public sealed record CreateStaticStudentCommand() : ICommand<MessageResponse>;

