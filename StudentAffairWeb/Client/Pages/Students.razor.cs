using Microsoft.JSInterop;

namespace StudentAffairWeb.Client.Pages;

partial class Students
{
    public string? searchText { get; set; }

    List<Student>? students = new();

    protected override async Task OnInitializedAsync()
    {
        students = await GetStudents();
        searchText = "";
    }

    protected override async Task OnParametersSetAsync() => students = await GetStudents();

    public async Task<List<Student>?> GetStudents() => await _client.GetFromJsonAsync<List<Student>>("api/Student");

    public void AddStudent() => navigationManager.NavigateTo("AddStudent");

    public async void Delete(Guid? id)
    {
        await _client.DeleteAsync($"api/Student/{id.ToString()}");
        students = await GetStudents();
        StateHasChanged();
    }
    public void Update(Guid? id)
    {
        navigationManager.NavigateTo($"EditStudent/{id.ToString()}");
        StateHasChanged();
    }
    public async Task Search()
    {
        students = await _client.GetFromJsonAsync<List<Student>>($"api/Student/Search/{searchText}");
        StateHasChanged();
    }

    private async Task DownloadProfilePic(Student student) => await Js.InvokeVoidAsync("downloadPic", student.ImagePath, student.Name);

}