namespace StudentAffairWeb.Shared;

public  class User:BaseSetting
{
    public string? ImagePath { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmationPassword { get; set; }

    public SecurityRole SecurityRole { get; set; } = SecurityRole.None;


}
