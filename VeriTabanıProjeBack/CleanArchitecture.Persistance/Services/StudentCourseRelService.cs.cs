using CleanArchitecture.Application.Features.StudentCourseFeatures.Commands.CreateStudentCourse;
using CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByCourse;
using CleanArchitecture.Application.Features.StudentCourseFeatures.Queries.GetAllStudentCourseByStudent;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.StudentCourseRelRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class StudentCourseRelService : IStudentCourseRelService
{
    private readonly IStudentCourseRelCommandRepository _commandRepository;
    private readonly IStudentCourseRelQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly IStaffCourseRelService _staffCourseRelService;

    public StudentCourseRelService(IStudentCourseRelCommandRepository commandRepository, IStudentCourseRelQueryRepository queryRepository, IAppUnitOfWork unitOfWork, IStaffCourseRelService staffCourseRelService)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _staffCourseRelService = staffCourseRelService;
    }

    public async Task CreateAsync(CreateStudentCourseRelCommand request, CancellationToken cancellationToken)
    {
        StudentCourseRelationship rel = new()
        {
            StudentId = request.StudentId,
            StaffCourseId = request.CourseId,
        };
        await _commandRepository.AddAsync(rel, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task DeleteAsync(string Id, CancellationToken cancellationToken)
    {
        await _commandRepository.RemoveById(Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<StudentCourseRelationship>> GetAllByCourse(GetAllStudentCourseByCourseQuery request, CancellationToken cancellationToken)
    {
        var queryGetAll = _queryRepository
            .GetAll()
            .Where(p => p.StaffCourseId == request.CourseId)
            .Where(p => request.Search == null || p.StaffCourses.Course.CourseName.Contains(request.Search))
            .Include(p => p.StaffCourses)
            .ThenInclude(p => p.Course)
            .Include(p => p.StaffCourses)
            .ThenInclude(p => p.Staff)
            .Include(p => p.Student)
            .OrderBy(p => p.StaffCourses.Course.CourseCode);

        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
        return resultGetAll;
    }

    public async Task<PaginationResult<StudentCourseRelationship>> GetAllByStudent(GetAllStudentCourseByStudentQuery request, CancellationToken cancellationToken)
    {
        var queryGetAll = _queryRepository
          .GetAll()
          .Where(p => p.StudentId == request.StudentId)
          .Where(p => request.Search == null || (p.Student.Name + " " + p.Student.LastName).Contains(request.Search))
          .Include(p => p.StaffCourses)
          .ThenInclude(p => p.Course)
          .Include(p => p.StaffCourses)
          .ThenInclude(p => p.Staff)
          .Include(p => p.Student)
          .OrderBy(p => p.StaffCourses.Course.CourseCode);
        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
        return resultGetAll;
    }

    public async Task<bool> GetByCourse(string studentId, string staffCourseId)
    {
        StaffCourseRelationship staffCourse = await _staffCourseRelService.GetById(staffCourseId);
        return _queryRepository.GetAll().Where(p => p.StudentId == studentId).Any(p => p.StaffCourses.CourseId == staffCourse.CourseId);
    }

    public async Task<StudentCourseRelationship> GetById(string Id)
    {
        return await _queryRepository.GetById(Id);
    }

    public async Task<StudentCourseRelationship> GetByRel(string StudentId, string CourseId, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.StaffCourseId == CourseId && p.StudentId == StudentId, cancellationToken);
    }

    public int GetCountByCourse(string CourseId)
    {
        return _queryRepository.GetAll().Where(p => p.StaffCourseId == CourseId).Count();
    }

    public int GetCountByStudent(GetAllStudentCourseByStudentQuery request)
    {
        return _queryRepository.GetAll().Where(p => p.StudentId == request.StudentId).Count();
    }

}
