var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();


builder.Services.AddTransient<HYAuthorizationHandler>();

builder.Services.AddScoped<HYAuthorizationHandler>();
builder.Services.AddHttpClient("StudentAffairWeb",
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<HYAuthorizationHandler>();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("StudentAffairWeb"));

builder.Services.AddScoped<AuthenticationStateProvider,HYAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthServices,AuthServices>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
