//Roberto (...)
//Dado el alto y el ancho, se mostrará un rectángulo de "almohadillas"

using System;

class Ejercicio_34
{
    static void Main()
    {
        int ancho;
        int alto;
        int filas = 1;
        int columnas = 1;
        
        Console.Write("Introduzca el ancho: ");
        ancho = Convert.ToInt32( Console.ReadLine() );
        
        Console.Write("Introduzca el alto: ");
        alto = Convert.ToInt32( Console.ReadLine() );
        
        while (filas <= alto)
        {
            while (columnas <= ancho)
            {
                Console.Write("#");
                columnas = columnas + 1;
            }
            columnas = 1;
            filas = filas + 1;
            Console.WriteLine();
        }
    }
}
