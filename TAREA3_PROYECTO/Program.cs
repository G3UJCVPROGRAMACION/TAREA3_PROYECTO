using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace TAREA3_PROYECTO
{
    internal class Program
    {
        static string[][] clientes = new string[100][];//Arreglo tipo Matriz, variable clientes, inicializada en 100
        static string[][] boletos  = new string[100][];
        static string[][] reservas = new string[100][];
        static string[][] espacios = new string[100][];
        static string[][] facturas = new string[100][];

        static int contadorClientes = 0;//Contador de Variable clientes
        static int contadorBoletos  = 0;
        static int contadorReservas = 0;
        static int contadorEspacios = 0;
        static int contadorFacturas = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Clear();
                WriteLine("Bienvenido al sistema de Boleteria de cine Permanencia Voluntaria");
                WriteLine("Seleccione una opción:");
                WriteLine("1. Clientes");
                WriteLine("2. Boletos");
                WriteLine("3. Reservas");
                WriteLine("4. Espacios");
                WriteLine("5. Facturas");
                WriteLine("6. Salir");
                WriteLine("Ingrese el número de la opción deseada:");

                try
                {
                    int opcion = int.Parse(ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            GestionarArreglo(clientes, ref contadorClientes, "Clientes", new string[] { "Numero de DNI", "Primer Nombre", "Segundo Nombre", "Primer Apellido", "Segundo Apellido", "Numero de Cliente", "Ciudad de Ubicacion" });
                            break;//Llamado a la funcion GestionarArreglo
                        case 2:
                            GestionarArreglo(boletos, ref contadorBoletos, "Boletos", new string[] { "Numero de Boleto", "Numero de Sala", "Numero de Asiento", "Numero de Pelicula", "Hora de la Funcion", "Fecha de la Funcion", "Ciudad de Ubicacion" });
                            break;
                        case 3:
                            GestionarArreglo(reservas, ref contadorReservas, "Reservas", new string[] { "Numero de Reserva", "Numero de Boleto", "Numero de Cliente", "Nombre de Cliente", "Fecha de la Reserva", "Hora de la Reserva", "Ciudad de Ubicacion" });
                            break;
                        case 4:
                            GestionarArreglo(espacios, ref contadorEspacios, "Espacios", new string[] { "Numero de Sala", "Tipo de Sala", "Capacidad de la Sala", "Disponibilidad de la Sala", "Numero de Asiento", "Estado del Asiento", "Ciudad de Ubicacion" });
                            break;
                        case 5:
                            GestionarArreglo(facturas, ref contadorFacturas, "Facturas", new string[] { "Numero de Factura", "Numero de Reserva", "Numero de Cliente", "Nombre de Cliente", "Fecha de la Factura", "Hora de la Factura", "Ciudad de Ubicacion" });
                            break;
                        case 6:
                            return;
                        default:
                            WriteLine("Opción no válida. Debes seleccionar un numero entre 1 y 6");
                            break;

                    }
                }
                catch (FormatException)
                {
                    WriteLine("Opción no válida. Se debe ingresar un numero entre 1 y 6. ");
                }
                catch (Exception ex)
                {
                    WriteLine($"Error inesperado: {ex.Message}");
                }
            }
        }
        static void GestionarArreglo(string[][] arreglo, ref int contador, string nombreArreglo, string[] campos)//Funcion GestionarArreglo
        {
            Func<string, bool> esNumeroValido = valor =>
            { return int.TryParse(valor, out int numero); };//Funcion Lambda

            while (true)
            {
                WriteLine($"Gestión de {nombreArreglo}");
                WriteLine("Seleccione una opción:");
                WriteLine("1. Agregar");
                WriteLine("2. Visualizar");
                WriteLine("3. Imprimir posicion");
                WriteLine("4. Regresar");
                WriteLine("Ingrese el número de la opción deseada:");
                try
                {
                    int opcion = int.Parse(ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            AgregarElemento(arreglo, ref contador, campos, esNumeroValido);
                            break;
                        case 2:
                            VisualizarArreglo(arreglo, contador, campos);
                            break;
                        case 3:
                            ImprimirPosicion(arreglo, ref contador, campos);
                            break;
                        case 4:
                            return;
                        default:
                            WriteLine("Opción no válida.  Debes seleccionar un numero entre 1 y 4");
                            break;
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Opción no válida. Se debe ingresar un numero entre 1 y 4 ");
                }
                catch (Exception ex)
                {
                    WriteLine($"Error inesperado: {ex.Message}");
                }
            }
        }
        static void AgregarElemento(string[][] arreglo, ref int contador, string[] campos, Func<string, bool> esNumeroValido)
        {
            if (contador >= arreglo.Length)
            {
                WriteLine("No se pueden agregar más elementos");
                return;
            }
            string[] elemento = new string[campos.Length];
            for (int i = 0; i < campos.Length; i++)
            {
                WriteLine($"Ingrese el valor para {campos[i]}: ");
                string valor = ReadLine();

                if (campos[i].Contains("Numero"))
                {
                    if (!esNumeroValido(valor))
                    {
                        WriteLine("Caracter no válido. Debe ingresar un número entero");
                        i--;
                        continue;
                    }

                }

                if (campos[i].Contains("Fecha"))
                {
                    if (!EsFechaValida(valor))
                    {
                        WriteLine("Fecha no válida. Ingrese la fecha en el formato dd/mm/yyyy");
                        i--;
                        continue;
                    }

                }
                else if (campos[i].Contains("Hora"))
                {

                    if (!EsHoraValida(valor))
                    {
                        WriteLine("Hora no válida. Ingrese la hora en formato de 24 horas (hh:mm)");
                        i--;
                        continue;
                    }
                }
                elemento[i] = valor;
            }
            arreglo[contador++] = elemento;
            WriteLine("Elemento agregado correctamente");
        }

        static void VisualizarArreglo(string[][] arreglo, int contador, string[] campos)
        {
            if (contador == 0)
            {
                WriteLine("No hay elementos para visualizar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                WriteLine($"Elemento {i + 1}");
                for (int j = 0; j < campos.Length; j++)
                {
                    WriteLine($"{campos[j]}: {arreglo[i][j]}");
                }
                WriteLine();
            }
        }
        static void ImprimirPosicion(string[][] arreglo, ref int contador, string[] campos)
        {
            if (contador == 0)
            {
                WriteLine("No hay elementos para visualizar");
                return;
            }
            WriteLine("Ingrese la posición del elemento a imprimir:");
            try
            {
                int posicion = int.Parse(ReadLine());
                if (posicion > 0 && posicion <= contador)
                {
                    posicion--;
                    WriteLine($"Elemento {posicion + 1}: ");
                    for (int j = 0; j < campos.Length; j++)
                    {
                        WriteLine($"{campos[j]}: {arreglo[posicion][j]}");
                    }
                }
                else
                {
                    WriteLine("Posicion no Valida o posicion aun NO tiene datos almacenados. Ingrese un numero entre 1 y 100 ");
                }
            }
            catch (FormatException)
            {
                WriteLine("Posición no válida. Se debe ingresar un numero entero Positivo no mayor a 100 ");
            }
            catch (Exception ex)
            {
                WriteLine($"Error inesperado: {ex.Message}");
            }

        }
        static bool EsFechaValida(string fecha)
        {
            DateTime result;
            return DateTime.TryParseExact(fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out result);

        }
        static bool EsHoraValida(string hora)
        {
            DateTime result;
            return DateTime.TryParseExact(hora, "HH:mm", null, System.Globalization.DateTimeStyles.None, out result);
        }

    }

}