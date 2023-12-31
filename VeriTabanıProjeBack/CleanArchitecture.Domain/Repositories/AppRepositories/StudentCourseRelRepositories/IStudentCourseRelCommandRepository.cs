﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.GenericRepositories;

namespace CleanArchitecture.Domain.Repositories.AppRepositories.StudentCourseRelRepositories;
public interface IStudentCourseRelCommandRepository : IAppCommandRepository<StudentCourseRelationship>
{
}
