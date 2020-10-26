/*    
37. Crea un programa que muestre los números del 100 al 250, 
separados por un espacio, sin avanzar de línea, usando "for".
*/

using System;

class Ejercicio_37
{
    static void Main()
    {
        int contador = 0;
        for (contador = 100; contador <= 250; contador++)
        {
            Console.Write(contador + " ");
        }
    }
}
