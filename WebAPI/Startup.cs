using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json.Serialization;

using WebAPI.Data;
using Microsoft.AspNetCore.HttpOverrides;

namespace WebAPI
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
            services.AddDbContext<WebAPI_Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<I_WebAPI_Repo, SQL_WebAPI_Repo>();
            
            services.AddMvc();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.All;
            });
            
            // Enable CORS
            services.AddCors();

            // Swagger
            services.AddSwaggerDocument(config => {
                config.PostProcess = document => {
                    document.BasePath = "/WebAPI";
                    document.Info.Version = "v1";
                    document.Info.Title = "WebAPI";
                    document.Info.Description = "";
                    document.Info.TermsOfService = "";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Andrew Pennington",
                        Email = "andrew.pennington@capgemini.com"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UsePathBase(new Microsoft.AspNetCore.Http.PathString("/WebAPI"));
            
            app.UseForwardedHeaders();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Swagger Front End
            NSwag.AspNetCore.SwaggerUi3Route swaggerRoute;
            if (env.IsDevelopment()) 
            { swaggerRoute = new NSwag.AspNetCore.SwaggerUi3Route("v1", "/swagger/v1/swagger.json"); }
            else { swaggerRoute = new NSwag.AspNetCore.SwaggerUi3Route("v1", "/WebAPI/swagger/v1/swagger.json"); }
            app.UseOpenApi(config => {
                config.PostProcess = (d, _) => { d.BasePath = "/WebAPI"; };
            });
            app.UseSwaggerUi3(config => {
                config.SwaggerRoutes.Add(swaggerRoute);
            });
        }
    }
}
