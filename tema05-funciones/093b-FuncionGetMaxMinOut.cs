/*93. Crea una función llamada "GetMaxMin", que devolverá el máximo y el mínimo 
del array de enteros que se pase como parámetro.
Iván (...)*/

// Variante 2: con "out"

using System;

public class Ejercicio_93
{
    public static void GetMaxMin(int[] numeros, out int maximo, out int minimo)
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
        int minimo, maximo;
        int[] numeros = {15, 205, -19, 625, 99 , 8 ,623};
        GetMaxMin(numeros, out maximo, out minimo);
        Console.WriteLine("Máximo: " + maximo + " Mínimo: " + minimo);
    }
}
