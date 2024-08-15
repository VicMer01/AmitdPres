using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AmitdPres; // Asegúrate de cambiar esto por el namespace correcto para tu proyecto

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Configura los servicios que se inyectarán en la aplicación
    public void ConfigureServices(IServiceCollection services)
    {
        // Configura el DbContext para usar SQL Server con la cadena de conexión definida en appsettings.json
        services.AddDbContext<AmitdPresContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Registra el uso de controladores (para API)
        services.AddControllers();
    }

    // Configura el middleware y la respuesta a solicitudes HTTP
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Muestra la página de errores detallados si está en modo desarrollo
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Configura el manejo de errores y seguridad para entornos de producción
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Redirige todo el tráfico HTTP a HTTPS
        app.UseHttpsRedirection();

        // Configura el enrutamiento de la aplicación
        app.UseRouting();

        // Configura la autorización (opcional)
        app.UseAuthorization();

        // Configura los endpoints de los controladores
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}