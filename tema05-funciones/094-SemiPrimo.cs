/*94. Crea un programa que pida al usuario dos números enteros largos y 
 * muestre qué números hay entre ambos (inclusive) que sean 
 * "semiprimos" (o "biprimos": producto de dos números primos no 
 * necesariamente distintos). Por ejemplo, para los números 10 y 20, 
 * la respuesta sería 10 14 15. Para gestionar los errores de 
 * introducción de datos, no debes usar "try-catch" sino "TryParse" 
 * (apartado 5.7.4 de los apuntes).*/

using System;

class ejercicio82
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
        
        BuscarYMostrarSemiprimos(numero1,numero2);
    }

    // EsPrimo, aproximación lenta (pero correcta), según la definición
    static bool EsPrimo(long numero)
    {
        bool primo = false;
        long divisores = 0;

        for (long i = 1; i <= numero; i++)
        {
            if (numero % i == 0)
                divisores ++;
        }

        if (divisores == 2)
            primo = true;

        return primo;
    }
    
    // EsSemiPrimo, forma lenta y exhaustiva
    static bool EsSemiPrimo(long numero)
    {
        bool encontradosDivisoresPrimos = false;
        for (long i = 1; i <= numero; i++)
        {
            for (long j = 1; j <= numero; j++)
            {
                if (EsPrimo(i) && EsPrimo(j) && i*j == numero)
                    encontradosDivisoresPrimos = true;
            }
        }
        return encontradosDivisoresPrimos;
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
