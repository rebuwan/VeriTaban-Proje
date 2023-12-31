using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateAllRoles;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.DeleteRole;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.UpdateRole;
using CleanArchitecture.Application.Features.RoleFeatures.Queries.GetAllByFilterRoles;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Roles;

public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateRoleCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateRoleCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Remove(string id)
    {
        DeleteRoleCommand request = new(id);

        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAllRoles()
    {
        CreateAllRolesCommand request = new();
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByFilterRoles(GetAllByFilterRolesQuery request)
    {
        PaginationResult<GetAllByFilterRolesQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }
}
