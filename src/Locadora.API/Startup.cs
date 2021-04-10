using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Locadora.API.Token;
using Locadora.API.ViewModels;
using Locadora.API.ViewModels.Aluguel;
using Locadora.API.ViewModels.Carro;
using Locadora.API.ViewModels.Cliente;
using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using Locadora.Infra.Repositories;
using Locadora.Services.DTO;
using Locadora.Services.Interfaces;
using Locadora.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Locadora.API
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
            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Locadora API",
                    Version = "v1",
                    Description = "API construída com DDD e JWT.",
                    Contact = new OpenApiContact
                    {
                        Name = "Eduardo Lemos",
                        Email = "joseeduardo0131@gmail.com"
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            #endregion

            #region Jwt
            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Carro, CarroDTO>().ReverseMap();
                cfg.CreateMap<CriarCarroViewModel, CarroDTO>().ReverseMap();
                cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap();
                cfg.CreateMap<CriarClienteViewModel, ClienteDTO>().ReverseMap();
                cfg.CreateMap<Aluguel, AluguelDTO>().ReverseMap();
                cfg.CreateMap<CriarAluguelViewModel, AluguelDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion

            #region DI
            services.AddSingleton(d => Configuration);
            services.AddDbContext<LocadoraContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:LOCADEVAPI"]), ServiceLifetime.Transient);
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAluguelService, AluguelService>();
            services.AddScoped<IAluguelRepository, AluguelRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
