using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesWebMvc.Data;
using SalesWebMvc.Service;

namespace SalesWebMvc
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
            services.AddControllersWithViews();
            services.AddDbContext<SalesWebMvcContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("SalesWebMvcContext")));

            // Registrando o servi�o na inje��o de depend�ncia
            services.AddScoped<SeedingService>();
            services.AddScoped<SellerService>();
            services.AddScoped<DeparmentService>();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();   // Preechendo o banco de dados caso n�o tenha nenhum registro.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");              
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
