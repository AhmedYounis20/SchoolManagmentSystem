namespace StudentAffairWeb.Client.Pages.Teachers;

public partial class AddTeacher
{
    [Parameter] public string? id { get; set; }
    public Teacher? _teacher { get; set; } = new();
    protected override async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _teacher = await _client.GetFromJsonAsync<Teacher>($"api/Teacher/{id}");
        else
            _teacher = new Teacher();
    }
    public async void Submit()
    {
        if (_teacher != null)
        {

            if (String.IsNullOrEmpty(id))
            {
                await _client.PostAsJsonAsync<Teacher>("api/Teacher", _teacher);
                navigationManager.NavigateTo("teachers");
            }
            else
            {
                await _client.PutAsJsonAsync<Teacher>($"api/Teacher", _teacher);
                navigationManager.NavigateTo("teachers");
            }
        }
    }
}
