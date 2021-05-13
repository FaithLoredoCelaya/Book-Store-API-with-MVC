using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSotrAPIwithMVC.Models;
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

namespace BookSotrAPIwithMVC
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
            //This is a fake database we can use 
            services.AddDbContext<BookContext>(opt => opt.UseInMemoryDatabase("Book"));
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { 
                Title="Book API",
                Description="A book List example",
                TermsOfService=new Uri("https://twitter.com/Dragonkitten555"),
                Contact= new OpenApiContact { Name="Amber",Email="notfake@notfake.com"},
                License = new OpenApiLicense
                {
                    Name="Under my Licence",
                    Url = new Uri("https://twitter.com/Dragonkitten555")
                },
                Version="V1" 
            }));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API version 1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
