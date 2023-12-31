using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStudend;
public sealed class CreateStudendCommandHandler : ICommandHandler<CreateStudendCommand, MessageResponse>
{
    private readonly IStudentService _studentService;

    public CreateStudendCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<MessageResponse> Handle(CreateStudendCommand request, CancellationToken cancellationToken)
    {
       await _studentService.CreateAsync(request,cancellationToken);

        return new("Öğrenci Başarıyla Oluşturuldu");
        
    }
}
