using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateStaticCourses;
public sealed record CreateStaticCoursesCommand() : ICommand<MessageResponse>;
