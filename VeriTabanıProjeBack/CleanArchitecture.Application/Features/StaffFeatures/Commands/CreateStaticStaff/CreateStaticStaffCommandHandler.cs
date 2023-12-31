using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.StaticList;

namespace CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaticStaff;
public sealed class CreateStaticStaffCommandHandler : ICommandHandler<CreateStaticStaffCommand, MessageResponse>
{
    private readonly IStaffService _service;

    public CreateStaticStaffCommandHandler(IStaffService service)
    {
        _service = service;
    }

    public async Task<MessageResponse> Handle(CreateStaticStaffCommand request, CancellationToken cancellationToken)
    {
        IList<Staff> courses = await _service.GetAll();
        IList<Staff> courseList = StaffList.GetStaticStaffs();
        IList<Staff> newList = new List<Staff>();

        foreach (var item in courseList)
        {
            if (!courses.Contains(item))
            {
                newList.Add(item);
            }
        }

        await _service.CreateRange(newList, cancellationToken);

        return new(newList.Count + "  Adet Personel Eklendi");
    }
}
