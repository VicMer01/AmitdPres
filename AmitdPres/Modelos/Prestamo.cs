using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmitdPres.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int idTipoPrestamoId { get; set; }
        public int IdGarantia { get; set; }
        public int idTipoGastosLegales { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        public int CantidadCuotas { get; set; }
        public int TipoAmortizacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPagos { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Abono { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Tasa { get; set; }

        public int FrecuenciaPago { get; set; }
        public int DiasGracia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoGastoLegal { get; set; }

        public List<Pagos> ListaPagos { get; set; }
        public int IdEstadoPrestamo { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcientoMora { get; set; }
    }
}
