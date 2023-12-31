using AutoMapper;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.CreateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Commands.UpdateCourse;
using CleanArchitecture.Application.Features.CourseFeatures.Queries.GetAllCourseByFilter;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.CourseRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class CourseService : ICourseService
{
    private readonly ICourseCommandRepository _commandRepository;
    private readonly ICourseQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(ICourseCommandRepository commandRepository, ICourseQueryRepository queryRepository, IAppUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        Course course = _mapper.Map<Course>(request);
        await _commandRepository.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateAsync(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        Course course = await GetById(request.Id);
        course.CourseName = request.CourseName;
        course.CourseCode = request.CourseCode;
        course.Credit = request.Credit;
        course.DepartmentId = request.DepartmentId;

        _commandRepository.Update(course);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task RemoveAsync(string id, CancellationToken cancellationToken)
    {
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Course>> GetAllByFilter(GetAllCourseByFilterQuery request, CancellationToken cancellationToken)
    {
        var queryGetAll = _queryRepository
         .GetAll()
         .Where(p => p.DepartmentId == request.DepartmentId)
         .Where(p => request.Search == null || p.CourseName.Contains(request.Search) || p.CourseCode.Contains(request.Search))
         .Include(p => p.Staffs)
         .ThenInclude(p => p.Staff)
         .OrderBy(p => p.CourseCode);
        var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
        return resultGetAll;
    }

    public async Task<Course> GetByCourseCode(string courseCode, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.CourseCode == courseCode, cancellationToken);
    }

    public async Task<Course> GetById(string id)
    {
        return await _queryRepository.GetById(id);
    }

    public async Task<Course> GetByCourseName(string courseName, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.CourseName == courseName, cancellationToken);
    }

    public int GetCount(string DepartmentId, string search)
    {
        return _queryRepository.GetAll()
        .Where(p => p.DepartmentId == DepartmentId)
        .Where(p => search == null || p.CourseName.Contains(search) || p.CourseCode.Contains(search))
        .Count();

    }

    public async Task ChangeActivity(string Id, bool state, CancellationToken cancellationToken)
    {
        Course entity = await _queryRepository.GetById(Id) ?? throw new Exception("Ders Bulunamadı");
        entity.IsActive = state;
        _commandRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Course>> GetAll()
    {
        var queryGetAll = _queryRepository
        .GetAll()
        .Include(p => p.Staffs)
        .ThenInclude(p => p.Staff)
        .OrderBy(p => p.CourseCode);

        return await queryGetAll.ToListAsync();
    }

    public async Task CreateRange(IList<Course> courses, CancellationToken cancellationToken)
    {
        await _commandRepository.AddRangeAsync(courses, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
