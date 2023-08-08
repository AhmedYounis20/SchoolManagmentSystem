using StudentAffairWeb.Client.Pages.Students;

namespace StudentAffairWeb.Client.Pages.ClassRooms;

public partial class ClassRoomDetails
{
    [Parameter] public string? ClassroomId { get; set; }
    private ClassRoom? classRoom { get; set; }
    private Teacher? teacher { get; set; }
    private Subject? subject { get; set; }
    private List<ClassRoomStudent>? students = new();
    private ClassRoomStudent? classRoomStudent = new();
    private List<Student>? allStudents = new();
    public string? searchText { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        classRoom = await _client.GetFromJsonAsync<ClassRoom>($"/api/classRoom/{ClassroomId}");
        if (classRoom != null)
        {
            allStudents = await _client.GetFromJsonAsync<List<Student>>("api/Student");
            teacher = classRoom.Teacher;
            subject = classRoom.Subject;
            students = classRoom.ClassRoomStudents;
            classRoomStudent = new ClassRoomStudent();
            classRoomStudent.ClassRoomId = classRoom.Id;
            StateHasChanged();
        }
    }
    private async void AddStudent()
    {
        if (classRoomStudent != null)
        {
            classRoomStudent.JoinedOn = new DateTime();
            await _client.PostAsJsonAsync<ClassRoomStudent>("/api/ClassRoomStudent", classRoomStudent);
            classRoom = await _client.GetFromJsonAsync<ClassRoom>($"/api/classRoom/{ClassroomId}");
            students=classRoom.ClassRoomStudents.ToList();
            StateHasChanged();
        }
    }
    private async Task RemoveStudent(Guid id)
    {
        await _client.DeleteAsync($"/api/ClassRoomStudent/{id}");
        classRoom = await _client.GetFromJsonAsync<ClassRoom>($"/api/classRoom/{ClassroomId}");
        students = classRoom.ClassRoomStudents.ToList();
        StateHasChanged();
    }

    public async Task Search(ChangeEventArgs input)
    {
        if (input.Value is not null && !string.IsNullOrEmpty(input.Value.ToString()))
            students = classRoom.ClassRoomStudents.Where(e=>e.Student.Name.Contains(input.Value.ToString())).ToList();
        else
            students = classRoom.ClassRoomStudents;
        StateHasChanged();
    }

}
