using MahalliyMarket.Data;
using MahalliyMarket.Mappings;
using MahalliyMarket.Services;
using MahalliyMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MahalliyMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MahalliyDBContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                if ( string.IsNullOrEmpty(connectionString) )
                {
                    throw new InvalidOperationException("Connection string is missing");
                }

                options.UseMySQL(connectionString);
            }, ServiceLifetime.Scoped);


            // Dependency Injection
            builder.Services.AddScoped<IProductUserService, ProductUserService>();

            // User Injection
            builder.Services.AddScoped<IUserService, UserService>();


            // Add Auto Mapper
            builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfiles));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment() )
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
