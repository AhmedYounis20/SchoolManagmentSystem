using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;

namespace StudentAffairWeb.Server;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseSettingController<Student>
{
    IStudentUnitOfWork _studentUnitOfWork;
    public StudentController(IStudentUnitOfWork unitOfWork) : base(unitOfWork) => _studentUnitOfWork = unitOfWork;

    [HttpGet("{startIndex}/{Count}")]
    public async Task<IEnumerable<Student>?> GetForPage(int startIndex, int Count)
    {
        List<Student> students = new();
        if (startIndex == 0)
        {
            List<Student>? dbStudents = (await Get())?.ToList();
            if (dbStudents?.Any() ?? false)
                students.AddRange(dbStudents);
        }
        for (int i = startIndex; i < startIndex + Count; i++)
        {
            if (i < 2000)
            {
                students.Add(new Student
                {
                    Name = i.ToString(),
                    Birthdate = DateTime.Now,
                    Phone = "01234567891",
                });
            }
        }
        return students.AsEnumerable();
    }
}
