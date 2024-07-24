using ariel_my_friend.Data;
using Microsoft.EntityFrameworkCore;

namespace ariel_my_friend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Ariel: defining db context with the connection string from the configuration
            // Ariel: look up for appsettings.json
            builder.Services.AddDbContext<ApplicationDbContext>(
                opitons => opitons.UseSqlServer(
                    // Ariel: you can simply replcae this with the original connection string
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection"
                    )
                )
            );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
    }
}
