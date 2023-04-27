using NetCoreDemo.Services;
using System.Text.Json.Serialization;
using NetCoreDemo.Models;
using NetCoreDemo.Db;
using NetCoreDemo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NetCoreDemo.Middlewares;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

    builder.WebHost.UseKestrel(options =>
            {
                options.ListenLocalhost(7654);

                options.ListenLocalhost(7657, listenOptions =>
                {
                    listenOptions.UseHttps();
                });
            });

    builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true ;
        });

    builder.Services
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

    builder.Services.AddDbContext<AppDbContext>();

    builder.Services
        .AddIdentity<User, IdentityRole<int>>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<AppDbContext>();

    builder.Services
        .AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
            };
        });

    builder.Services.AddAuthorization(options =>
    {
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(
                "oauth2",
                new OpenApiSecurityScheme
                {
                    Description = "Bearer token authentication",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                }
            );
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IProductRepo, ProductRepo>().AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<ICategoryRepo, CategoryRepo>().AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IImageRepo, ImageRepo>().AddScoped<IImageService, ImageService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IOrderRepo, OrderRepo>().AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IRoleService, RoleService>();
    builder.Services.AddScoped<ITokenService, JwtTokenService>();

    builder.Services.AddTransient<ErrorHandlerMiddleware>();



    var app = builder.Build();

    app.UseHttpsRedirection();
    
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    }
}
