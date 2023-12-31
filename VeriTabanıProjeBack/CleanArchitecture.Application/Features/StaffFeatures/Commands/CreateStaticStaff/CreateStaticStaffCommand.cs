using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaticStaff;
public sealed record CreateStaticStaffCommand() : ICommand<MessageResponse>;

