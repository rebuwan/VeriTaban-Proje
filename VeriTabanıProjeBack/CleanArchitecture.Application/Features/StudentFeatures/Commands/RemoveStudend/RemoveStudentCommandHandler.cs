using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.RemoveStudend;
public sealed class RemoveStudentCommandHandler : ICommandHandler<RemoveStudentCommand, MessageResponse>
{
    private readonly IStudentService _studentService;

    public RemoveStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<MessageResponse> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
    {
        _ = await _studentService.GetById(request.Id) ?? throw new Exception("Öğrenci Bulunamadı");

        await _studentService.DeleteAsync(request.Id, cancellationToken);

        return new("Öğrenci Başarıyla Silindi");
    }
}
