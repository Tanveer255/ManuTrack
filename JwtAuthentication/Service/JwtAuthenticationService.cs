using JwtAuthentication.Request;

namespace JwtAuthentication.Service;
public interface IJwtAuthenticationService
{

    public string GenerateJwtToken(GenerateTokenRequest generateTokenRequest);
    public Task<RefreshTokenRequest> RefreshTokenAsync(GenerateTokenRequest generateTokenRequest);
}

public class JwtAuthenticationService : IJwtAuthenticationService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IConfiguration _configuration;

    public JwtAuthenticationService(IOptions<JwtSettings> jwtSettings, IConfiguration configuration)
    {
        _jwtSettings = jwtSettings.Value;
        _configuration = configuration;
    }

    public string GenerateJwtToken(GenerateTokenRequest request)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.Email, request.Email),
        // Add more claims if needed
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<RefreshTokenRequest> RefreshTokenAsync(GenerateTokenRequest tokenRequest)
    {
        var claims = new List<Claim>
     {
         new Claim(ClaimTypes.Email, tokenRequest.Email),
         new Claim(ClaimTypes.NameIdentifier, tokenRequest.UserId.ToString())
     };

        var newRefreshToken = GenerateJwtToken(tokenRequest);

        var token = new RefreshTokenRequest
        {
            RefreshToken = newRefreshToken,
            RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryTime)
        };

        return token;
    }
}
