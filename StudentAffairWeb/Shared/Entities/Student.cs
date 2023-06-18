namespace StudentAffairWeb.Shared;

public  class Student:BaseSetting
{
    public string? Phone { get; set; }
    public DateTime Birthdate { get; set; } = DateTime.Now;
    public int Age { get { return (DateTime.Now.Year - Birthdate.Year); } }
    public string? ImagePath { get; set;  }

}
