using Microsoft.EntityFrameworkCore;

namespace AmitdPres.Modelos
{
    
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Cedula { get; set; }
            public DateTime FechaIngreso { get; set; }
            public string Direccion { get; set; }
            public string FotoCedulaFrente { get; set; } 
            public string FotoCedulaAtras { get; set; } 
            public string FotoCliente { get; set; } 
            public string Apodo { get; set; }
            public string Telefono { get; set; }
            public string Celular { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Ocupacion { get; set; }
            public string Sexo { get; set; }

            
        }
    
}
