var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString)
                                                                      .EnableDetailedErrors()
                                                                      .EnableSensitiveDataLogging()
                                                                      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                                                        );



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(option =>
                                            {
                                                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                                                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                            })
                                            .AddCookie(option=> option.LoginPath="/login")
                                            .AddJwtBearer(option =>
                                            {
                                                option.RequireHttpsMetadata = true;
                                                option.SaveToken = true;
                                                option.TokenValidationParameters = new TokenValidationParameters
                                                {
                                                    ValidateIssuerSigningKey = true,
                                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTSettings:SecretKey"])),
                                                    ValidateIssuer = false,
                                                    ValidateAudience = false,
                                                    ClockSkew = TimeSpan.Zero
                                                };
                                            });

builder.Services.AddTransient<ILogRepository, LogRepository>();
builder.Services.AddTransient<ILogUnitOfWork, LogUnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IMessageUnitOfWork, MessageUnitOfWork>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherUnitOfWork, TeacherUnitOfWork>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectUnitOfWork, SubjectUnitOfWork>();

builder.Services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
builder.Services.AddScoped<IClassRoomUnitOfWork, ClassRoomUnitOfWork>();

builder.Services.AddScoped<IClassRoomStudentRepository, ClassRoomStudentRepository>();
builder.Services.AddScoped<IClassRoomStudentUnitOfWork, ClassRoomStudentUnitOfWork>();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseCors();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chathub");
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();