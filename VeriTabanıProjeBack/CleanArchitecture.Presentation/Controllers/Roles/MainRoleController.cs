using CleanArchitecture.Application.Features.MainRoleFeatures.Commands.CreateAllMainRoles;
using CleanArchitecture.Application.Features.MainRoleFeatures.Commands.CreateMainRole;
using CleanArchitecture.Application.Features.MainRoleFeatures.Commands.RemoveMainRole;
using CleanArchitecture.Application.Features.MainRoleFeatures.Commands.UpdateMainRole;
using CleanArchitecture.Application.Features.MainRoleFeatures.Queries.GetAllByFilterMainRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Roles;
public sealed class MainRoleController : ApiController
{
    public MainRoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAllMainRoles(CancellationToken cancellationToken)
    {
        CreateAllMainRolesCommand request = new(null);
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GelAllByFilterMainRoles(GetAllByFilterMainRoleQuery query, CancellationToken cancellationToken)
    {
        PaginationResult<GetAllByFilterMainRoleQueryResponse> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveMainRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
