/*Eduardo (..)

Crea una función recursiva que calcule un cierto elemento de la serie de 
Fibonacci, en la que los dos primeros elementos son 0 y 1, y cada elemento 
posterior es la suma de los dos que le preceden (n[0] = 0, n[1] = 1,  n[i] = 
n[i-1] + n[i-2]). */

using System;
class Fibo
{
    static void Main()
    {
        int n, resultado;
        
        Console.WriteLine("Número de elemento?");
        n = Convert.ToInt32(Console.ReadLine());
        resultado = Fibonacci(n);
        Console.WriteLine("Fibonacci(n) = "  + resultado);
    }
    
    static int Fibonacci(int n)
    {
        if (n == 1 || n == 0)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
