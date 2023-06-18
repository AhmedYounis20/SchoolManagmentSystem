namespace StudentAffairWeb.Client
{
    public class HYAuthenticationStateProvider : AuthenticationStateProvider
    {
        HttpClient _client { get; set; }
        ILocalStorageService _localStorageService;
        public HYAuthenticationStateProvider(HttpClient client, ILocalStorageService localStorageService) { 
            _client = client;
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            // get dataof current user 
            User? loggedInUser = await GetCurrentUser();//await _client.GetFromJsonAsync<User>("api/user/CurrentUser");
            if(loggedInUser is not null && !string.IsNullOrEmpty(loggedInUser.Name))
            {

            // claims 
            Claim claimName = new Claim(ClaimTypes.Name, loggedInUser.Name);
            Claim claimIdentifier = new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString());
            Claim claimEmail = new Claim(ClaimTypes.Email, loggedInUser.Email ?? "");
            Claim claimRole= new Claim(ClaimTypes.Role, loggedInUser.SecurityRole.ToString() ?? "");
                Console.WriteLine($"{claimRole} ,------------ , {nameof(SecurityRole.Admin)}");
            // claimIdentity
            ClaimsIdentity claimIdentity = new ClaimsIdentity(new[] {claimName,claimIdentifier,claimEmail,claimRole}, "serverAuth");

            //claimsprincipal 
            ClaimsPrincipal claimsPrincipal =  new ClaimsPrincipal(claimIdentity);

            // authenticationState
            return new AuthenticationState(claimsPrincipal);
            }
            await _localStorageService.SetItemAsync<bool>("IsAuthenticated", false);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task<User?> GetCurrentUser()
        {
            User? user;
            if (!string.IsNullOrEmpty(await _localStorageService.GetItemAsStringAsync("JWTToken")))
                user = await GetUserByJwtAsync();
            else 
                user = await GetCurrentUserByCookie();

        return user;
        }

        private async Task<User?> GetUserByJwtAsync()
        {
            string jwtToken = await _localStorageService.GetItemAsStringAsync("JWTToken");
            if (jwtToken is null)
                return null;
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/Authentication/getuserbyJwt");
            requestMessage.Content = new StringContent(jwtToken);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage responseMessage = await _client.SendAsync(requestMessage);
            HttpStatusCode responseStatusCode = responseMessage.StatusCode;
            User? user = await responseMessage.Content.ReadFromJsonAsync<User>(); 


            return user is null ? null : await Task.FromResult(user);

        }

        public async Task<User?> GetCurrentUserByCookie()
            => await _client.GetFromJsonAsync<User>("api/Authentication/CurrentUser");

    }
}