﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.MainRoleAndRoleRelRepositories;
public interface IMainRoleAndRoleRelCommandRepository : IAppCommandRepository<MainRoleAndRoleRelationship>
{
}
