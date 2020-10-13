//Eduardo (...)

// Este programa pide al usuario un número, que guardarás en una variable "n". 
// Dale a una variable llamada "par" el valor 1 si "n" es par, o un valor 0
// si es impar.

using System;

class EjercicioPropuesto23
{
    static void Main()
    {
        int n, par;
        Console.WriteLine("Introduzca un número");
        n = Convert.ToInt32 (Console.ReadLine());
        Console.WriteLine("Gracias");
        
        if (n%2==0) par=1; else par=0;
        Console.WriteLine("n vale {0} por lo que par vale {1}", n, par);
        
        par = n%2==0 ? 1 : 0;
        Console.WriteLine("n vale {0} por lo que par vale {1}", n, par);
    }
}

        
