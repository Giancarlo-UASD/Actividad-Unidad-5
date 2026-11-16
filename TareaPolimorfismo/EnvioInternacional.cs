namespace GestorEnvios
{
    public class EnvioInternacional : Envio
    {
        public EnvioInternacional(string codigo, string destinatario, decimal peso)
            : base(codigo, destinatario, peso)
        {
        }

        public override string Modalidad
        {
            get { return "Internacional"; }
        }

        // RD$ 500 + RD$ 120 x peso + RD$ 200 de gestión
        public override decimal CalcularCosto()
        {
            return 500m + 120m * Peso + 200m;
        }
    }
}
