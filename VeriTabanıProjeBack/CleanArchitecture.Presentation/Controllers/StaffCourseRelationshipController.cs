using CleanArchitecture.Application.Features.StaffCourseFeatures.Commands.CreateStaffCourse;
using CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCourseByDepartment;
using CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCoursesByStaff;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class StaffCourseRelationshipController : ApiController
{
    public StaffCourseRelationshipController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateStaffCourseRelCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByDepartment(GetAllStaffCourseByDepartmentQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllStaffCourseByDepartmentQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByStaff(GetAllStaffCoursesByStaffQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllStaffCoursesByStaffQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
