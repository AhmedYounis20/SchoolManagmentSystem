namespace StudentAffairWeb.Server;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : BaseSettingController<User>
{
    IUserUnitOfWork _userUnitOfWork;
    private readonly IConfiguration _configuration;
    public AuthenticationController(IUserUnitOfWork unitOfWork, IConfiguration configuration) : base(unitOfWork)
    {
        _userUnitOfWork = unitOfWork;
        _configuration = configuration;
    }
    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(LoginRequest loginRequest, [FromQuery] bool rememberMe = false, [FromQuery] int ExprireInDays = 5)
    {
        User? dbSystemUser = (await _userUnitOfWork.Read()).FirstOrDefault(e => e.Email == loginRequest.Email && e.Password == loginRequest.Password) ?? new();
        try
        {
            if (dbSystemUser != null)
            {
                Claim claimName = new Claim(ClaimTypes.Name, dbSystemUser.Name ?? "");
                Claim claimEmail = new Claim(ClaimTypes.Email, dbSystemUser.Email ?? "");
                Claim claimIdentifer = new Claim(ClaimTypes.NameIdentifier, dbSystemUser.Id.ToString());
                Claim claimRole = new Claim(ClaimTypes.Role, dbSystemUser.SecurityRole.ToString());

                ClaimsIdentity claimIdentity = new ClaimsIdentity(new[] { claimName, claimIdentifer, claimEmail, claimRole }, "serverAuth");
                ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(claimPrincipal, GetAuthenticationProperties(rememberMe, ExprireInDays));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return Ok(dbSystemUser ?? new());
    }

    [HttpGet("logout")]
    public async Task<ActionResult> Logout()
    {
        try
        {
            if (User?.Identity?.IsAuthenticated ?? false)
                await HttpContext.SignOutAsync();
            else
                return Unauthorized();
        }
        catch (Exception ex)
        {
            return Ok(ex);
        }
        return Ok("signed Out Successfully");

    }

    [HttpGet("currentuser")]
    public async Task<ActionResult<User>> GetCurrentUser()
    {
        User user = new();
        try
        {
            if (User?.Identity?.IsAuthenticated ?? false)
                user = await _userUnitOfWork.Read(new Guid(User?.Claims.Where(e => e.Type == ClaimTypes.NameIdentifier).Select(e => e.Value).FirstOrDefault() ?? ""));
        }
        catch (Exception ex)
        {
            return Ok(ex);
        }
        return Ok(user);
    }

    private AuthenticationProperties GetAuthenticationProperties(bool rememberMe = false, int ExprireInDays = 5)
    =>
        new AuthenticationProperties
        {
            IsPersistent = rememberMe,
            ExpiresUtc = DateTime.UtcNow.AddDays(ExprireInDays),
            RedirectUri = "/user/login"
        };


    /////// JWT Section
    // getcurrent User
    [HttpPost("getuserbyJwt")]
    public async Task<ActionResult<User>> GetUserByJwt([FromBody] string jwtToken)
    {
        try
        {
            string secretKey = _configuration["JWTSettings:SecretKey"];
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token;
            ClaimsPrincipal principle = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out token);
            JwtSecurityToken jwtValidatedToken = (JwtSecurityToken)token;
            if (jwtValidatedToken is not null && jwtValidatedToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return (await _userUnitOfWork.Read(new Guid((string)(principle?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""))));
            }
        }
        catch (Exception ex)
        {
            //logging the error and returning null
            Console.WriteLine("Exception : " + ex.Message);
            return Ok("not found");
        }

        return Ok("not found");
    }


    // login with JWT
    [HttpPost("AuthenticateJWT")]
    public async Task<JWTResponse> AuthenticateJWT(LoginRequest loginRequest)
    {
        string token = string.Empty;
        User? loggedinUser = (await _userUnitOfWork.Read()).FirstOrDefault(e => e.Email == loginRequest.Email && e.Password == loginRequest.Password);
        if (loggedinUser is not null)
            token = GenerateJWTToken(loggedinUser);
        return await Task.FromResult(new JWTResponse { Token = token });
    }


    //Migrating to JWT Authorization...
    private string GenerateJWTToken(User user)
    {
        string secretKey = _configuration["JWTSettings:SecretKey"];
        byte[] key = Encoding.ASCII.GetBytes(secretKey);

        Claim claimName = new Claim(ClaimTypes.Name, user.Name ?? "");
        Claim claimEmail = new Claim(ClaimTypes.Email, user.Email ?? "");
        Claim claimIdentifer = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
        Claim claimRole = new Claim(ClaimTypes.Role, user.SecurityRole.ToString());

        ClaimsIdentity claimIdentity = new ClaimsIdentity(new[] { claimName, claimIdentifer, claimEmail, claimRole }, "serverAuth");

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimIdentity,
            Expires = DateTime.UtcNow.AddDays(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
