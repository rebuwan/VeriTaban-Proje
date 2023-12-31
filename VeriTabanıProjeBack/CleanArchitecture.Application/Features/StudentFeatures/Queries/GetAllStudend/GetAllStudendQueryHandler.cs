using CleanArchitecture.Application.Messaging;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Features.StudentFeatures.Queries.GetAllStudend;
public sealed class GetAllStudendQueryHandler : IQueryHandler<GetAllStudendQuery, PaginationResult<GetAllStudendQueryResponse>>
{
    private readonly IStudentService _service;

    public GetAllStudendQueryHandler(IStudentService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllStudendQueryResponse>> Handle(GetAllStudendQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Student> students = await _service.GetAllByFilter(request);
        if (students == null || students.Datas == null)
            throw new Exception("Veri Bulunamadı");

        int count = _service.GetCount(request);

        PaginationResult<GetAllStudendQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: students.Datas.Select(p => new GetAllStudendQueryResponse(
                Id: p.Id,
                StudentNo: p.StudentNo,
                Name: p.Name,
                LastName: p.LastName,
                DepartmentName: p.User.Department.DepartmentName,
                DepartmentId: p.User.Department.Id,
                EnrollDate: p.EnrollmentDate,
                PhotoUrl: p.StudentPhoto,
                Birthdate: p.Birthdate,
                IsActive: p.IsActive,
                TotalCount: count
            )).ToList());

        return response;
    }
}