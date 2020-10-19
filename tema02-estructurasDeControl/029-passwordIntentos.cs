// Ejercicio 29 - Tercera semana Tema 2
// Iván (...)
/* Escribir un programa en C# que nos pida una una clave numérica.
 * Se le dirá si puede pasar (si acierta la contraseña correcta: 1234) o no.
 * Si no puede pasar, se le devolverá a pedir tantas veces como sea necesario.*/
// VERSIÓN MEJORADA - Cuenta los intentos gastados.
 
using System;

class Ejercicio_29
{
    static void Main()
    {
        int clave = 1234;
        int intentos = 0;
            
        do
        {
            intentos = intentos + 1;
            
            Console.Write("Introduzca la contraseña: ");
            clave = Convert.ToInt32(Console.ReadLine());

            if (clave != 1234)
            {
                Console.WriteLine("CLAVE INCORRECTA");                
                Console.WriteLine("Intentos gastados: {0}", intentos);
                
            }
        }
        while (clave != 1234);
            
        Console.WriteLine("ACCESO PERMITIDO, a la {0} va la vencida",intentos );
    }
}
