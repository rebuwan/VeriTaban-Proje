using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.RemoveStudend;
public sealed record RemoveStudentCommand(
    string Id // Düz id
    ): ICommand<MessageResponse>;
