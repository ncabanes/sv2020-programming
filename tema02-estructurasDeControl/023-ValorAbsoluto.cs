/*

23. Escribe un programa que calcule (y muestre) el valor absoluto de un número 
x: si el número es positivo (o cero), su valor absoluto es exactamente el 
número x; en caso contrario, su valor absoluto es -x. Hazlo de dos maneras 
diferentes en el mismo programa: usando "if" y usando el "operador condicional" 
o "ternario" (?).

*/

using System;

class Ejercicio_23
{
    static void Main()
    {
        Console.WriteLine("Introduce un numero: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int valorAbsoluto;
        
        /*---------------USANDO IF---------------------*/       
        if(n >= 0)
        {
            valorAbsoluto = n;
            
        }
        else
        {
            valorAbsoluto = n*-1;
        }
        Console.WriteLine(valorAbsoluto);
        
        /*---------------USANDO OPERADOR TERNARIO-------*/

        valorAbsoluto = n >= 0 ? n : n * -1;
        Console.WriteLine(valorAbsoluto);
    }
}
