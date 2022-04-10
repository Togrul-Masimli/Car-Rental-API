using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

public class Program
{
    public static void Main(string[] args)
    {
        new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables();
            })
            .ConfigureServices(s =>
            {
                var authenticationProviderKey = "MyOcelot";

                Action<JwtBearerOptions> options = o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;

                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidIssuer = JWTModel.Issuer,
                        ValidAudience = JWTModel.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTModel.Key))
                    };
                };
                
                s.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = authenticationProviderKey;
                    option.DefaultChallengeScheme = authenticationProviderKey;
                }).AddJwtBearer(authenticationProviderKey, options);

                s.AddOcelot();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
            })
            .UseIISIntegration()
            .Configure(app =>
            {
                app.UseOcelot().Wait();
            })
            .UseUrls("https://localhost:5001/")
            .Build()
            .Run();
    }
}

public static class JWTModel
{
    public static string Key = "mysupersecretkeymysupersecretkey";
    public static string Issuer = "togrul@gmail.com";
    public static string Audience = "www.togrul.com";
}