using CleanArchitecture.Application.Features.StaffCourseFeatures.Commands.CreateStaffCourse;
using CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCourseByDepartment;
using CleanArchitecture.Application.Features.StaffCourseFeatures.Queries.GetAllStaffCoursesByStaff;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StaffCourseRelRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class StaffCourseRelService : IStaffCourseRelService
{
    private readonly IStaffCourseRelCommandRepository _commandRepository;
    private readonly IStaffCourseRelQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public StaffCourseRelService(IStaffCourseRelCommandRepository commandRepository, IStaffCourseRelQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateStaffCourseRelCommand request, CancellationToken cancellationToken)
    {
        StaffCourseRelationship relationship = new()
        {
            StaffId = request.StaffUserId,
            CourseId = request.CourseId
        };

        await _commandRepository.AddAsync(relationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<StaffCourseRelationship>> GetAllByDepartment(GetAllStaffCourseByDepartmentQuery request, CancellationToken cancellationToken)
    {
        var queryGetAll = _queryRepository
       .GetAll()
       .Where(p => p.Course.DepartmentId == request.DepartmentId)
       .Where(p => request.Search == null || p.Course.CourseName.Contains(request.Search) || p.Course.CourseCode.Contains(request.Search) || (p.Staff.Name + " " + p.Staff.LastName).Contains(request.Search))
       .Include(p => p.Staff)
       .Include(p => p.Course)
       .OrderBy(p => p.Course.CourseCode);

        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
        return resultGetAll;
    }

    public async Task<PaginationResult<StaffCourseRelationship>> GetAllByStaff(GetAllStaffCoursesByStaffQuery request, CancellationToken cancellationToken)
    {
        var queryGetAll = _queryRepository
               .GetAll()
               .Where(p => p.StaffId == request.StaffId)
               .Where(p => request.Search == null || p.Course.CourseName.Contains(request.Search) || p.Course.CourseCode.Contains(request.Search))
               .Include(p => p.Staff)
               .Include(p => p.Course)
               .OrderBy(p => p.Course.CourseCode);

        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
        return resultGetAll;
    }

    public Task<StaffCourseRelationship> GetById(string id)
    {
        return _queryRepository.GetById(id);
    }

    public Task<StaffCourseRelationship> GetByRelation(string CourseId, string StaffUserId, CancellationToken cancellationToken)
    {
        return _queryRepository.GetFirstByExpression(p => p.CourseId == CourseId && p.StaffId == StaffUserId, cancellationToken);
    }

    public int GetCount(string DepartmentId, string search)
    {
        return _queryRepository
            .GetAll()
            .Where(p => p.Course.DepartmentId == DepartmentId)
            .Where(p => search == null || p.Course.CourseName.Contains(search) || p.Course.CourseCode.Contains(search) || (p.Staff.Name + " " + p.Staff.LastName).Contains(search))
            .Count();
    }

    public int GetCountByStaff(string staffId, string search)
    {
        return _queryRepository
          .GetAll()
          .Where(p => p.StaffId == staffId)
          .Where(p => search == null || p.Course.CourseName.Contains(search) || p.Course.CourseCode.Contains(search))
          .Count();
    }

    public async Task RemoveAsync(string id, CancellationToken cancellationToken)
    {
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
