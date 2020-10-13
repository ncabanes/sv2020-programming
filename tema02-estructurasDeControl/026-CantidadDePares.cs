/* Carlos (...)
 Pide al usuario dos números, que guardarás en variables "n1" y 
 "n2". Dale a una variable llamada "pares" el valor 2 si los dos 
 son pares, 1 si sólo uno es par o 0 si ninguno es par.*/
     
using System;

class CantidadDePares
{
    static void Main()
    {
        int n1, n2, pares;
        Console.WriteLine("Introduce un número: ");
        n1 = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Introduce otro número: ");
        n2 = Convert.ToInt32(Console.ReadLine());
        
        // Versión 1, con "if"
        
        if (( n1 % 2 == 0 ) && (n2 % 2 == 0))
            pares = 2;
        else if (( n1 % 2 == 0 ) || (n2 % 2 == 0))
            pares = 1;
        else
            pares = 0;
            
        Console.WriteLine ( "{0} números pares (if)", pares );
        
        // Versión 2, con operador ternario
        
        pares = ( n1 % 2 == 0 ) && (n2 % 2 == 0) ? 2 :
            ( n1 % 2 == 0 ) || (n2 % 2 == 0) ? 1 : 0;
        
        Console.WriteLine ( "{0} números pares (ternario)", pares );
            
    }
        
}
