/* Eduardo (...)
 * Crea un diccionario simple de inglés a español: el programa deberá contener 
 * al menos 10 palabras prefijadas. Mostrará un menú que permita añadir una 
 * nueva palabra (junto con su traducción), buscar la traducción de una 
 * palabra, ver la lista de todas las palabras almacenadas o salir. Puedes usar 
 * una SortedList, una tabla Hash o un Dictionary<string,string> (se 
 * compartirán las tres soluciones, para que puedas comparar).
 */

using System;
using System.Collections;

class Ejercicio166Ht
{
    static void Main()
    {
        string opcion;

        Hashtable englishSpanish = new Hashtable();  // <- Diferencia

        englishSpanish.Add("hello", "quepasatio");
        englishSpanish.Add("bye", "dew");
        englishSpanish.Add("friend", "tron");
        englishSpanish.Add("beer", "birra");
        englishSpanish.Add("wine", "tintorro");
        englishSpanish.Add("house", "chabolo");
        englishSpanish.Add("mother", "ma");
        englishSpanish.Add("go", "tira");
        englishSpanish.Add("eat", "zampar");
        englishSpanish.Add("come", "ventepacá");

        do
        {
            verMenu();
            opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1":
                    anyadirPalabra(englishSpanish);
                    break;
                case "2":
                    buscarTraduccion(englishSpanish);
                    break;
                case "3":
                    verTodas(englishSpanish);
                    break;
                case "S":
                    Console.WriteLine("¡Gracias por ampliar su vocabulario!");
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;
            }

        }
        while (opcion != "S");


    }

    static void verTodas(Hashtable englishSpanish)
    {
        foreach (string clave in englishSpanish.Keys) // <- Diferencia
        {
            Console.WriteLine("{0}  -->  {1}",
                clave, englishSpanish[clave]);
        }
    }

    static void verMenu()
    {
        Console.WriteLine("1. Anañadir nueva palabra al diccionario");
        Console.WriteLine("2. Buscar traducción");
        Console.WriteLine("3. Ver diccionario completo");
        Console.WriteLine("S. SALIR");
        Console.WriteLine();
    }

    static void buscarTraduccion(Hashtable englishSpanish)
    {
        string palabraTraducir;
        Console.WriteLine("Indique palabra en inglés");
        palabraTraducir = Console.ReadLine();

        if (englishSpanish.Contains(palabraTraducir))
            Console.WriteLine(englishSpanish[palabraTraducir]);
        else
            Console.WriteLine("Palabra no incluida");
    }

    static void anyadirPalabra(Hashtable englishSpanish)
    {
        string ingles;
        string espanyol;

        Console.WriteLine("Escriba la palabra en inglés");
        ingles = Console.ReadLine();
        Console.WriteLine("Escriba la palabra en español");
        espanyol = Console.ReadLine();
        
        englishSpanish.Add(ingles, espanyol);
    }
}
