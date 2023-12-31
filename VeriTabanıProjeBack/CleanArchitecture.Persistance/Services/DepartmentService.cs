using AutoMapper;
using CleanArchitecture.Application.Features.DepartmentFeatures.Commands.CreateDepartment;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories.AppRepositories.DepartmentRepositories;
using CleanArchitecture.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class DepartmentService : IDepartmentService
{
    private readonly IDepartmentCommandRepository _commandRepository;
    private readonly IDepartmentQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentCommandRepository commandRepository, IDepartmentQueryRepository queryRepository, IAppUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department department = _mapper.Map<Department>(request);
        department.DepatmentCode = _queryRepository.GetAll().Count() + 1;

        await _commandRepository.AddAsync(department, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task CreateRange(IList<Department> newList, CancellationToken cancellationToken)
    {
        await _commandRepository.AddRangeAsync(newList, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Department>> GetAll()
    {
        return await _queryRepository.GetAll().ToListAsync();
    }



    public async Task<Department> GetById(string id)
    {
        return await _queryRepository.GetById(id);
    }

    public async Task<Department> GetByName(string name, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.DepartmentName == name, cancellationToken);
    }

    public async Task RemoveById(string id, CancellationToken cancellationToken)
    {
        _ = await _queryRepository.GetById(id) ?? throw new Exception("Bölüm Bulunamadı");

        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
