using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using TalabatRepository.Data;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configure Kestrel Server
            // Add services to the container.
            webApplicationBuilder.Services.AddControllers();

            // Swagger
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();
              
            webApplicationBuilder.Services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            var app = webApplicationBuilder.Build();

            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreContext>();
            //Ask CLS To Crating Object From DBContext Explicitly 

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await context.Database.MigrateAsync(); //Update-Database
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }

            #region Configure Kestrel Middleware

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            #endregion

            app.Run();

        }
    }
}