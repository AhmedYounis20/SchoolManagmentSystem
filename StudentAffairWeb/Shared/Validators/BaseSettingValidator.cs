namespace StudentAffairWeb.Shared;

public class BaseSettingValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : BaseSetting
{
    public BaseSettingValidator()
    {
        const int  nameMaxLength= 50;
        RuleFor(e => e.Name).NotEmpty().WithMessage($"{typeof(TEntity).Name} name is required.");
        RuleFor(e => e.Name).MaximumLength(nameMaxLength).WithMessage($"{typeof(TEntity).Name} name max length is {nameMaxLength} character{(nameMaxLength<=1 ? ' ':'s')}");
    }
}