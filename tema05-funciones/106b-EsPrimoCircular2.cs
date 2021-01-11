/* Eduardo (...)
 * 
 * Crea una función EsPrimoCircular, que devuelva true si el número 
 * entero largo pasado como parámetro es un primo circular 
 */

using System;

class ejercicioMuyMortal
{
    static void Main()
    {
        Console.WriteLine("Indique un número para saber si es un" + 
        " número primo circular");
        long numero = Convert.ToInt64(Console.ReadLine());
        
        if (EsPrimoCircular(numero))
            Console.WriteLine("El {0} es un número primo circular",
              numero);
        else 
            Console.WriteLine("El {0} no es un número primo circular",
              numero);
    }
    static bool EsPrimoCircular(long numero)
    {
        bool siLoEs = true;
        //numero de cifras
        long numeroCifras = 1;
        long numeroParaContarCifras = numero;
        long cifraMovil;
        
        while (numeroParaContarCifras / 10 != 0)
        {
            numeroParaContarCifras = numeroParaContarCifras / 10;
            numeroCifras++;
        }
        
        for (int i = 0; i < numeroCifras; i++)
        {
            if (EsPrimo(numero) == false)
                siLoEs = false;
            cifraMovil = numero % 10;
            numero = numero / 10;
            numero = numero + cifraMovil * Convert.ToInt64(Math.Pow(10, 
                (numeroCifras - 1)));
        }
        return siLoEs;
        
    }
    static bool EsPrimo(long numero)
    {
        int contador = 0;
        bool primo = false;
        
        for (int i = 2; i < numero; i++)
            if (numero % i == 0)
                contador++;
        
        if (contador == 0)
            primo = true;
        
        return primo;
    }
}

