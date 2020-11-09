//Carmen (...)

/* Ejercicio que saluda al usuario
   dependiendo del nombre que escriba */

using System;

class Ejercicio56
{
    static void Main ()
    {
        string nombre;
        
        Console.Write("¿Cómo se llama usted? ");
        nombre= Console.ReadLine();
        
        if (nombre == "Carmen")
            Console.WriteLine("¡Hola, Carmen!");
        else
            Console.WriteLine("Disculpe, pero no le conozco.");
    }
}
