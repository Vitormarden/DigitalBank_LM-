using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DigitalBank_LM.Data;
using DigitalBank_LM.Repositorys;
using DigitalBank_LM.Repositorys.Interfaces;
using DigitalBank_LM.Services;
using DigitalBank_LM.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace DigitalBank_LM
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
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IContaBancariaServices, ContaBancariaServices>();
            services.AddScoped<IContaBancariaRepository,ContaBancariaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddDbContext<Context>();

            services.AddSwaggerGen(
                    c => {
                            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                            var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name+".xml";
                            var xml = Path.Combine(basePath, fileName);
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Digital Bank API", Version = "v1" });

                            c.IncludeXmlComments(xml);
                    }
                    );

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
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
            c => {
                c.RoutePrefix = String.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            }
            );


        }
    }
}
