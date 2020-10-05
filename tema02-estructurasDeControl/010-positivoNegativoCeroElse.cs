/*
Carlos (...)

Pide al usuario un número entero y responda si es un número positivo, negativo 
o cero, usando else
*/
     
using System;

class Ejercicio10 
{

    static void Main ()
    {
        Console.WriteLine("Introduce un número: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        
        if (numero > 0)
            Console.WriteLine("El número introducido es positivo");
        else if (numero == 0)
            Console.WriteLine("El número introducido es 0");
        else
            Console.WriteLine("El número introducido es negativo");
    }
}
