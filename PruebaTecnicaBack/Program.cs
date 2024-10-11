using Data.Data;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBack.Interfaces;
using PruebaTecnicaBack.Services;

namespace PruebaTecnicaBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddScoped<IProducto, ProductoService>();

            builder.Services.AddDbContext<TiendaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
