using System;
using NetCoreDemo.Services;
using System.Text.Json.Serialization;
using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using NetCoreDemo.Repositories;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

    builder.WebHost.UseKestrel(options =>
            {
                options.ListenLocalhost(7655);

                options.ListenLocalhost(7656, listenOptions =>
                {
                    listenOptions.UseHttps();
                });
            });

// Add services to the container.

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
builder.Services.AddSwaggerGen();
// builder.Services.AddAutoMapper(typeof(Program).Assembly);

// builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICrudRepo<Image, ImageDTO>, CrudRepo<Image,ImageDTO>>();
builder.Services.AddScoped<IProductRepo, ProductRepo>().AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>().AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartRepo, CartRepo>().AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();


var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
        var config = scope.ServiceProvider.GetService<IConfiguration>();
            if (dbContext is not null && config.GetValue<bool>("CreateDbAtStart", false)) //later change this and on dev.json file to true
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}

    

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    }
}
