using Logs;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Services;

namespace proyectoLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            LoggerConfig.ConfigureLogger(configuration);
            Log.Logger = LoggerConfig.Logger;
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseSerilog();
                builder.Services.AddControllersWithViews();
                builder.Services.AddScoped<ILogica, Servicio>();
                var app = builder.Build();
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseAuthorization();
                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


    }
}
