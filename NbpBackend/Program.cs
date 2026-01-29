using Microsoft.EntityFrameworkCore;
using NbpBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Zezwolenie na CORS (po³¹czenie z Angulara)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.AllowAnyOrigin()   
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Rejestracja HttpClient i naszego serwisu
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<NbpBackend.Services.NbpService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
