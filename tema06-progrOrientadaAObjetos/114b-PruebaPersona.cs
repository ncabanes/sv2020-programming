using System;

/* Crea una nueva versión del ejercicio 113, en la que cada clase esté en un 
 * fichero independiente, empleando Visual Studio (o alguna herramienta 
 * similar). */

// Eduardo (...)

class PruebaPersona
{
    static void Main()
    {
        Persona p1 = new Persona();
        Persona p2 = new Persona();

        Console.WriteLine("Nombre de la primera persona:");
        p1.SetNombre(Console.ReadLine());
        Console.WriteLine("Edad de la primera persona:");
        p1.SetEdad(Convert.ToByte(Console.ReadLine()));
        Console.WriteLine("Email de la primera persona:");
        p1.SetEmail(Console.ReadLine());

        Console.WriteLine("Nombre de la segunda persona:");
        p2.SetNombre(Console.ReadLine());
        Console.WriteLine("Edad de la segunda persona:");
        p2.SetEdad(Convert.ToByte(Console.ReadLine()));
        Console.WriteLine("Email de la segunda persona:");
        p2.SetEmail(Console.ReadLine());

        Console.WriteLine();
        p1.Mostrar();
        p2.Mostrar();
    }
}
