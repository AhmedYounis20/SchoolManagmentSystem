namespace StudentAffairWeb.Shared;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator() {
        RuleFor(e => e.Email).NotEmpty().WithMessage("please enter your Email");
        RuleFor(e => e.Email).EmailAddress().WithMessage("Please enter Valid Email");
        RuleFor(e => e.Password).NotEmpty().WithMessage("please enter your password");
    }
}