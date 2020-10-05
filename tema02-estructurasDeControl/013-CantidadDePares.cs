/*13. Pide dos números al usuario y responde cuántos de ellos eran pares. 
No debes usar un contador, sino condiciones encadenadas.*/

using System;


class MainClass 
{
    public static void Main () 
    {
        Console.Write("Dime un número: ");
        int primerNumero = Convert.ToInt32( Console.ReadLine() );
        Console.Write("Dime otro: ");
        int segundoNumero = Convert.ToInt32( Console.ReadLine() );

        if (primerNumero % 2 == 0 && segundoNumero % 2 == 0)
        {
            Console.WriteLine("Los dos son pares.");
        }
        else if (primerNumero % 2 == 0 || segundoNumero % 2 == 0)
        {
            Console.WriteLine("Uno es par");
        }
        else
        {
            Console.WriteLine("Los dos son impares");
        }
    }
}

