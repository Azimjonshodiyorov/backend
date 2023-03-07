var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenLocalhost(5000);

            options.ListenLocalhost(5001, listenOptions =>
            {
                listenOptions.UseHttps();
            });
        });

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
