namespace NordigenSwagger
{
    public class User
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; } = null!;

        public int Telf { get; set; }

        public double Salario { get; set; }

        public double Comision { get; set; }

        public string Comision_p => Math.Round((Comision * 100 / Salario), 2) + "%";

    }
}
