using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.UpdateStudend;
public sealed class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand, MessageResponse>
{
    private readonly IStudentService _service;

    public UpdateStudentCommandHandler(IStudentService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        _ = await _service.GetById(request.Id) ?? throw new Exception("Öğrenci Bulunamadı");

        await _service.UpdateAsync(request, cancellationToken);

        return new("Öğrenci Başarıyla Güncellendi");
    }
}
