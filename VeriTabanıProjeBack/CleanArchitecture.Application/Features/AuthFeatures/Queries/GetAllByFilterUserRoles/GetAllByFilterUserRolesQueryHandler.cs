using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.AuthFeatures.Queries.GetAllByFilterUserRoles;
public sealed class GetAllByFilterUserRolesQueryHandler : IQueryHandler<GetAllByFilterUserRolesQuery, GetAllByFilterUserRolesQueryResponse>
{
    private readonly IAuthService _service;

    public GetAllByFilterUserRolesQueryHandler(IAuthService service)
    {
        _service = service;
    }

    public async Task<GetAllByFilterUserRolesQueryResponse> Handle(GetAllByFilterUserRolesQuery request, CancellationToken cancellationToken)
    {
        User user = await _service.GetByEmailOrUserNameAsync(request.userNameOrEmail, cancellationToken);

        GetAllByFilterUserRolesQueryResponse response = new(
            UserRoles: await _service.GetUserRolesByUserNameOrEmail(user.Id));

        return response;
    }
}
