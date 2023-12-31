using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.LoginForAFirstTime;
public sealed class LoginForAFirstTimeCommandValidator : AbstractValidator<LoginForAFirstTimeCommand>
{
    public LoginForAFirstTimeCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı adı boş olamaz!");
        RuleFor(p => p.UserId).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır!");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şife en az 1 adet büyük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şife en az 1 adet küçük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şife en az 1 adet rakam içermelidir!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şife en az 1 adet özel karakter içermelidir!");
    }
}
