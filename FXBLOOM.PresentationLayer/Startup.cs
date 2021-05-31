using FXBLOOM.ApplicationLayer;
using FXBLOOM.DataLayer;
using FXBLOOM.DataLayer.Context;
using FXBLOOM.InfrastructureLayer;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer
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
            services.AddSingleton<ILog, LogNLog>();
            services.AddControllers();
           
            var connStr = Configuration.GetConnectionString("FXBLOOMConnectionString");

            services.AddDbContext<FXBloomContext>(options =>
            {
                options.UseSqlServer("server=DESKTOP-74QMUAQ\\TEW_SQLEXPRESS;database=FxBloom;Trusted_Connection=true;");
            });

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };


            services.AddMvc(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                config.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            }

                ).SetCompatibilityVersion(CompatibilityVersion.Latest)

            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = false;

                //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
            });

            services.InfrastructureLayerServices();
            services.DataLayerServices();
            services.ApplicationLayerServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Contact = new OpenApiContact
                    {
                        Email = "",
                        Name = "FXBLOOM"
                    },
                    Description = "Web API Documentation For FXBLOOM",
                    Title = "FXBLOOM API",
                    Version = "Version 1"
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Enter the word 'Bearer' into field",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});

                //c.AddSecurityDefinition("Token", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Enter token generated after signing in",
                //    Name = "fxbloom-token",
                //    Type = SecuritySchemeType.ApiKey
                //});

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "apiKey",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        },
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Token"
                                },
                                Scheme = "apiKey",
                                Name = "Token",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                                         name: "default",
                                        pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "FXBLOOM API"); //../swagger
            });
        }
    }
}
