/*40.Muestra las tablas de multiplicar de los números del 0 al 10, suando 
"for". Debe haber una línea en blanco separando cada tabla de multiplicar de la 
siguiente.*/

using System;

class Ej49
{
    static void Main()
    {

        for ( int tabla = 1; tabla <= 10; tabla++)
        {
            Console.WriteLine("TABLA DEL " + tabla );
            for ( int numero = 0; numero <= 10; numero++)
            {
                Console.WriteLine("{0} x {1} = {2}", 
                    tabla, numero, tabla*numero);
            }
            Console.WriteLine();
        }
    }
}
