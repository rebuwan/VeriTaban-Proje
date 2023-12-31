using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.MainRoleAndRoleFeatures.Queries.GetAllByFilterMainRoleAndRoleRL;
public sealed class GetAllByFilterMainRoleAndRoleRLQueryHandler : IQueryHandler<GetAllByFilterMainRoleAndRoleRLQuery, GetAllByFilterMainRoleAndRoleRLQueryResponse>
{
    private readonly IMainRoleAndRoleRelasionshipService _service;

    public GetAllByFilterMainRoleAndRoleRLQueryHandler(IMainRoleAndRoleRelasionshipService service)
    {
        _service = service;
    }

    public async Task<GetAllByFilterMainRoleAndRoleRLQueryResponse> Handle(GetAllByFilterMainRoleAndRoleRLQuery request, CancellationToken cancellationToken)
    {
        return new(
            await _service
            .GetAll()
            .Include("Role")
            .Include("MainRole")
            .ToListAsync());
    }
}
