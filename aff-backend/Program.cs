using aff.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<AlpacaSettings>(builder.Configuration.GetSection("AlpacaInfo"));
builder.Services.AddScoped<IAlpacaService, AlpacaService>();

builder.Services.AddDbContext<AffContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // ✅ Correct method
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();