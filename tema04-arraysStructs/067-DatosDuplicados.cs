using System;

//ALBERTO (...)

/* 67. Crea un programa que pida al usuario una serie de números enteros en una 
misma línea (varios números separados por espacios, como en "12 23 34 23 45") y 
después muestre los números que estén duplicados. En el ejemplo anterior, la 
respuesta sería "Duplicados: 23". Si no hubiera ningún duplicado, la respuesta 
deberá ser "Duplicados: Ninguno".*/

class Ejercicio67
{
    static void Main()
    {
        int contador=0;

        Console.Write("Introduzca numeros: ");
        string respuesta = Console.ReadLine();
        string[] fragmentos = respuesta.Split();
        int[] numerosElegidos = new int[fragmentos.Length];

        for (int i = 0; i < numerosElegidos.Length; i++)
        {
            numerosElegidos[i] = Convert.ToInt32(fragmentos[i]);
        }

        Console.Write("Duplicados: ");
        for(int i = 0; i < fragmentos.Length;  i++)
        {
            for (int j = i + 1; j < numerosElegidos.Length; j++)
            {
                if (numerosElegidos[i] == numerosElegidos[j])
                {
                    Console.Write(numerosElegidos[i] + " ");
                    contador++;
                }
            }
        }

        if (contador == 0)
        {
            Console.Write("Ninguno.");
        }
       
    }
}
