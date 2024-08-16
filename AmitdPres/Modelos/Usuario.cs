using Microsoft.EntityFrameworkCore;

namespace AmitdPres.Modelos
{
    public class Usuario
    {
        public int id {  get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string rol { get; set; } 
        public string Permisos { get; set; }
    }
}

