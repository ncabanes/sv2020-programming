/* Alejandro (...) */
/* 105. El máximo divisor común (MCD) de dos números A y B se puede 
 * calcular de forma recursiva utilizando el algoritmo de Euclides: 
 * si B es 0, la respuesta es A; De lo contrario, debemos probar el MCD 
 * de B y A% B. 
Crea dos funciones que devuelvan el MCD de dos números enteros largos: 
* una debe ser iterativa (NO recursivo, sino usando "for" o "while"), y 
* debe llamarse "Mcd". La segunda función debe hacerlo de forma 
* recursiva, utilizando el algoritmo de Euclides y debe llamarse "McdR". 
* (2 puntos). Un ejemplo de uso podría ser*/

using System;

class Program
{
    
    static long MCD(long numero1, long numero2)
    {
        long resultado = 1;
        
        for (int i = 1; i < numero1; i++)
        {
            if (numero1%i == 0 && numero2%i == 0)
            {
                if (i > resultado)
                {
                    resultado = i;
                }
            }
        }
        
        return resultado;
    }
    
    static long MCDR(long numero1, long numero2)
    {
        long aux;
        if (numero1<numero2)
        {
            aux = numero1;
            numero1 = numero2;
            numero2 = aux;
        }
        if(numero1%numero2 == 0)
        {
            return numero2;
        }
        else
        {
            return MCDR(numero2, numero1%numero2);
        }
    }
    
    static void Main()
    {
        Console.WriteLine(MCD(78,30));
        Console.WriteLine(MCDR(78,30));
    }
}


