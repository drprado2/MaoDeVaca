using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaoDeVaca.Domain.Interfaces;
using MaoDeVaca.Domain.Services;
using MaoDeVaca.Infra;
using MaoDeVaca.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaoDeVaca.Api
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
            // Postgres
            //services
            //    .AddEntityFrameworkNpgsql()
            //    .AddDbContext<MaoDeVacaDbContext>(x => x.UseNpgsql(Configuration.GetConnectionString("MaoDeVaca")));

            services.AddDbContext<MaoDeVacaDbContext>(opt => opt.UseInMemoryDatabase());

            RegisterDependencyInjection(services);

            services.AddMvc();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials()
            );

            app.UseMvcWithDefaultRoute();
        }

        private void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<MaoDeVacaDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<ICommandQueryHandler, CommandQueryHandler>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
