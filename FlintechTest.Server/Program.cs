using FlintechTest.Server.Interface;
using FlintechTest.Server.Models;
using FlintechTest.Server.Services;
using Microsoft.AspNetCore.Builder;

namespace FlintechTest.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient(typeof(IRestRequest<>), typeof(RestRequest<>));

            builder.Services.AddOptions();
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
