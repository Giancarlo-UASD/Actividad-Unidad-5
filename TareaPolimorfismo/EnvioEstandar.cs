namespace GestorEnvios
{
    public class EnvioEstandar : Envio
    {
        public EnvioEstandar(string codigo, string destinatario, decimal peso)
            : base(codigo, destinatario, peso)
        {
        }

        public override string Modalidad
        {
            get { return "Estándar"; }
        }

        // RD$ 150 + RD$ 45 x peso
        public override decimal CalcularCosto()
        {
            return 150m + 45m * Peso;
        }
    }
}
