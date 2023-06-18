namespace StudentAffairWeb.Client;

public class AuthServices : IAuthServices
{
    private HttpClient _client;
    private NavigationManager navigation;
    private ILocalStorageService _localStorageService;
    //public static User currentUser = new();
    //public static bool Isauthenicated = false;

    public AuthServices(HttpClient client, ILocalStorageService localStorageService, NavigationManager navigation)
    {
        _client = client;
        _localStorageService = localStorageService;
        this.navigation = navigation;

    }

    public async Task<JWTResponse?> AuthenticateJWT(LoginRequest loginRequest, bool rememberMe = false, int ExpireInDays = 5)
    {
        var httpMessageResponse = await _client.PostAsJsonAsync("api/Authentication/AuthenticateJWT", loginRequest);
        JWTResponse? jwtResponse = await httpMessageResponse.Content.ReadFromJsonAsync<JWTResponse>();
        if (!string.IsNullOrEmpty(jwtResponse?.Token))
            await PrepareLoginStorage(jwtResponse.Token);

        return jwtResponse;
    }

    public async Task<User?> LoginCookie(LoginRequest loginRequest, bool rememberMe = false, int ExpireInDays = 5)
    {
        var httpMessageResponse = await _client.PostAsJsonAsync($"api/Authentication/login?rememberme={rememberMe}&ExpireInDays={ExpireInDays}", loginRequest);
        return await httpMessageResponse.Content.ReadFromJsonAsync<User>();
    }
    public async Task<string> GetJWtToken() => await _localStorageService.GetItemAsync<string>("JWTToken");

    private async Task PrepareLoginStorage(string token)
    {
        await _localStorageService.SetItemAsync<string>("JWTToken", token);
        //await _localStorageService.RemoveItemAsync("CurrentUser");
        await _localStorageService.SetItemAsync<bool>("IsAuthenticated", true);
    }
    private async Task PrepareLogoutStorage()
    {
        await _localStorageService.RemoveItemAsync("JWTToken");
        //await _localStorageService.RemoveItemAsync("CurrentUser");
        await _localStorageService.SetItemAsync<bool>("IsAuthenticated", false);
    }

    public async Task LogOut()
    {

        await PrepareLogoutStorage();

        await _client.GetAsync("api/Authentication/logout");
        navigation.NavigateTo("/login", true);

    }

    //public bool IsAuthenticated()=>_authenticationProvider.

    //public async Task<User?> GetCurrentUser() => await _authenticationProvider.GetCurrentUser();
}