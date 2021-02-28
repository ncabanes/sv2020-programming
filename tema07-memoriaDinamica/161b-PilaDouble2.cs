/*161. Haz una variante del ejercicio anterior, en la que los datos no se 
introduzcan en una cola, sino en una pila, de modo que se obtendrán en orden
inverso al que se introdujeron. Nuevamente, puedes usar una pila con tipo o
sin tipo.*/

// Raúl (...), correcciones por Nacho

using System;
using System.Collections.Generic;

class PilaDouble2
{
    static void Main()
    {
        double n, suma = 0;
        int contador = 0;

        Stack<double> pila = new Stack<double>();
        string respuesta;
        do
        {
            Console.Write("Dime un entero (Intro para terminar): ");
            respuesta = Console.ReadLine();
            if (respuesta != "")
                pila.Push(Convert.ToDouble(respuesta));
        } while (respuesta != "");

        Console.WriteLine();
        Console.WriteLine("Datos al revés:");
        contador = pila.Count;
        while (pila.Count > 0)
        {
            n = pila.Pop();
            suma += n;
            Console.WriteLine(n);
        }

        double media = suma / contador;
        Console.WriteLine("La suma de datos es: {0}", suma);
        Console.WriteLine("La media de datos es: {0}", media);
    }
}

