/*
39.Escribe un programa en C# que muestre en pantalla tantos asteriscos como 
indique el usuario, en una misma fila, usando "for". 

Por ejemplo, si el usuario introduce 7, la respuesta sería: ******* 
*/

using System;

class Ej39
{
    static void Main()
    {
        int asteriscos;

        Console.Write("Introduce el número de asteriscos: ");
        asteriscos = Convert.ToInt32(Console.ReadLine());

        for ( int i = 0; i < asteriscos; i++)
        {
            Console.Write("*");
        }
    }
}
