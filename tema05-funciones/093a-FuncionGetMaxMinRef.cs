/*93. Crea una función llamada "GetMaxMin", que devolverá el máximo y el mínimo 
del array de enteros que se pase como parámetro.
Iván (...)*/

// Variante 1: con "ref"

using System;

public class Ejercicio_93
{
    public static void GetMaxMin(int[] numeros, ref int maximo, ref int minimo)
    {
        maximo = numeros[0];
        minimo = numeros[0];
        
        for(int i = 1; i < numeros.Length; i++)
        {
            if(numeros[i] > maximo)
            {
                maximo = numeros[i];
            }
        }
        for(int i = 1; i < numeros.Length; i++)
        {
            if(numeros[i] < minimo)
            {
                minimo = numeros[i];
            }
        }
    }
    
    public static void Main()
    {
        int minimo = 0, maximo = 0;
        int[] numeros = {15, 205, -19, 625, 99 , 8 ,623};
        GetMaxMin(numeros, ref maximo, ref minimo);
        Console.WriteLine("Máximo: " + maximo + " Mínimo: " + minimo);
    }
}
