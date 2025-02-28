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

            builder.Services.AddDbContext<BelotGameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Enable CORS for frontend connection
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Add SignalR
            builder.Services.AddSignalR();

            var app = builder.Build();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<GameHub>("/gameHub"); // Register SignalR Hub

            app.Run();

        }
    }
}
