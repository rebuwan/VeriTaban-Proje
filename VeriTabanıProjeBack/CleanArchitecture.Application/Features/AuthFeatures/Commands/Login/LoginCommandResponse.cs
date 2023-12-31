using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed record LoginCommandResponse(
    TokenRefreshTokenDto Token,
    string UserId,
    string StaffId_StudentId,
    string UserCode,
    string NameLastName,
    string UserPhoto,
    DepartmentDto Department
    );
