/*
En matemáticas, el número "e" se puede escribir como

e = 1 + 1/1 + 1/(1·2) + 1/(1·2·3) + …

Crea un programa que pregunte al usuario cuántos sumandos desea y le muestre el 
valor de la aproximación de e y la diferencia con el valor anterior (el que se 
obtendría con un sumando menos). El programa se repetirá hasta que el usuario 
pulse “Intro” sin introducir ningún número:

Sumandos? 1
e vale aproximadamente 1 (diferencia con 0 sumandos: 1)
Sumandos? 3
e vale aproximadamente 2,5 (diferencia con 2 sumandos: 0,5)
Sumandos?
¡Hasta otra!
*/

using System;

class NumeroE
{
    static void Main()
    {
        double sumandos;
        
        string respuesta;

        do
        {
            Console.Write("Sumandos? ");
            respuesta = Console.ReadLine();

            if (respuesta != "")
            {
                sumandos = Convert.ToDouble(respuesta);

                double e = 1;
                double eAnterior = 0;
                double denominador = 1;
                double diferencia = 0;

                for (int contador = 1; contador < sumandos; contador++)
                {
                    denominador = denominador * contador;
                    eAnterior = e;
                    e = e + (1 / denominador);
                }
                diferencia = e - eAnterior;
                Console.Write("e vale aproximadamente {0} ", e);
                Console.WriteLine("(la diferencia es {0})", diferencia);
            }
        }
        while (respuesta != "");

        Console.WriteLine("¡Hasta otra!");
    }
}
