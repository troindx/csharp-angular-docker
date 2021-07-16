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
using Microsoft.OpenApi.Models;
using Translator.Services;

namespace Translator
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
            var apikey = this.Configuration["GoogleApiKey"];

            //Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("FreeForAll",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
                 options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://www.contoso.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });

            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Translator", Version = "v1" });
            });
            services.AddSingleton<GoogleTranslateService>( x => new GoogleTranslateService(apikey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Translator v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("FreeForAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
