using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace OnlineLearning.API
{
    public static class JwtHelper
    {
        private static readonly SymmetricSecurityKey _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppConfig.JwtKey));
        private static readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        // Define a constant for the custom user claim type
        public const string UserDataClaimType = "userData";

        public static string GetNewToken(User user)
        {
            // Create a slim user object with just the properties we need
            var slimUser = new { user.Id, user.Name, user.Email };

            // Serialize the user object to JSON with camelCase property names
            string userJson = JsonSerializer.Serialize(slimUser, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(UserDataClaimType, userJson),  // Store the entire user object in a custom claim
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
            };

            // If user has a name, add it as a claim
            if (!string.IsNullOrEmpty(user.Name))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
            }

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(AppConfig.JwtExpireHours),
                SigningCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512)
            };

            SecurityToken securityToken = _handler.CreateToken(descriptor);
            return _handler.WriteToken(securityToken);
        }

        public static void SetBearerOptions(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _symmetricSecurityKey,
                NameClaimType = ClaimTypes.NameIdentifier, // Ensures we extract user ID
            };
        }
    }
}