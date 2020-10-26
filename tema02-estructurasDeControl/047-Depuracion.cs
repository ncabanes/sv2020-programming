/*
Carlos (...)
Ejercicio 47. Debug

Depuración: Crea un programa para mostrar ciertos valores de la función y = x^2 
- 2x + 1 (usando números enteros para x, que vayan desde -10 a +10) Añade un 
punto de interrupción en el momento en que calculas el valor de Y, y comprueba 
los valores de x^2 y de 2x.
*/

using System;

class Ejercicio47
{
    static void Main()
    {

        for(int x = -10; x <= 10; x++)
        {
            Console.Write("Para el valor de x = {0}, ", x);
            
            // Añadir punto de interrupción en la siguiente línea
            int y = x*x- 2*x + 1;
            
            // Mostrar en el depurador los valores de x*x y de 2*x
            
            // Finalmente, mostramos el resultado en consola
            Console.WriteLine("y = {0}", y);
        }
    }
}
