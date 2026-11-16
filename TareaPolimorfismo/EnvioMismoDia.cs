namespace GestorEnvios
{
    // Desafío opcional: agregar nueva modalidad sin modificar el recorrido de la lista
    public class EnvioMismoDia : Envio
    {
        public EnvioMismoDia(string codigo, string destinatario, decimal peso)
            : base(codigo, destinatario, peso)
        {
        }

        public override string Modalidad
        {
            get { return "Mismo día"; }
        }

        // RD$ 400 + RD$ 95 x peso
        public override decimal CalcularCosto()
        {
            return 400m + 95m * Peso;
        }
    }
}
