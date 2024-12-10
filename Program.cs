
using API_CRUD_PRACT_1.Repository;
using API_CRUD_PRACT_1.Service;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_PRACT_1
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
            builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            builder.Services.AddDbContext<Appdbcontext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                                  });
            });
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyAllowSpecificOrigins");

            app.MapControllers();

            app.Run();

        }
    }
}
