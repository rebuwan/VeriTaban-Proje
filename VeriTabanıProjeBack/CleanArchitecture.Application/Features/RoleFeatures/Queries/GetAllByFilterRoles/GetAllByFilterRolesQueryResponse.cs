using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.RoleFeatures.Queries.GetAllByFilterRoles;
public sealed record GetAllByFilterRolesQueryResponse(
    string Id,
    string Name,
    string NormalizedName,
    string ConcurrencyStamp,
    string Code,
    string Title,
    bool? IsActive
    );
