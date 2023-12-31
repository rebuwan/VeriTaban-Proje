using CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.CreateMainRoleAndRoleRL;
using CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.IsHaveRoleInMainRole;
using CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Commands.RemoveByIdMainRoleAndRole;
using CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Queries.GetAllByFilterMainRoleAndRoleRL;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Roles;
public sealed class MainRoleAndRoleRelationshipController : ApiController
{
    public MainRoleAndRoleRelationshipController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllByFilterMainRoleAndRoleRLQuery request = new();
        GetAllByFilterMainRoleAndRoleRLQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndRoleRLCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveByIdMainRoleAndRoleCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> IsHaveRoleInMainRole(IsHaveRoleInMainRoleCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
