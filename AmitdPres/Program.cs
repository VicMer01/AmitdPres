using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AmitdPres; // Aseg�rate de cambiar esto por el namespace correcto para tu proyecto

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Configura los servicios que se inyectar�n en la aplicaci�n
    public void ConfigureServices(IServiceCollection services)
    {
        // Configura el DbContext para usar SQL Server con la cadena de conexi�n definida en appsettings.json
        services.AddDbContext<AmitdPresContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Registra el uso de controladores (para API)
        services.AddControllers();
    }

    // Configura el middleware y la respuesta a solicitudes HTTP
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Muestra la p�gina de errores detallados si est� en modo desarrollo
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Configura el manejo de errores y seguridad para entornos de producci�n
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Redirige todo el tr�fico HTTP a HTTPS
        app.UseHttpsRedirection();

        // Configura el enrutamiento de la aplicaci�n
        app.UseRouting();

        // Configura la autorizaci�n (opcional)
        app.UseAuthorization();

        // Configura los endpoints de los controladores
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}