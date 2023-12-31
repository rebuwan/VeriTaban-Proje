using CleanArchitecture.Application.Features.StaffFeatures.Commands.CreateStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.RemoveStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Commands.UpdateStaff;
using CleanArchitecture.Application.Features.StaffFeatures.Queries.GetAllStaff;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;
public interface IStaffService
{
    public Task CreateAsync(CreateStaffCommand request, CancellationToken cancellationToken);
    public Task UpdateAsync(UpdateStaffCommand request, CancellationToken cancellationToken);
    public Task UpdateUserAsync(UpdateStaffCommand request, CancellationToken cancellationToken);
    public Task RemoveAsync(RemoveStaffCommand request, CancellationToken cancellationToken);

    public Task<Staff> GetById(string id);
    public Task<Staff> GetByStaffCode(string staffId, CancellationToken cancellationToken);
    public Task<PaginationResult<Staff>> GetAllBySearch(GetAllStaffQuery request);
    int GetCount(GetAllStaffQuery request);

    public Task<Staff> GetByStaffNo(string no, CancellationToken cancellationToken);
    Task ChangeActivity(string Id, bool state, CancellationToken cancellationToken);
    Task CreateRange(IList<Staff> newList, CancellationToken cancellationToken);
    Task<IList<Staff>> GetAll();
}
