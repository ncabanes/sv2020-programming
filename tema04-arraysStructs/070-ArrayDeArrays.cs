/*70. Crea un programa que pregunte al usuario cuántos datos guardará en un 
primer bloque de números reales, luego cuántos datos guardará en un segundo 
bloque, y finalmente pida los datos en sí. Los debe guardar en un array de 
arrays. Después mostrará el promedio de los valores que hay guardados en el 
primer subarray, luego el promedio de los valores en el segundo subarray y 
finalmente el promedio global.

Iván (...), retocado por Nacho */

using System;
class Ejercicio69
{
    static void Main()
    {
        const byte FILAS = 2;
        float[][] datos;
        float[] suma = new float[FILAS];
        float sumaTotal = 0;
        
        Console.Write("Indique los datos que almacenara el primer bloque: ");
        int cantidad1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Indique los datos que almacenara el segundo bloque: ");
        int cantidad2 = Convert.ToInt32(Console.ReadLine());

        datos = new float[2][];
        datos[0] = new float [cantidad1];
        datos[1] = new float [cantidad2];

        // Pedir datos
        for(int fila = 0; fila < FILAS; fila++)
        {
            for(int columna = 0; columna < datos[fila].Length; columna++)
            {
                Console.WriteLine("Introduce un número en la posición {0},{1}:",
                    fila+1, columna+1);
                datos[fila][columna] = Convert.ToSingle(Console.ReadLine());
            }
        }

        // Calcular y mostrar promedios
        for(int fila = 0; fila < FILAS; fila++)
        {
            suma[fila] = 0;
            for(int columna = 0; columna < datos[fila].Length; columna++)
            {
                suma[fila] += datos[fila][columna];
                sumaTotal += datos[fila][columna];
            }
            Console.WriteLine("La media de la fila {0} es: {1}", 
                fila+1, suma[fila] / datos[fila].Length);
        }
        
        Console.WriteLine("La media total del array es: {0}", 
            sumaTotal / (cantidad1 + cantidad2) );
    }
}

