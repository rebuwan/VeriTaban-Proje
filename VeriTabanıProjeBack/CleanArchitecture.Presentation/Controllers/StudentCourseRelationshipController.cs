
using CleanArchitecture.Application.Features.StudentCourseFeatures.Commands.CreateStudentCourse;
using CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByCourse;
using CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByStudent;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class StudentCourseRelationshipController : ApiController
{
    public StudentCourseRelationshipController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateStudentCourseRelCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByStudent(GetAllStudentCourseByStudentQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllStudentCourseByStudentQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByCourse(GetAllStudentCourseByCourseQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllStudentCourseByCourseQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
