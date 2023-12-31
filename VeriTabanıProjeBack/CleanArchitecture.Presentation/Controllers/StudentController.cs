using CleanArchitecture.Application.Features.StudentFeatures.Commands.ChangeActivity;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.CreateStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.RemoveStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Commands.UpdateStudend;
using CleanArchitecture.Application.Features.StudentFeatures.Queries.GetAllStudend;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class StudentController : ApiController
{
    public StudentController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] CreateStudendCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllStudendQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllStudendQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeActivity(ChangeActivityStudentCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveById(RemoveStudentCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
