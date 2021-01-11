/*
Ejercicio 103. Escribir centrado y subrayado
Carlos (...)
*/

using System;

class Ejercicio103
{
    static void EscribirCentradoYSubrayado(string cadena)
    {
        for (int i = 0; i < (80 - cadena.Length) / 2; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(cadena);
        
        for (int i = 0; i < (80 - cadena.Length) / 2; i++)
        {
            Console.Write(" ");
        }
        for (int i = 0; i < cadena.Length; i++)
        {
            Console.Write("_");
        }
    }

    static void Main()
    {
        EscribirCentradoYSubrayado("Texto de ejemplo");
    }
}
