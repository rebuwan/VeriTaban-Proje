using CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateStaticCourses;
using CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateStaticDepartments;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaticStaff;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStaticStudent;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class A_GenericListController : ApiController
{
    public A_GenericListController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateDepartment(CancellationToken cancellationToken)
    {
        CreateStaticDepartmentsCommand request = new();
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCourse(CancellationToken cancellationToken)
    {
        CreateStaticCoursesCommand request = new();
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateStudent(CancellationToken cancellationToken)
    {
        CreateStaticStudentCommand request = new();
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateStaff(CancellationToken cancellationToken)
    {
        CreateStaticStaffCommand request = new();
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
