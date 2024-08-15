namespace AmitdPres.Modelos
{
    public class Pagos
    {
        public int Id { get; set; }
        public int IdPrestamo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Mora { get; set; }
    }
}
