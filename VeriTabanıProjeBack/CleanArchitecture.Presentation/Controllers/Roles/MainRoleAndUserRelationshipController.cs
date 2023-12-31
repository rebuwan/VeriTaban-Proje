using CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.CreateMainRoleAndUserRL;
using CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.IsHaveMainRoleInUser;
using CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Commands.RemoveByIdMainRoleAndUserRL;
using CleanArchitecture.Application.Features.MainRoleAndUserFeatures.Queries.GetAllByFilterMainRoleAndUserRL;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Roles;
public sealed class MainRoleAndUserRelationshipController : ApiController
{
    public MainRoleAndUserRelationshipController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveByIdMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByFilterMainRoleAndUserRL(GetAllByFilterMainRoleAndUserRLQuery request)
    {
        PaginationResult<GetAllByFilterMainRoleAndUserRLQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> IsHaveMainRoleInUser(IsHaveMainRoleInUserCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
