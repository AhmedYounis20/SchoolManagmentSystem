namespace StudentAffairWeb.Shared;

public class ClassRoomValidator : BaseSettingValidator<ClassRoom>
{
    public ClassRoomValidator()
    {
        RuleFor(e => e.TeacherId).NotNull().WithMessage("Please Select a Teacher For the ClassRoom");
        RuleFor(e => e.SubjectId).NotNull().WithMessage("Please Select a Teacher For the ClassRoom");
    }
}