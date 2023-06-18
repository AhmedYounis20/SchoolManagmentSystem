namespace StudentAffairWeb.Client;

public partial class SignUpPage
{
    IBrowserFile? imageFile;
    public User? _user { get; set; } = new();
    public LoginRequest loginRequest { get; set; } = new();
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

    public async Task Submit()
    {
        if (_user != null)
        {
            await _client.PostAsJsonAsync<User>($"api/User", _user);
            loginRequest = new LoginRequest {
            Email= _user.Email,
            Password= _user.Password,
            };
            await _authServices.AuthenticateJWT(loginRequest,true);
            navigationManager.NavigateTo("/profile",true);
        }
    }
}