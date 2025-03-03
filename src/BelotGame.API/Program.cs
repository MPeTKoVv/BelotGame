using BelotGame.API.Data;
using BelotGame.API.Hubs;
using Microsoft.EntityFrameworkCore;

namespace BelotGame.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSignalR();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
