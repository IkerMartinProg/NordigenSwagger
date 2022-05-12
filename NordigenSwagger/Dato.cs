namespace NordigenSwagger
{
    public class Dato
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Respuesta { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        // Less Than
        public int MenorQue { get; set; }

        // Less Than Or Equal
        public int MenorOIgual { get; set; }

        // Greater Than
        public int MayorQue { get; set; }

        // Greater Than Or Equal
        public int MayorOIgual { get; set; }

        // Regular Expression
        public int UnoACuatro { get; set; }

        // Email
        public string Email { get; set; }

        // Credit Card
        // (5555555555554444)
        public string TarjetaCredito { get; set; }

        // Empty
        // Null
        public string Vacio { get; set; }

        // ExclusiveBetween
        public int RangoEx { get; set; }

        // InclusiveBetween
        public int RangoIn { get; set; }

        // ScalePrecision
        public double Precio { get; set; }

    }
}
