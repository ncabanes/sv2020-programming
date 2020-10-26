/* 
38. Escribe los números del 100 al 0, disminuyendo de 10 en 10 (100 90 80 70 ... 10 0) usando "for".
*/

using System;

class Ejercicio_38
{
    static void Main()
    {
        int contador;
        for (contador = 100; contador >= 0; contador -= 10)
        {
            Console.Write(contador + " ");
        }
    }
}
