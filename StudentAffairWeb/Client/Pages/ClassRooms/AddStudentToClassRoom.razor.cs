namespace StudentAffairWeb.Client.Pages.ClassRooms;

public partial class AddStudentToClassRoom
{
    [Parameter] public string? id { get; set; }
    public ClassRoomStudent? _classRoomStudent { get; set; } = new();
    protected override async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _classRoomStudent = await _client.GetFromJsonAsync<ClassRoomStudent>($"api/ClassRoomStudent/{id}");
        else
            _classRoomStudent = new ClassRoomStudent();
    }

    public async void Submit()
    {
        if (_classRoomStudent != null)
        {
            if (String.IsNullOrEmpty(id))
            {
                await _client.PostAsJsonAsync<ClassRoomStudent>("api/ClassRoomStudent", _classRoomStudent);
                navigationManager.NavigateTo("classRoomStudents");
            }
            else
            {
                await _client.PutAsJsonAsync<ClassRoomStudent>($"api/ClassRoomStudent", _classRoomStudent);
                navigationManager.NavigateTo("classRoomStudents");
            }
        }
    }
}
