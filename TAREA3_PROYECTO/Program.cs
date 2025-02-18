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
        static int[] numeros = new int[7];
        static int[,] matriz = new int[3, 3];
        static bool arregloLleno = false;
        static bool matrizLlena = false;
        static void Main(string[] args )
        {
            int opcion = 0;

            do
            {
                Clear();
                WriteLine("--- MENÚ ---");
                WriteLine("1. Agregar datos al arreglo");
                WriteLine("2. Visualizar el arreglo");
                WriteLine("3. Imprimir una posición del arreglo");
                WriteLine("4. Agregar datos a la matriz");
                WriteLine("5. Visualizar la matriz");
                WriteLine("6. Imprimir una posición de la matriz");
                WriteLine("7. Salir");
                Write("Seleccione una opción: ");

                try
                {
                    opcion = int.Parse(ReadLine());
                    if (opcion < 1 || opcion > 7)
                    {
                        WriteLine("Opción fuera de rango. Presione cualquier tecla para continuar.");
                        ReadKey();
                        continue;

                    }
                }
                catch (FormatException ex)
                {
                    WriteLine(ex.Message);
                    WriteLine(ex.StackTrace);
                    WriteLine(ex.ToString());
                    WriteLine("Entrada inválida, Usted deberia ingresar un numero entero. Presione cualquier tecla para continuar.");
                    ReadKey();
                    continue;

                }

                switch (opcion)
                {
                    case 1:
                        AgregarArreglo();
                        break;
                    case 2:
                        VisualizarArreglo();
                        break;
                    case 3:
                        ImprimirElementoArreglo();
                        break;
                    case 4:
                        AgregarMatriz();
                        break;
                    case 5:
                        VisualizarMatriz();
                        break;
                    case 6:
                        ImprimirElementoMatriz();
                        break;
                    case 7:
                        WriteLine("Saliendo...");
                        break;
                }
                WriteLine("Presione cualquier tecla para continuar...");
                ReadKey();
            } while (opcion != 7);
        }
        static void AgregarArreglo()
        {
            WriteLine("Ingrese 7 números enteros:");
            for (int i = 0; i < numeros.Length; i++)
            {
                while (true)
                {
                    Write($"Número {i + 1}: ");
                    try
                    {
                        numeros[i] = int.Parse(ReadLine());
                        break;
                    }
                    catch (FormatException ex)
                    {
                        WriteLine("Valor inválido. Ingrese un número entero.");
                    }
                }
            }
            arregloLleno = true;
        }
        static void VisualizarArreglo()
        {
            if (!arregloLleno) { WriteLine("El arreglo aún no tiene datos."); return; }
            Write("Arreglo: ");
            numeros.ToList().ForEach(num => Write(num + " "));
            WriteLine();
        }

        static void ImprimirElementoArreglo()
        {
            if (!arregloLleno) { WriteLine("El arreglo aún no tiene datos."); return; }
            Write("Ingrese la posición a imprimir (0-6): ");
            try
            {
                int pos = int.Parse(ReadLine());
                if (pos >= 0 && pos < numeros.Length)
                    WriteLine($"Valor en la posición {pos}: {numeros[pos]}");
                else
                    WriteLine("Posición inválida.");
            }
            catch (FormatException ex)
            {
                WriteLine("Entrada inválida.");
            }
        }
        static void AgregarMatriz()
        {
            WriteLine("Ingrese los valores de la matriz 3x3:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    while (true)
                    {
                        Write($"Elemento [{i},{j}]: ");
                        try
                        {
                            matriz[i, j] = int.Parse(ReadLine());
                            break;
                        }
                        catch (FormatException ex)
                        {
                            WriteLine("Valor inválido. Ingrese un número entero.");
                        }
                    }
                }
            }
            matrizLlena = true;
        }
        static void VisualizarMatriz()
        {
            if (!matrizLlena) { WriteLine("La matriz aún no tiene datos."); return; }
            WriteLine("Matriz:");
            Enumerable.Range(0, 3).ToList().ForEach(i =>
            {
                Enumerable.Range(0, 3).ToList().ForEach(j => Write(matriz[i, j] + "	"));
                WriteLine();
            });

        }
        static void ImprimirElementoMatriz()
        {
            if (!matrizLlena) { WriteLine("La matriz aún no tiene datos."); return; }
            try
            {
                Write("Ingrese fila (0-2): ");
                int fila = int.Parse(ReadLine());
                Write("Ingrese columna (0-2): ");
                int col = int.Parse(ReadLine());
                if (fila >= 0 && fila < 3 && col >= 0 && col < 3)
                    WriteLine($"Valor en [{fila},{col}]: {matriz[fila, col]}");
                else
                    WriteLine("Posición inválida.");
            }
            catch (FormatException ex)
            {
                WriteLine("Entrada inválida.");
            }
        }
    }

    //ARREGLOS PARA APROVACION DE PROYECTO

    /*int[] numeros = new int[7];
    Console.WriteLine("Ingrese 7 numeros enteros: ");
    for (int i = 0; i < 7; i++)
    {
        numeros[i] = int.Parse(Console.ReadLine());
    }
    for (int i = 0; i < 7; i++)
    {
        Console.WriteLine($"Elemento {i + 1} Posicion {i} {numeros[i]}");
    }
    int[,] matriz = new int[3, 3];
    Console.WriteLine("Ingrese 9 numeros enteros: ");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            matriz[i, j] = int.Parse(Console.ReadLine());
        }
    }
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.WriteLine($"Elemento {i + 1} Posicion {i},{j} {matriz[i, j]}");
        }
    }

    Console.ReadLine();*/


}
    





