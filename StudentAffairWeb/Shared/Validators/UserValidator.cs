namespace StudentAffairWeb.Shared;

public class UserValidator : BaseSettingValidator<User>
{
    public UserValidator() {
        RuleFor(e => e.Email).NotEmpty().WithMessage("please Enter an Email");
        RuleFor(e => e.Email).EmailAddress().WithMessage("Please Enter Valid Email");
        RuleFor(e => e.Password).NotEmpty().WithMessage("please Enter a password");
        RuleFor(e => e.ConfirmationPassword).NotEmpty().WithMessage("Confirm your password");
        RuleFor(e => e.ConfirmationPassword).Equal<User>(e => e.Password).WithMessage("doesn't match password");
    }
}