/* Eduardo (...), retocado por Nacho
 * 
 * 69. Crea un programa que pida al usuario 10 números reales, 
 * los guarde en una matriz bidimensional de 2x5 datos, y luego muestre 
 * el promedio de los valores que hay guardados en la primera mitad de 
 * la matriz, luego el promedio de los valores en la segunda mitad de 
 * la matriz y finalmente el promedio global.
 */

using System;
class Ejercicio69
{
    static void Main()
    {
        const byte COLUMNAS = 5;
        const byte FILAS = 2;
        double[,] numeros = new double[FILAS,COLUMNAS];
        double[] suma = new double[FILAS];
        double sumaGlobal = 0;
        
        Console.WriteLine("Vamos a introducir 10 numeros enteros");
        
        for (int i = 0; i < FILAS; i++)
        {
            for (int j = 0; j < COLUMNAS; j++)
            {
                Console.WriteLine("Introduzca dato en fila {0}, columna {1}",
                    i+1, j+1);
                numeros[i,j] = Convert.ToDouble(Console.ReadLine());
            }
        }
        
        for (int i = 0; i < FILAS; i++)
        {        
            suma[i] = 0;
            for (int j = 0; j < COLUMNAS; j++)
            {
                suma[i] += numeros[i,j];
                sumaGlobal += numeros[i,j];
            }
            Console.WriteLine("El promedio de los datos de la fila {0} es: {1}",
                i+1, suma[i] / COLUMNAS);
        }
        
        Console.WriteLine("El promedio de todos los datos es {0}",
            sumaGlobal / (FILAS*COLUMNAS) );
        
        
    }
}

