using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffRepositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Repositories.AppRepositories.StaffRepositories;
public sealed class StaffQueryRepository : AppQueryRepository<Staff>, IStaffQueryRepository
{
    public StaffQueryRepository(AppDbContext context) : base(context)
    {
    }
}
