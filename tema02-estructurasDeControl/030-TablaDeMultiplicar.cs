/*Pide un número entero y muestra su tabla de multiplicar.
 * Iván (...) */
using System;
 
public class Ejercicio_30
{
    public static void Main()
    {
        int numero, resultado;
        int i = 0;
        
        Console.WriteLine("Introduce un número: ");
        numero = Convert.ToInt32(Console.ReadLine());
        
        do
        {
            resultado = numero * i;
            Console.WriteLine("{0} x {1} = {2}", numero, i, resultado);
            i++;
        }
        while( i <= 10);
    }
}    


