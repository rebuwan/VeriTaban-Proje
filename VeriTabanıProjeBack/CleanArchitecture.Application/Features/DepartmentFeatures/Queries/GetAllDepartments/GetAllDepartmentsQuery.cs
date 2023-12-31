using CleanArchitecture.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.DepartmentFeatures.Queries.GetAllDepartments;
public sealed record GetAllDepartmentsQuery() : IQuery<GetAllDepartmentsQueryResponse>;

