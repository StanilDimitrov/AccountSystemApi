using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Core.Dal;
using SampleApp.Core.Dal.Contracts;
using SampleApp.Core.Data;
using SampleApp.Core.Utilities.Extensions;
using System.Reflection;

namespace SampleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var assembly = Assembly.Load("SampleApp.Controllers");

            services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAccountService, AccountService>();

            var handlersAssembly = Assembly.Load("SampleApp.Handlers");
            services.AddMediatR(handlersAssembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
