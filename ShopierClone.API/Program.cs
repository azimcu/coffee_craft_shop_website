using Microsoft.EntityFrameworkCore;
using ShopierClone.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Controller desteğini servislere ekliyoruz
builder.Services.AddControllers();

// 2. Swagger / OpenAPI desteği (API Dokümantasyonu)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ShopierClone API",
        Version = "v1",
        Description = "3D Baskı E-Ticaret Backend Projesi"
    });
});

// 3. SQLite Veritabanı Servis Kaydı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopierClone API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 4. Controller Endpoint yönlendirmelerini haritalandırıyoruz
app.MapControllers();

app.Run();
