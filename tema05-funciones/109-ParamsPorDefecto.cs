//Jorge (...)
//Ejercicio109, Mejora Escribircentrado

using System;

class ejercicio109
{
    static void EscribirCentradoYSubrayado(String cadena, char letra='-')
    {
        int posicionInicial = 0;

        posicionInicial = (80 - cadena.Length) / 2;
        for (int i = 0; i < posicionInicial; i++)
            Console.Write(" ");
        Console.WriteLine(cadena);

        for (int i = 0; i < posicionInicial; i++)
            Console.Write(" ");
        for (int i = 0; i < cadena.Length; i++)
            Console.Write(letra);
    }
    
    static void Main()
    {
        EscribirCentradoYSubrayado("Hola", '=');
        Console.WriteLine();
        
        EscribirCentradoYSubrayado("Hola otra vez");
        Console.WriteLine();
        
        EscribirCentradoYSubrayado(letra: '.', cadena: "Hasta luego");
        Console.WriteLine();
    }
}
