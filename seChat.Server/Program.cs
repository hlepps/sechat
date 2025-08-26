
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using seChat.Server.Data;

namespace seChat.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContextPool<UserContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.MapStaticAssets();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.MapDefaultControllerRoute();


            app.Run();
        }
    }
}
