/*
Carlos (...)
Ejercicio 108. Probar funciones mejorado
*/

using System;

class Ejercicio108
{
    static bool EsCircular(string numero)
    {
        int contador = 0;
        bool circular = true;

        while (circular && contador <= numero.Length)
        {
            numero = numero.Substring(1) + numero[0];

            circular = EsPrimo(Convert.ToInt32(numero));
            contador++;
        }

        return circular;
    }

    static bool EsPrimo(int numero)
    {
        int contador = 0;

        for (int j = 1; j <= numero; j++)
        {
            if (numero % j == 0)
            {
                contador++;
            }
        }

        if (contador == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void ContarMm(string cadena, ref int mays, ref int mins)
    {
        for (int i = 0; i < cadena.Length; i++)
        {
            if (cadena[i] >= 'a' && cadena[i] <= 'z')
            {
                mins++;
            }
            else if (cadena[i] >= 'A' && cadena[i] <= 'Z')
            {
                mays++;
            }
        }
    }

    static void EscribirCentradoYSubrayado(string cadena)
    {
        for (int i = 0; i < (80 - cadena.Length) / 2; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(cadena);

        for (int i = 0; i < (80 - cadena.Length) / 2; i++)
        {
            Console.Write(" ");
        }
        for (int i = 0; i < cadena.Length; i++)
        {
            Console.Write("_");
        }
    }

    static long Mcd(long numero1, long numero2)
    {
        while (numero2 != 0)
        {
            long auxiliar = numero1 % numero2;
            numero1 = numero2;
            numero2 = auxiliar;
        }

        return numero1;
    }

    static int Main(string[] args)
    {
        const int CORRECTO = 0;
        const int PARAM_INCORRECTO = 1;
        const int FALTA_PARAMETRO = 2;

        int codigoDeSalida = 0;

        if (args.Length > 0)
        {
            string menu = args[0];
            menu = menu.ToUpper();

            switch (menu)
            {
                case "cprime":
                    if(args.Length > 2)
                    {
                        string numero = args[1];

                        if (EsCircular(numero))
                        {
                            Console.WriteLine(numero + " es primo circular.");
                        }
                        else
                        {
                            Console.WriteLine(numero + " no es primo circular.");
                        }

                        codigoDeSalida = CORRECTO;
                    }
                    else
                    {
                        codigoDeSalida = FALTA_PARAMETRO;
                    }
                    break;

                case "mm":
                    if(args.Length > 2)
                    {
                        string palabra = args[1];
                        int mays = 0, mins = 0;

                        ContarMm(palabra, ref mays, ref mins);
                        Console.WriteLine ("Mayúsculas: " + mays +
                            ", minúsculas: " + mins);

                        codigoDeSalida = CORRECTO;
                    }
                    else
                    {
                        codigoDeSalida = FALTA_PARAMETRO;
                    }
                    break;

                case "centrar":
                    if(args.Length > 2)
                    {
                        string texto = args[1];
                        EscribirCentradoYSubrayado(texto);

                        codigoDeSalida = CORRECTO;
                    }
                    else
                    {
                        codigoDeSalida = FALTA_PARAMETRO;
                    }
                    break;

                case "mcd":
                    if(args.Length > 3)
                    {
                        long numero1 = Convert.ToInt64(args[1]);
                        long numero2 = Convert.ToInt64(args[2]);

                        Console.WriteLine ("El máximo común divisor de {0} y {1} es: {2}",
                            numero1, numero2, Mcd(numero1, numero2));

                        codigoDeSalida = CORRECTO;
                    }
                    else
                    {
                        codigoDeSalida = FALTA_PARAMETRO;
                    }
                    break;

                default:
                    codigoDeSalida = PARAM_INCORRECTO;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Uso: cprime / mm / centrar / mcd");
            codigoDeSalida = PARAM_INCORRECTO;
        }

        return codigoDeSalida;
    }
}
