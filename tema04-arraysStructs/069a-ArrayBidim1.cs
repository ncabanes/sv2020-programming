/* Eduardo (...)
 * 
 * 69. Crea un programa que pida al usuario 10 números reales, 
 * los guarde en una matriz bidimensional de 2x5 datos, y luego muestre 
 * el promedio de los valores que hay guardados en la primera mitad de 
 * la matriz, luego el promedio de los valores en la segunda mitad de 
 * la matriz y finalmente el promedio global.
 */

using System;

class Ejercicio69originalç
{
    static void Main()
    {
        const byte COLUMNAS = 5;
        const byte FILAS = 2;
        double[,] numeros = new double[FILAS,COLUMNAS];
        double promedio_fila1 = 0;
        double promedio_fila2 = 0;
        double promedio;
        
        Console.WriteLine("Vamos a introducir 10 numeros enteros");
        
        for (int i = 0; i < FILAS; i++)
        {
            for (int j = 0; j < COLUMNAS; j++)
            {
                Console.WriteLine("Introduzca dato en fila {0}, columna {1}",
                i,j);
                numeros[i,j] = Convert.ToDouble(Console.ReadLine());
            }
        }
        
        for (int i = 0; i < COLUMNAS; i++)
        {
            promedio_fila1 += numeros[0,i];
        }
        
        Console.WriteLine("El promedio de los datos de la primera fila es: {0}",
            promedio_fila1 / COLUMNAS);
        
        for (int i = 0; i < COLUMNAS; i++)
        {
            promedio_fila2 += numeros[1,i];
        }
        
        Console.WriteLine("El promedio de los datos de la segunda fila es: {0}",
            promedio_fila2 / COLUMNAS);
        
        promedio = (promedio_fila1 + promedio_fila2) / 2;
        
        Console.WriteLine("El promedio de todos los datos es {0}",
            promedio);
        
        
    }
}

