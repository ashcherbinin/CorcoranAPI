using System;
using CorcoranAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static CorcoranAPI.Models.PresidentModel;

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

           
            services.AddDbContext<PresidentContext>(opt => opt.UseInMemoryDatabase("PresidentDB"));

            //add dependency injection
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

            // in-memory database seed 
            SeedDatabase(app);

            app.UseMvc();
        }

        // 
        private static void SeedDatabase(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PresidentContext>();


                context.Presidents.AddRange(
                     
                    new President { Id = new Guid(), president = "James Madiso", birthday = "1751-3-16", birthplace = "Port Conway, Va.", deathday = "1836-6-28", Deathplace = "Orange Co., Va." },
                    new President { Id = new Guid(), president = "James Monroe", birthday = "1758-4-28", birthplace = "Westmoreland Co., Va.", deathday = "1831-7-4", Deathplace = "New York, New York" },
                    new President { Id = new Guid(), president = "John Quincy Adams", birthday = "1767-7-11", birthplace = "Quincy Mass.", deathday = "1848-2-23", Deathplace = "Washington, D.C." },
                    new President { Id = new Guid(), president = "Andrew Jackson", birthday = "1767-3-15", birthplace = "Waxhaws, No./So. Carolina", deathday = "1845-6-8", Deathplace = "Nashville, Tennessee" },
                    new President { Id = new Guid(), president = "Martin Van Buren", birthday = "1782-12-5", birthplace = "Kinderhook, New York", deathday = "1862-7-24", Deathplace = "Kinderhook, New York" },
                    new President { Id = new Guid(), president = "William Henry Harrison", birthday = "1773-2-9", birthplace = "Charles City Co., Va.", deathday = "1841-4-4", Deathplace = "Washington, D.C." },
                    new President { Id = new Guid(), president = "John Tyler", birthday = "1790-3-29", birthplace = "Charles City Co., Va.", deathday = "1862-1-18", Deathplace = "Richmond, Va." },
                    new President { Id = new Guid(), president = "James K. Polk", birthday = "1795-11-2", birthplace = "Mecklenburg Co., N.C.", deathday = "1849-6-15", Deathplace = "Nashville, Tennessee" },
                    new President { Id = new Guid(), president = "Zachary Taylor", birthday = "1784-11-24", birthplace = "Orange County, Va.", deathday = "1850-7-9", Deathplace = "Washington, D.C" },
                    new President { Id = new Guid(), president = "MillardFillmore", birthday = "1800-1-7", birthplace = "Cayuga Co., New York", deathday = "1874-3-8", Deathplace = "Buffalo, New York" },
                    new President { Id = new Guid(), president = "Franklin Pierce", birthday = "1804-11-23", birthplace = "Hillsborough, N.H.", deathday = "1869-10-8", Deathplace = "Concord, New Hamp." },
                    new President { Id = new Guid(), president = "James Buchanan", birthday = "1791-4-23", birthplace = "Cove Gap, Pa.", deathday = "1868-6-1", Deathplace = "Lancaster, Pa." },
                    new President { Id = new Guid(), president = "Abraham Lincoln", birthday = "1809-2-12", birthplace = "LaRue Co., Kentucky", deathday = "1865-4-15", Deathplace = "Washington, D.C." },
                    new President { Id = new Guid(), president = "Andrew Johnson", birthday = "1808-12-29", birthplace = "Raleigh, North Carolina", deathday = "1875-7-31", Deathplace = "Elizabethton, Tenn." },
                    new President { Id = new Guid(), president = "Ulysses S. Grant", birthday = "1822-4-27", birthplace = "Point Pleasant, Ohio", deathday = "1885-7-23", Deathplace = "Wilton, New York" },
                    new President { Id = new Guid(), president = "Rutherford B. Hayes", birthday = "1822-10-4", birthplace = "Delaware, Ohio", deathday = "1893-1-17", Deathplace = "Fremont, Ohio" },
                    new President { Id = new Guid(), president = "James A. Garfield", birthday = "1831-11-19", birthplace = "Cuyahoga Co., Ohio", deathday = "1881-9-19", Deathplace = "Elberon, New Jersey" },
                    new President { Id = new Guid(), president = "Chester Arthur", birthday = "1829-10-5", birthplace = "Fairfield, Vermont", deathday = "1886-11-18", Deathplace = "New York, New York" },
                    new President { Id = new Guid(), president = "Grover Cleveland", birthday = "1837-3-18", birthplace = "Caldwell, New Jersey", deathday = "1908-6-24", Deathplace = "Princeton, New Jersey" },
                    new President { Id = new Guid(), president = "Benjamin Harrison", birthday = "1833-8-20", birthplace = "North Bend, Ohio", deathday = "1901-3-13", Deathplace = "Indianapolis, Indiana" },
                    new President { Id = new Guid(), president = "William McKinley", birthday = "1843-1-29", birthplace = "Niles, Ohio", deathday = "1901-9-14", Deathplace = "Buffalo, New York" },
                    new President { Id = new Guid(), president = "Theodore Roosevelt", birthday = "1858-10-27", birthplace = "New York, New York", deathday = "1919-1-6", Deathplace = "Oyster Bay, New York" },
                    new President { Id = new Guid(), president = "William Howard Taft", birthday = "1857-9-15", birthplace = "Cincinnati, Ohio", deathday = "1930-3-8", Deathplace = "Washington, D.C." },
                    new President { Id = new Guid(), president = "Woodrow Wilson", birthday = "1856-12-28", birthplace = "Staunton, Virginia", deathday = "1924-2-3", Deathplace = "Washington, D.C." },
                    new President { Id = new Guid(), president = "Warren G. Harding", birthday = "1865-11-2", birthplace = "Morrow County, Ohio", deathday = "1923-8-2", Deathplace = "San Francisco, Cal." },
                    new President { Id = new Guid(), president = "Calvin Coolidge", birthday = "1872-7-4", birthplace = "Plymouth, Vermont", deathday = "1933-1-5", Deathplace = "Northampton, Mass." },
                    new President { Id = new Guid(), president = "Herbert Hoover", birthday = "1874-8-10", birthplace = "West Branch, Iowa", deathday = "1964-10-20", Deathplace = "New York, New York" },
                    new President { Id = new Guid(), president = "Franklin Roosevelt", birthday = "1882-1-30", birthplace = "Hyde Park, New York", deathday = "1945-4-12", Deathplace = "Warm Springs, Georgia" },
                    new President { Id = new Guid(), president = "Harry S. Truman", birthday = "1884-5-8", birthplace = "Lamar, Missouri", deathday = "1972-12-26", Deathplace = "Kansas City, Missouri" },
                    new President { Id = new Guid(), president = "Dwight Eisenhower", birthday = "1890-10-14", birthplace = "Denison, Texas", deathday = "1969-3-28", Deathplace = "Washington, D.C." },
                    new President { Id = new Guid(), president = "John F. Kennedy", birthday = "1917-5-29", birthplace = "Brookline, Mass.", deathday = "1963-11-22", Deathplace = "Dallas, Texas" },
                    new President { Id = new Guid(), president = "Lyndon B. Johnson", birthday = "1908-8-27", birthplace = "Gillespie Co., Texas", deathday = "1973-1-22", Deathplace = "Gillespie Co., Texas" },
                    new President { Id = new Guid(), president = "Richard Nixon", birthday = "1913-1-9", birthplace = "Yorba Linda, Cal.", deathday = "1994-4-22", Deathplace = "New York, New York" },
                    new President { Id = new Guid(), president = "Gerald Ford", birthday = "1913-7-14", birthplace = "Omaha, Nebraska", deathday = "2006-12-26", Deathplace = "Rancho Mirage, Cal." },
                    new President { Id = new Guid(), president = "Jimmy Carter", birthday = "1924-10-1", birthplace = "Plains, Georgia", deathday = "", Deathplace = "" },
                    new President { Id = new Guid(), president = "Ronald Reagan", birthday = "1911-2-6", birthplace = "Tampico, Illinois", deathday = "2004-6-5", Deathplace = "Los Angeles, Cal." },
                    new President { Id = new Guid(), president = "George Bush", birthday = "1924-6-12", birthplace = "Milton, Mass.", deathday = "", Deathplace = "" },
                    new President { Id = new Guid(), president = "Bill Clinton", birthday = "1946-8-19", birthplace = "Hope,Arkansas", deathday = "", Deathplace = "" },
                    new President { Id = new Guid(), president = "George W. Bush", birthday = "1646-7-6", birthplace = "New Haven, Conn.", deathday = "", Deathplace = "" },
                    new President { Id = new Guid(), president = "Barack Obama", birthday = "1961-8-4", birthplace = "Honolulu, Hawaii", deathday = "", Deathplace = "" }, 
                    new President { Id = new Guid(), president = "Donald Trump", birthday = "1946-6-14", birthplace = "New York, New York", deathday = "", Deathplace = "" }                                                                                          

                   );
                   
                context.SaveChangesAsync();             
                 
            }
        }

    }
}
