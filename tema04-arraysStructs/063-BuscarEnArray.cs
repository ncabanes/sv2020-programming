/*
Pide al usuario 10 enteros largos y guárdalos en un array. Luego pide uno más y 
dile si estaba entre esos 10 datos iniciales, de 2 formas distintas: primero 
usando un booleano y luego usando un contador, para responderle cuántas veces 
aparecía (ambas respuestas serán parte del mismo programa, no dos programas 
independientes).
*/

using System;

class BuscarEnArray
{
    static void Main()
    {
        long[] numeros = new long[10];
        long buscarNumero;
        int i;
        int veces = 0;
        bool encontrado = false;

        for(i=0; i < numeros.Length; i++)
        {
            Console.WriteLine("Introduce el numero {0}:", i+1);
            numeros[i] = Convert.ToInt64(Console.ReadLine());                
        }

        Console.WriteLine("Introduzca otro numero:");
        buscarNumero = Convert.ToInt64(Console.ReadLine());

        for(i = 0; i < numeros.Length; i++)
            if (numeros[i] == buscarNumero)
                encontrado = true;

        if (encontrado)
            Console.WriteLine("Encontrado!");
        else
            Console.WriteLine("No encontrado");
            
        for(i = 0; i < numeros.Length; i++)
            if (numeros[i] == buscarNumero)
                veces++;

        if (veces > 0)
            Console.WriteLine("Aparece {0} veces ", veces);
    }
}
