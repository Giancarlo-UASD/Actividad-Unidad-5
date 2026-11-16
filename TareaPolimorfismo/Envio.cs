using System;

namespace GestorEnvios
{
    // Clase base abstracta: Todos los demás tipos de envío se derivan de esta.
    public abstract class Envio
    {
        public string Codigo { get; private set; }
        public string Destinatario { get; private set; }
        public decimal Peso { get; private set; }

        // Las validaciones se hacen en el constructor de la clase padre, para economizar.
        public Envio(string codigo, string destinatario, decimal peso)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(destinatario))
                throw new ArgumentException("El destinatario no puede estar vacío.");

            if (peso <= 0)
                throw new ArgumentException("El peso debe ser mayor que cero.");

            Codigo = codigo;
            Destinatario = destinatario;
            Peso = peso;
        }

        // Al declarar esta propiedad como abstracta, cada clase derivada puede retornar su modalidad.
        public abstract string Modalidad { get; }

        // Método para calcular el costo.
        public abstract decimal CalcularCosto();
    }
}
