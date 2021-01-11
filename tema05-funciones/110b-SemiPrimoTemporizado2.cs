// Buscador de semiprimos, versión acelerada

/*
Se puede medir el tiempo que se tarda en realizar un proceso mirando el 
valor del reloj del sistema antes y después de dicho proceso, y 
restando sus valores, como en el siguiente ejemplo:

DateTime comienzo = DateTime.Now;
BuscarYMostrarSemiprimos(numero1,numero2);
Console.WriteLine("Tiempo transcurrido: "+ 
    (DateTime.Now-comienzo));

Usa ese fragmento de código para intentar mejorar la velocidad del 
programa que busca números semiprimos (ejercicio 094). Empieza por ver 
el efecto de tus mejoras al buscar números pequeños (del 1 al 50, luego 
del 100 al 200, después del 2000 al 2500, y así sucesivamente). Como 
resultado final, deberías conseguir que localice los números semiprimos 
que hay entre 1 y 9000 en menos de un segundo. Algunas de las mejoras 
que puedes aplicar son:

¿Realmente es necesario un doble "for" en "EsSemiPrimo" o se puede 
hacer con un único "for"?

A la hora de comprobar si es primo, ¿es necesario llegar hasta n?  ¿se 
podría limitar la búsqueda a n/2?  ¿y a raíz( n )?

A la hora de probar posibles divisores para ver si un número es primo, 
¿necesitas probar los números pares?

¿Se puede interrumpir la comprobación de si es primo antes de contar 
todos los divisores?

(Enunciado original

Crea un programa que pida al usuario dos números enteros largos y 
muestre qué números hay entre ambos (inclusive) que sean 
"semiprimos" (o "biprimos": producto de dos números primos no 
necesariamente distintos). Por ejemplo, para los números 10 y 20, 
la respuesta sería 10 14 15. Para gestionar los errores de 
introducción de datos, no debes usar "try-catch" sino "TryParse" 
(apartado 5.7.4 de los apuntes).

*/

using System;

class SemiPrimoTemporizado
{
    static void Main()
    {
        long numero1, numero2;
        
        Console.WriteLine("Dime el rango en el que quieres buscar ");
        
        do
        {
            Console.Write("Desde: ");
        } 
        while (! Int64.TryParse(Console.ReadLine(), out numero1));
        
        do
        {
            Console.Write("Hasta: ");
        }
        while (! Int64.TryParse(Console.ReadLine(), out numero2));
        
        DateTime comienzo = DateTime.Now;
        BuscarYMostrarSemiprimos(numero1,numero2);
        Console.WriteLine("Tiempo transcurrido: "+ 
            (DateTime.Now-comienzo));
    }

    // EsPrimo, versión algo mejorada
    static bool EsPrimo(long numero)
    {
        if (numero == 1)
            return false;
        if (numero == 2)
            return true;
        if (numero % 2 == 0)
            return false;

        for (long i = 3; i <= (int) Math.Sqrt(numero); i+=2)
        {
            if (numero % i == 0)
                return false;
        }
        return true;
    }
    
    // EsSemiPrimo, versión con un solo "for"
    static bool EsSemiPrimo(long numero)
    {
        for (long i = 2; i <= numero/2; i++)
        {
            long j = numero / i;
            if (i*j == numero && EsPrimo(i) && EsPrimo(j) )
            {
                return true;
            }
        }
        return false;
    }
    
    static void BuscarYMostrarSemiprimos(long desde, long hasta)
    {
        for (long i = desde; i <= hasta; i++)
        {
            if (EsSemiPrimo(i))
                Console.Write(i + " ");
        }
    }
}
