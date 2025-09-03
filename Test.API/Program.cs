
using Microsoft.EntityFrameworkCore;
using Test.DataAccess.Data;
using Test.DataAccess.Repository;
using Test.DataAccess.Repository.IRepository;

namespace Test.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // we have two part, one is service Configration for DI and one is Middlewares

            #region Service Configuration
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Add services to the container.
            //builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            #endregion

            #region Middlewares

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod()
            .WithOrigins("http://localhost:4200","https://localhost:4200"));
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion MiddleWares
        }
    }
}
