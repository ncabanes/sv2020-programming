//Jorge (...)
//Ejercicio84

/*
84. Crea una función llamada "SumaDeArray", que devolverá la suma de los 
elementos de un array de enteros que se pasará como parámetro. Pruébala con un 
array prefijado. La función deberá aparecer antes de "Main".
*/

using System;

class Ejercicio84
{

    static int SumaDeArray(int[] arrayEnteros)
    {
        int resultado = 0;

        for (int i = 0; i < arrayEnteros.Length; i++)
            resultado += arrayEnteros[i];

        return resultado;
    }

    static void Main()
    {
        int[] contenedor = { 5, 10, 15, 20 };
        Console.WriteLine("La suma del array es: {0}", SumaDeArray(contenedor));
    }
}
