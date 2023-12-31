﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndUserRelRepositories;
public interface IMainRoleAndUserRelCommandRepository : IAppCommandRepository<MainRoleAndUserRelationship>
{
}
