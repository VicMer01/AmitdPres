using AmitdPres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios para Razor Pages
builder.Services.AddDbContext<AmitdPresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// A�ade servicios para Razor Pages
builder.Services.AddRazorPages();

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
    app.UseHsts(); // A�ade HSTS en producci�n
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configura Razor Pages
app.MapRazorPages();

app.Run();
