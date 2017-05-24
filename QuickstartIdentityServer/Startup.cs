using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace QuickstartIdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // identity server configuration - ready for Client api calls
            services.AddIdentityServer()
                    .AddTemporarySigningCredential()
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddInMemoryClients(Config.GetClients())            // Add our hard-coded Client
                    .AddTestUsers(Config.GetUsers());                   // Add our hard-coded Users

            // MVC Client
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            // middleware for google authentication
            app.UseGoogleAuthentication(new GoogleOptions
            {
                AuthenticationScheme = "Google",
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
                ClientId = "708996912208-9m4dkjb5hscn7cjrn5u0r4tbgkbj1fko.apps.googleusercontent.com",
                ClientSecret = "wdfPY6t8H8cecgjlxud__4Gh"
            });

            // middleware for external openid connect authentication
            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
                SignOutScheme = IdentityServerConstants.SignoutScheme,

                DisplayName = "OpenID Connect",
                Authority = "https://demo.identityserver.io/",
                ClientId = "implicit",

                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                }
            });

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
