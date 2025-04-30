using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using personapi_dotnet.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar DbContext con la cadena de conexión de appsettings.json
builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonaDb")));  // Usamos "PersonaDb" que es el nombre de tu cadena de conexión en appsettings.json

// Registrar Repositorios
// Registro de repositorios
builder.Services.AddScoped<IEstudiosRepository, EstudiosRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IProfesionRepository, ProfesionRepository>();
builder.Services.AddScoped<ITelefonoRepository, TelefonoRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();