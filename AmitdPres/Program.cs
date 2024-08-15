using Microsoft.EntityFrameworkCore;
using AmitdPres; // Aseg�rate de cambiar esto por el namespace correcto para tu proyecto

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios para Blazor Server
builder.Services.AddRazorComponents();
builder.Services.AddDbContext<AmitdPresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// A�ade servicios de Blazor
builder.Services.AddServerSideBlazor();

// Construcci�n de la aplicaci�n
var app = builder.Build();

// Configuraci�n del pipeline HTTP
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
