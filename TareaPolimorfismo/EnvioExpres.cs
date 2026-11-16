namespace GestorEnvios
{
    public class EnvioExpres : Envio
    {
        public EnvioExpres(string codigo, string destinatario, decimal peso)
            : base(codigo, destinatario, peso)
        {
        }

        public override string Modalidad
        {
            get { return "Exprés"; }
        }

        // RD$ 260 + RD$ 70 x peso
        public override decimal CalcularCosto()
        {
            return 260m + 70m * Peso;
        }
    }
}
