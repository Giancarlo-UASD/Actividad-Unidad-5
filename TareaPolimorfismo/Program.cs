using System;
using System.Collections.Generic;

namespace GestorEnvios
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista del tipo base con objetos de distintas modalidades
            List<Envio> envios = new List<Envio>();
            envios.Add(new EnvioEstandar("EST-001", "Ana Pérez", 2.5m));
            envios.Add(new EnvioEstandar("EST-002", "Luis Gómez", 7m));
            envios.Add(new EnvioExpres("EXP-001", "María Rodríguez", 1.2m));
            envios.Add(new EnvioExpres("EXP-002", "Carlos Díaz", 4.8m));
            envios.Add(new EnvioInternacional("INT-001", "John Smith", 3m));
            envios.Add(new EnvioInternacional("INT-002", "Laura Martínez", 10m));

            bool mismoDiaAgregados = false;
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("===== GESTOR DE ENVÍOS =====");
                Console.WriteLine("1. Mostrar envíos y total");
                Console.WriteLine("2. Probar fórmulas con 2 kg");
                Console.WriteLine("3. Probar validaciones");
                Console.WriteLine("4. Agregar envíos Mismo día (desafío)");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarEnvios(envios);
                        break;

                    case "2":
                        List<Envio> control = new List<Envio>();
                        control.Add(new EnvioEstandar("C-EST", "Control", 2m));
                        control.Add(new EnvioExpres("C-EXP", "Control", 2m));
                        control.Add(new EnvioInternacional("C-INT", "Control", 2m));
                        MostrarEnvios(control);
                        break;

                    case "3":
                        ProbarValidaciones();
                        break;

                    case "4":
                        if (mismoDiaAgregados)
                        {
                            Console.WriteLine("Los envíos Mismo día ya fueron agregados.");
                        }
                        else
                        {
                            envios.Add(new EnvioMismoDia("MD-001", "Pedro Santana", 2m));
                            envios.Add(new EnvioMismoDia("MD-002", "Rosa Medina", 5.5m));
                            mismoDiaAgregados = true;
                            Console.WriteLine("Envíos Mismo día agregados. Use la opción 1 para verlos.");
                        }
                        break;

                    case "0":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Recorre la lista y llama a CalcularCosto() desde la referencia Envio
        static void MostrarEnvios(List<Envio> lista)
        {
            decimal total = 0m;

            Console.WriteLine();
            foreach (Envio e in lista)
            {
                decimal costo = e.CalcularCosto(); 
                total += costo;

                Console.WriteLine("Código: " + e.Codigo
                    + " | Destinatario: " + e.Destinatario
                    + " | Modalidad: " + e.Modalidad
                    + " | Peso: " + e.Peso + " kg"
                    + " | Costo: RD$ " + costo.ToString("F2"));
            }

            Console.WriteLine("TOTAL: RD$ " + total.ToString("F2"));
        }

        static void ProbarValidaciones()
        {
            Console.WriteLine();

            try
            {
                new EnvioEstandar("", "Ana Pérez", 2m);
                Console.WriteLine("Código vacío: no se detectó el error.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Código vacío -> " + ex.Message);
            }

            try
            {
                new EnvioExpres("EXP-X", "", 2m);
                Console.WriteLine("Destinatario vacío: no se detectó el error.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Destinatario vacío -> " + ex.Message);
            }

            try
            {
                new EnvioInternacional("INT-X", "John Smith", 0m);
                Console.WriteLine("Peso no positivo: no se detectó el error.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Peso no positivo -> " + ex.Message);
            }
        }
    }
}
