//Angel (...)
//Ejercicio 80: Saludar muchas veces

using System;

class Ejercicio80
{
    static void SaludarMuchasVeces(string saludarNombre, byte vecesRepetir)
    {
        for(byte i = 0; i < vecesRepetir; i++)
        {
            Console.WriteLine("Hola, {0}", saludarNombre);
        }
    }
    
    static void Main()
    {
        string nombre;
        byte veces;
        
        Console.Write("Introduce tu nombre: ");
        nombre = Console.ReadLine();
        Console.Write("Introduce el número de veces que quieres saludar: ");
        veces = Convert.ToByte(Console.ReadLine());
        
        SaludarMuchasVeces(nombre, veces);
    }
}
