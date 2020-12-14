/*
Ejercicio 81.  Crea una función llamada "Promedio", que devolverá un valor 
"double", el promedio de tres parámetros de tipo "double". Utilízala en un 
programa que muestre el promedio de tres datos prefijados, que serán parte de 
un array.

*/

using System;

class Ejercicio81
{
    static double Promedio(double[] numeros)
    {
        double suma = 0;
        for (int i = 0; i < numeros.Length; i++)
        {
            suma += numeros[i];
        }
        return suma / numeros.Length;
    }

    static void Main()
    {
        double[] datos = {1.0, 2.2, 3.456789};
        Console.WriteLine("El promedio es: " + Promedio(datos));
    }
}
