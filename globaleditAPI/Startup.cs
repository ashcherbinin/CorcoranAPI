using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorcoranAPI.Models;
using CorcoranAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static CorcoranAPI.Models.PresidentModel;

//using static CorcoranAPI.Models.PresidentModel;

namespace CorcoranAPI
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
           
            //var connection = Configuration.GetConnectionString("VisitorDb");
            services.AddDbContext<PresidentContext>(opt => opt.UseInMemoryDatabase("PresidentDB"));

            //regestering dependency injection
            services.AddScoped<IPresidentRepository, PresidentRepository>();


            services.AddMvc();
        }

      
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Calling in-memory database seed 
            SeedDatabase(app);

            app.UseMvc();
        }


        private static void SeedDatabase(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PresidentContext>();


                context.Presidents.AddAsync(
                     
                    new PresidentList {Id = new Guid(), president = "James Madiso", birthday = "1751-3-16", birthplace = "Port Conway, Va.", deathday = "1836-6-28", Deathplace = "Orange Co., Va." }
               
                   );
                context.SaveChangesAsync();             

            
            }
        }

    }
}
