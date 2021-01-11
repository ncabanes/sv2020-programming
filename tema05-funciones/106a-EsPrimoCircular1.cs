/*106. Crea una función EsPrimoCircular, que devuelva true si el número entero 
largo pasado como parámetro es un primo circular 
if (EsPrimoCircular(117))
    Console.Write("117 es primo circular");
if (! EsPrimoCircular(23))
    Console.Write("23 no es primo circular");*/

//ALBERTO (...)

using System;

class EJERCICIO106
{
    static void Main()
    {
        Console.Write("Numero: ");
        long numeroSelect = Convert.ToInt64(Console.ReadLine());
        if (EsPrimoCircular(numeroSelect))
            Console.Write(numeroSelect + " es primo circular");
        else
            Console.Write(numeroSelect + " no es primo circular");
    }

    static bool EsPrimoCircular(long numero)
    {
        string numeroEnLetras = Convert.ToString(numero);
        int longitudNumero = numeroEnLetras.Length;
        int contadorDock = 0, contadorRotaciones = 0;

        do
        {
            numero = Convert.ToInt64(numeroEnLetras);
            if (EsPrimo(numero))
            {
                numeroEnLetras = numeroEnLetras.Substring(longitudNumero - 1) +
                    numeroEnLetras.Substring(0, longitudNumero - 1);
                contadorRotaciones++;
            }
            contadorDock++;
        } while (contadorDock<longitudNumero);

        if (contadorRotaciones == longitudNumero)
            return true;
        else
            return false;

    }
    static bool EsPrimo(long numero)
    {
        for (int i = 2; i < numero; i++)
        {
            if (numero % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

