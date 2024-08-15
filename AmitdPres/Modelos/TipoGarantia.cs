namespace AmitdPres.Modelos
{
    public class TipoGarantia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Garantia> TipoGarantias { get; set; }
    }
}
