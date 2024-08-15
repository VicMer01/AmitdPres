using Microsoft.EntityFrameworkCore;
using AmitdPres; // Asegúrate de cambiar esto por el namespace correcto para tu proyecto

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios para Blazor Server
builder.Services.AddRazorComponents();
builder.Services.AddDbContext<AmitdPresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Añade servicios de Blazor
builder.Services.AddServerSideBlazor();

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
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
