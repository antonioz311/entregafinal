using GestionInventario.Data;
using GestionInventario.Repositories;
using GestionInventario.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 33))));

// Repositorios
builder.Services.AddScoped<ProductoRepositorio>();
builder.Services.AddScoped<MovimientoRepositorio>();
builder.Services.AddScoped<ProveedorRepositorio>();
builder.Services.AddScoped<UsuarioRepositorio>();

// Servicios
builder.Services.AddScoped<ProductoServicio>();
builder.Services.AddScoped<MovimientoServicio>();
builder.Services.AddScoped<ProveedorServicio>();
builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<ReporteServicio>();
builder.Services.AddScoped<NotificacionServicio>();

// Configuración de controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
