namespace StudentAffairWeb.Client.Pages.auth;

public partial class AddUser
{
    [Parameter] public string? id { get; set; }
    IBrowserFile? imageFile;
    public User? _user { get; set; } = new();
    protected override async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _user = await _client.GetFromJsonAsync<User>($"api/User/{id}");
        else
            _user = new User();
    }
    async Task LoadImage(InputFileChangeEventArgs inputFile)
    {
        imageFile = inputFile.File;
        if (_user != null)
            _user.ImagePath = await GetImageLink(imageFile);
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
        if (_user != null)
        {
            if (String.IsNullOrEmpty(id))
            {
                await _client.PostAsJsonAsync<User>("api/User", _user);
                //if (_authServices.GetCurrentUser() != null)
                    navigationManager.NavigateTo("Users");
                //else
                //    navigationManager.NavigateTo("/login");
            }
            else
            {
                await _client.PutAsJsonAsync<User>($"api/User", _user);
                //if (_authServices.GetCurrentUser() != null)
                    navigationManager.NavigateTo("Users");
                //else
                //    navigationManager.NavigateTo("/login");
            }
        }
    }
}