using Cairo_book_fair.DBContext;
using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;
using Cairo_book_fair.Services;
using Cairo_book_fair.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Cairo_book_fair
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var googleClientId = builder.Configuration["GoogleOAuth:ClientId"];


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-8H9KKU1\\SQLEXPRESS;Initial Catalog=CairoBookDB;Integrated Security=True;Encrypt=False");
            });

            builder.Services.AddCors(options =>
            options.AddPolicy("MyPolicy", policy =>
                policy.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
            ));

            builder.Services.AddIdentity<User, IdentityRole>(
                options =>
                {
                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredUniqueChars = 4;

                    //options.Lockout.AllowedForNewUsers = true;
                    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    //options.Lockout.MaxFailedAccessAttempts = 5;

                    options.User.RequireUniqueEmail = true;

                })
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigninKey"]))
                };
            }).AddGoogle(options =>
            {
                options.ClientId = googleClientId;
                options.ClientSecret = builder.Configuration["GoogleOAuth:ClientSecret"]; // Make sure this is also set
            });


            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
            });


            //.AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]; ;
            //    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            //});



            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Project"
                });
                //To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                    });
            });


            //~~Abdallah Services~~//
            builder.Services.AddScoped<IRepository<Author>, Repository<Author>>();
            builder.Services.AddScoped<IRepository<Cart>, Repository<Cart>>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IBookCartRepository, BookCartRepository>();
            builder.Services.AddScoped<IBookCartService, BookCartService>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITicketService, TicketService>();

            //Abdelraheem Services//
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUsedBookRepository, UsedBookRepository>();
            builder.Services.AddScoped<IUsedBookService, UsedBookService>();
            builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();

            //okayyy
            builder.Services.AddScoped<ITransportationService, TransportationService>();
            builder.Services.AddScoped<IVisitorsService, VisitorService>();

            builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
            builder.Services.AddScoped<ITransportationRepository, TransportationRepository>();


            builder.Services.AddAutoMapper(typeof(Program));




            //review and shipment services
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();

            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
            builder.Services.AddScoped<IShipmentService, ShipmentService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // make sure database is created before running the application.//
            /*using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var Services = scope.ServiceProvider;
                    var context = Services.GetRequiredService<Context>();
                    context.Database.EnsureCreated();

                }
                catch (Exception ex)
                {
                    var LoggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                    var Logger = LoggerFactory.CreateLogger<Program>();
                    Logger.LogError(ex, ex.Message);
                }
            }*/

            app.UseHttpsRedirection();

            app.UseStaticFiles(); // to make it able to read static pages in wwwroot if needed

            app.UseCors("MyPolicy"); // to make the provider able to serve consumer from other domains


            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
