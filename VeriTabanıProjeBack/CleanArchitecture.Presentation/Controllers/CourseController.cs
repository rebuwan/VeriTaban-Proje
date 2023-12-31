using CleanArchitecture.Application.Features.CourseFeatures.Commands.ChangeActivity;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.RemoveCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.UpdateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Queries.GetAllCourseByFilter;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class CourseController : ApiController
{
    public CourseController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveById(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByFilter(GetAllCourseByFilterQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllCourseByFilterQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeActivity(ChangeActivityCourseCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
