using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetApi.Application.Queries;
using PetApi.Persistence.Database;

namespace PetApi
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

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            services.AddMediatR(typeof(GetPetQuery));

            services.AddScoped<IPetDatabase, SampleDatabase>(config =>
            {
                return new SampleDatabase(new List<Contracts.Models.Pet>()
                {
                    new Contracts.Models.Pet() { Id = 1, Name = "Zack", Species = Contracts.Models.Species.Cat, DateOfBirth = new DateTime(2009, 01, 01)},
                    new Contracts.Models.Pet() { Id = 2, Name = "Ziggy", Species = Contracts.Models.Species.Cat, DateOfBirth = new DateTime(2010, 05, 01)},
                    new Contracts.Models.Pet() { Id = 3, Name = "Stan", Species = Contracts.Models.Species.Cat, DateOfBirth = new DateTime(2012, 04, 15)},
                    new Contracts.Models.Pet() { Id = 4, Name = "Zelda", Species = Contracts.Models.Species.Dog, DateOfBirth = new DateTime(2007, 08, 03)}
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
