
using Cairo_book_fair.DBContext;
using Cairo_book_fair.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair
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
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-8H9KKU1\\SQLEXPRESS;Initial Catalog=CairoBook;Integrated Security=True;Encrypt=False");
            });

            builder.Services.AddCors(options => options.AddPolicy("MyPolicy", policy =>
            policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
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
