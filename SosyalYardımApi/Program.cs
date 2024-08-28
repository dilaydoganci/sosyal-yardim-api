using Microsoft.EntityFrameworkCore;
using SosyalYardimApi.Data;
using SosyalYardimApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Entity Framework Core ve SQL Server ba�lam�
builder.Services.AddDbContext<SosyalYardimContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS ayarlar�
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // React  URL'si
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add Swagger/OpenAPI deste�i
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CROS 
app.UseCors("AllowReactApp");

// Veri ekleme i�lemi
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SosyalYardimContext>();
    Seed.SeedData(context); // Seed s�n�f�ndaki veri ekleme metodu
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
