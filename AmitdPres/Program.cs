using AmitdPres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios para Razor Pages
builder.Services.AddDbContext<AmitdPresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Añade servicios para Razor Pages
builder.Services.AddRazorPages();

// Construcción de la aplicación
var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Añade HSTS en producción
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configura Razor Pages
app.MapRazorPages();

app.Run();
