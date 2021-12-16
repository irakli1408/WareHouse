using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WareHouse.Interfaces;
using WareHouse.Services;
using WareHouseLibrary.Mappings.Mappings;
using WareHouseLibrary.WareHouseContext;
using WarHouse.Interfaces;
using WarHouse.Repositories;
using WarHouse.Services;

namespace WarHouse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

     
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddDbContext<WHDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WRHH"));
            });

            //services.AddHangfire(h => h.UseSqlServerStorage("server=DGA-086E1;database=WareHouseDataBase;Trusted_Connection=True;"));

           // services.AddHangfireServer();

            services.AddScoped<IMport, ImportToExcelService>();

          //  services.AddScoped<IJobLogic, JobLogicService>();

            services.AddScoped<IFilter, FilterMethod>();

            services.AddScoped<IExcelFileCheck, importExcelFIleCheck>();

            services.AddAutoMapper(typeof(DataMappingProfile));

            services.AddRazorPages();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

           // app.UseHangfireDashboard("/dashboard");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
