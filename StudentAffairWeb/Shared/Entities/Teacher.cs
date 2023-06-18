namespace StudentAffairWeb.Shared;

public  class Teacher: BaseSetting
{
    public string Phone { get; set; }
    public DateTime Birthdate { get; set; } = DateTime.Now;
    public int Age { get { return (DateTime.Now.Year - Birthdate.Year); } }
}

