namespace Entity
{
    public class Alquiler
    {
        public int NumeroAlquiler { get; set; }
        public int IdTipoBicicleta { get; set; }
        public string DniCliente { get; set; }
        public decimal ImporteTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public TipoBicicleta TipoBicicleta { get; set; }
    }
}