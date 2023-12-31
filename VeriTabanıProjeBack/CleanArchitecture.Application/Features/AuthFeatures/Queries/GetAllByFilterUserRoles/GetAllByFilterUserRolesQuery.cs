using CleanArchitecture.Application.Messaging;

namespace CleanArchitecture.Application.Features.AuthFeatures.Queries.GetAllByFilterUserRoles;
public sealed record GetAllByFilterUserRolesQuery(
    string userNameOrEmail
    ) : IQuery<GetAllByFilterUserRolesQueryResponse>;
