using CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateDepartment;
using CleanArchitecture.Application.Features.DepartmentFeatures.Commands.RemoveDepartment;
using CleanArchitecture.Application.Features.DepartmentFeatures.Queries.GetAllDepartments;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class DepartmentController : ApiController
{
    public DepartmentController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveByID(RemoveDepartmentCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllDepartmentsQuery request = new();

        GetAllDepartmentsQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
