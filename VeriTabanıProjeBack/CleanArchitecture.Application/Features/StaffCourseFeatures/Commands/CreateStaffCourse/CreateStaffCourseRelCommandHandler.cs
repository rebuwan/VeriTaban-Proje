using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.StaffCourseFeatures.Commands.CreateStaffCourse;
public sealed class CreateStaffCourseRelCommandHandler : ICommandHandler<CreateStaffCourseRelCommand, MessageResponse>
{
    private readonly IStaffCourseRelService _service;

    public CreateStaffCourseRelCommandHandler(IStaffCourseRelService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateStaffCourseRelCommand request, CancellationToken cancellationToken)
    {
        StaffCourseRelationship relation = await _service.GetByRelation(request.CourseId,request.StaffUserId,cancellationToken);
        if (relation != null){ throw new Exception("Bu Ders Personel İlişkisi Zaten Mevcut"); }

        await _service.CreateAsync(request,cancellationToken);

        return new("İlişki Oluşturuldu");

    }
}
