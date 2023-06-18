namespace StudentAffairWeb.Client;

public interface IAuthServices
{
    public Task<User?> LoginCookie(LoginRequest loginRequest, bool rememberMe = false, int ExpireInDays = 5);
    public Task<JWTResponse?> AuthenticateJWT(LoginRequest loginRequest, bool rememberMe = false, int ExpireInDays = 5);
    public Task LogOut();
    public Task<string> GetJWtToken();
    //public Task<User?> GetCurrentUser();
}