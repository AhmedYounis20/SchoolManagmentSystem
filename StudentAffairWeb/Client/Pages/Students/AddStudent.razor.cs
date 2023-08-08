namespace StudentAffairWeb.Client.Pages.Students;

public partial class AddStudent
{
    [Parameter] public string? id { get; set; }
    IBrowserFile? imageFile;
    public Student? _student { get; set; } = new();
   
    protected override async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _student = await _client.GetFromJsonAsync<Student>($"api/Student/{id}");
        else
            _student = new Student();
    }
    async Task LoadImage(InputFileChangeEventArgs inputFile)
    {
        imageFile = inputFile.File;
        if (_student != null)
            _student.ImagePath = await GetImageLink(imageFile);
        StateHasChanged();
    }
    async Task<string> GetImageLink(IBrowserFile file)
    {
        byte[] buffer = new byte[file.Size];
        await file.OpenReadStream(100 * 1024 * 1024).ReadAsync(buffer);
        return $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
    }

    public async void Submit()
    {
        if (_student != null)
        {
            if (String.IsNullOrEmpty(id))
            {
                await _client.PostAsJsonAsync<Student>("api/Student", _student);
                navigationManager.NavigateTo("students");
            }
            else
            {
                await _client.PutAsJsonAsync<Student>($"api/Student", _student);
                navigationManager.NavigateTo("students");
            }
        }
    }
}