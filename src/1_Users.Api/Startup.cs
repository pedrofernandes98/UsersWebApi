using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Users.Api.ViewModels;
using Users.Domain.Entities;
using Users.Infra.Context;
using Users.Infra.Interfaces;
using Users.Infra.Repositories;
using Users.Services.DTO;
using Users.Services.Interfaces;
using Users.Services.Services;

namespace Users.Api
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
            services.AddControllers();

            //Configuração da injeção de dependência do AutoMapper
            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>().ReverseMap();
                c.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
                c.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion

            #region EFCore
            services.AddDbContext<UsersContext>
            (
                options =>
                options.UseSqlServer(Configuration["ConnectionStrings:WEBAPIDB"]),
                ServiceLifetime.Transient
            );
            #endregion

            #region AddScoped
            services.AddScoped<IUserService, UserService>(); //Uma instância única por requisição
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
