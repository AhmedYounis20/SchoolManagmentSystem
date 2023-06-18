namespace StudentAffairWeb.Shared;

public class StudentValidator : BaseSettingValidator<Student>
{
    public StudentValidator() {
        RuleFor(e => e.Birthdate).NotEmpty().WithMessage("Please Enter your birthdate");
        RuleFor(e => e.Phone).NotEmpty().WithMessage("Please Enter your Phone like:0101-234-2344.");
        RuleFor(e => e.Phone).Matches(new Regex("^[0-9]{11}$"));
        RuleFor(e => e.Birthdate).GreaterThanOrEqualTo(new DateTime(1990,1,1)).WithMessage("Birthdate must be after 1990/1/1");
        RuleFor(e => e.Birthdate).LessThanOrEqualTo(new DateTime(2015,1,1)).WithMessage("Birthdate must be before 2015/1/1");
    }
}