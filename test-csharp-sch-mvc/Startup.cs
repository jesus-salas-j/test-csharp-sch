using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using test_csharp_sch_application.contracts;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_application.services;
using test_csharp_sch_infrastructure;

namespace test_csharp_sch_mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSession(options =>
                options.IdleTimeout = TimeSpan.FromMinutes(1));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Signin}/{id?}");
            });
        }
    }
}
