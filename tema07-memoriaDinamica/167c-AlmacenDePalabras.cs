/*Carlos (...)
 
 167 c. Crea un programa que permita al usuario almacenar palabras y mostrar 
todas las palabras almacenadas. No debe permitir duplicados. Debes hacer tres 
variantes: una que use List<string>, otra que emplee SortedList y otra que 
utilice un conjunto.*/

// Versión con conjunto (SortedSet<string>)

using System;
using System.Collections.Generic;

class AlmacenDePalabras
{
    SortedSet<string> almacen = new SortedSet<string>();    // <-- Diferencia
    private void MostrarMenu()
    {
        Console.WriteLine("\n1. Añadir una palabra");
        Console.WriteLine("2. Ver lista de palabras");
        Console.WriteLine("3. Salir\n");
    }

    private void Anyadir()
    {
        string palabra;
        do
        {
            Console.WriteLine("Introduce una palabra a añadir: ");
            palabra = Console.ReadLine();

            if (almacen.Contains(palabra))
            {
                Console.WriteLine("Palabra ya presente en el almacén");
            }
        }
        while (almacen.Contains(palabra) && palabra != "");    // <-- Diferencia

        almacen.Add(palabra);    // <-- Diferencia
    }

    private void VerLista()
    {
        foreach(string palabra in almacen)    // <-- Diferencia
        {
            Console.WriteLine(palabra);
        }
    }
    
    private void Ejecutar()
    {
        bool salir = false;

        do
        {
            MostrarMenu();
            Console.WriteLine("Introduce una opción del menú: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Anyadir();
                    break;
                case 2:
                    VerLista();
                    break;
                case 3:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no disponible en el menú");
                    break;
            }
        }
        while (!salir);
    }
    
    public static void Main()
    {
        AlmacenDePalabras a = new AlmacenDePalabras();
        a.Ejecutar();
    }
}
