namespace StudentAffairWeb.Client.Pages.Teachers;

public partial class Teachers
{
    public string searchText { get; set; }

    List<Teacher>? teachers;

    protected override async Task OnInitializedAsync()  
    {
        teachers = await GetTeachers(); 
        searchText="";  
    }
    
    protected override async Task OnParametersSetAsync()
    {
        teachers = await GetTeachers();
        StateHasChanged();
    }

    public async Task<List<Teacher>?> GetTeachers()=> await _client.GetFromJsonAsync<List<Teacher>>("api/Teacher");
    
    public void AddTeacher() => navigationManager.NavigateTo("AddTeacher");
    
    public async void Delete(Guid? id)
    {
       await  _client.DeleteAsync($"api/Teacher/{id.ToString()}");
        teachers = await GetTeachers();
        StateHasChanged();
    }
    public void Update(Guid? id)
    {
        navigationManager.NavigateTo($"EditTeacher/{id.ToString()}");
        StateHasChanged();
    }
    public async Task Search(ChangeEventArgs input)
    {
        if (input.Value is not null && !string.IsNullOrEmpty(input.Value.ToString()))
            teachers = await _client.GetFromJsonAsync<List<Teacher>>($"api/Teacher/Search/{input.Value}");
        else
            teachers = await GetTeachers();

        StateHasChanged();
    }
}
