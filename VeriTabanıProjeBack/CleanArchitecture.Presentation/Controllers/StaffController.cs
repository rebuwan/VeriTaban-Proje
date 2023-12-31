using CleanArchitecture.Application.Features.StaffFeatures.Commands.ChangeActivity;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.RemoveStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.UpdateStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Queries.GetAllStaff;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class StaffController : ApiController
{
    public StaffController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] CreateStaffCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm] UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveStaffCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllStaffQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllStaffQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeActivity(ChangeActivityStaffCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
