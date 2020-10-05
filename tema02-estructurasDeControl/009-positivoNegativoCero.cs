/*Carlos (...)
     
Pide al usuario un número entero y responde si es un número positivo, negativo 
o cero*/

using System;

class Ejercicio9 
{
    
    static void Main ()
    {
        Console.WriteLine("Introduce un número: ");
        
        int numero = Convert.ToInt32(Console.ReadLine());
        
        if (numero > 0)
        {
            Console.WriteLine("El número introducido es positivo");
        }
        
        if (numero == 0)
        {
            Console.WriteLine("El número introducido es 0");
        }
        
        if (numero < 0)
        {
            Console.WriteLine("El número introducido es negativo");
        }
    }
}
