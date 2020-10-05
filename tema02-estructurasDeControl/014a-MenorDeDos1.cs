/* Alejandro (...)
 * Devuelve cual es el menor de dos numeros distintos*/
 
using System;

class Program
{
    static void Main()
    {
        int numero1, numero2;
        Console.WriteLine("Dime el primer número");
        numero1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Dime el segundo número");
        numero2 = Convert.ToInt32(Console.ReadLine());
        if (numero1 == numero2)
        {
            Console.WriteLine("Son el mismo número");
        } 
        else if (numero1 > numero2)
        {
            Console.WriteLine("El segundo número es menor que el primero, {0} es menor que {1}", numero2, numero1);
        } 
        else
        {
            Console.WriteLine("El primer número es menor que el segundo, {0} es menor que {1}", numero1, numero2);
        }
    }
}
