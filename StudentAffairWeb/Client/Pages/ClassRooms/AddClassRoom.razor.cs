namespace StudentAffairWeb.Client.Pages.ClassRooms;

public partial class AddClassRoom
{
    [Parameter] public string? id { get; set; }
    public ClassRoom _classRoom { get; set; } = new();
    public List<Teacher>? teachers { get; set; }
    public List<Subject>? subjects { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _classRoom = await _client.GetFromJsonAsync<ClassRoom>($"api/ClassRoom/{id}") ?? new();
        else
        {
            _classRoom = new ClassRoom();
            _classRoom.Subject = null;
            _classRoom.Teacher = null;
        }
        teachers = await _client.GetFromJsonAsync<List<Teacher>>($"api/Teacher");
        subjects = await _client.GetFromJsonAsync<List<Subject>>($"api/Subject");
    }

    public async void Submit()
    {
        if (_classRoom != null)
        {
            if (String.IsNullOrEmpty(id))
            {
                await _client.PostAsJsonAsync<ClassRoom>("api/ClassRoom", _classRoom);
                StateHasChanged();
            }
            else
            {
                await _client.PutAsJsonAsync<ClassRoom>($"api/ClassRoom", _classRoom);
            }
            navigationManager.NavigateTo("classRooms");
        }
    }
}
