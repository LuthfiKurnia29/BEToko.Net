using System.Text;
using System.Text.Json.Serialization;
using application;
using infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace api;

/// <summary>
/// Startup Class Configuration
/// </summary>
public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        services.AddApplicationServices();
        services.AddInfrastructureServices(_configuration);
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKeyForThisWeb")),
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = "Token For Admin",
            };
        });
        services.AddOpenApiDocument((configure, serviceProvider) =>
        {
            configure.Title = "API";
            configure.Version = "1";
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
            {
                Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                Description = "Type Into the textbox"
            });
        });
    }

    /// <summary>
    /// Config
    /// </summary>
    /// <param name="appBuilder"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder appBuilder, IWebHostEnvironment env)
    {
        appBuilder.UseOpenApi();
        if (env.IsDevelopment())
        {
            appBuilder.UseSwaggerUi(c =>
            {
                c.Path = "/swagger";
                c.EnableTryItOut = true;
            });
        }
        
        appBuilder.UseRouting();
        
        appBuilder.UseHttpsRedirection();

        appBuilder.UseAuthentication();

        appBuilder.UseAuthorization();
        
        appBuilder.UseEndpoints(endpoint => { endpoint.MapControllers(); });

    }
}