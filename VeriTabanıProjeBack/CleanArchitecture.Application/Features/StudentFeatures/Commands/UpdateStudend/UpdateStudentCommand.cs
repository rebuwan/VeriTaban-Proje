using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.UpdateStudend;
public sealed record UpdateStudentCommand(
       string Id,//Düz Id GUID
       string Name,
       string LastName,
       string DepartmentId//Değiştirme yetkisi var mı bilmiyorum ama ekledim
    ) : ICommand<MessageResponse>;

