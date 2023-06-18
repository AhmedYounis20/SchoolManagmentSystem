namespace StudentAffairWeb.Client;

public class HYAuthorizationHandler: DelegatingHandler
{
    public ILocalStorageService _localStorageService { get; set; }
    public HYAuthorizationHandler(ILocalStorageService localStorageService)=> _localStorageService = localStorageService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        string jwtToken = await _localStorageService.GetItemAsync<string>("JWTToken");
        if (!string.IsNullOrEmpty(jwtToken))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",jwtToken);


        return await base.SendAsync(request, cancellationToken);
    }
}
