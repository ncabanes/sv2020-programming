/* 169. A partir del fichero words.txt, crea un programa que sugiera palabras que 
comiencen por las letras que vaya tecleando el usuario, como el autocompletado 
de las búsquedas en Google.
* 
* Usando SortedSet
* 
* Hugo (...)
*/

using System;
using System.Collections.Generic;
using System.IO;

class Ejercicio
{
    static void Main()
    {
        char letra;
        string palabra = "";
        ConsoleKeyInfo tecla;
        string[] lineas = File.ReadAllLines("words.txt");

        SortedSet<string> listaPalabras = new SortedSet<string>(lineas);

        Console.WriteLine("Introduzca letras de la palabra a buscar:");
        do
        {
            tecla = Console.ReadKey();
            if (tecla.Key != ConsoleKey.Backspace)
            {
                letra = tecla.KeyChar;
                palabra += letra;
            }
            else if (palabra.Length > 0)
            {
                palabra = palabra.Substring(0, palabra.Length - 1);
            }

            Console.Clear();
            Console.WriteLine("Introduzca una palabra a buscar:");
            Console.WriteLine(palabra);
            Console.WriteLine();

            Mostrar(listaPalabras, palabra);
        }
        while (tecla.Key != ConsoleKey.Escape);
    }

    static void Mostrar(SortedSet<string> palabras, string palabra)
    {
        int palabrasAMostrar = 10;
        int mostradas = 0;

        foreach (string p in palabras)
        {
            if (p.IndexOf(palabra) == 0 && palabra.Length > 0
                && mostradas < palabrasAMostrar)
            {
                Console.WriteLine(p);
                mostradas++;
            }
        }
    }
}
