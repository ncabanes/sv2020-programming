/* Alejandro Pertíñez Gómez 1 DAM */
/* 87. Crea una función llamada "EsPrimoPalindromo", que devolverá true 
 * si el parámetro es un número primo que también es palíndromo, o 
 * false en caso contrario. Puedes apoyarte en las funciones que ya has 
 * creado antes. Úsala para mostrar los primos palíndromos que hay 
 * entre el 1 y el 1000.*/
 
using System;

class Program 
{
    static bool EsPrimo(int numero)
    {
        if (numero == 1)
        {
            return false;
        }
        else
        {
            for(int i = 2; i < numero; i++)
            {
                if (numero%i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
    
    static bool EsPalindromo(string texto)
    {
        int inicio = 0;
        int final = texto.Length - 1;
        texto = texto.ToUpper();
        
        while (inicio < final)
        {
            do 
            {
                if (texto[inicio] == ' ')
                { 
                    inicio++;
                }
                else if (texto[final] == ' ')
                {
                    final--;
                }
            }while(texto[inicio] == ' ' || texto[final] == ' ');
            
            if (texto[inicio] != texto[final])
            {
                return false;
            }
            inicio++;
            final--;
        }
        
        return true;
    }
    
    static bool EsPrimoPalindromo(int numero)
    {
        return EsPrimo(numero) && EsPalindromo(numero.ToString());
    }

    public static void Main()
    {
        const int MAXIMO = 1000;    
        int cantidad = 0;
        
        Console.Write("Primos palíndromos: ");
        
        for (int i = 1; i < MAXIMO; i++)
        {
            if(EsPrimoPalindromo(i))
            {
                cantidad++;
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
        Console.WriteLine("{0} primos palíndromos encontrados", cantidad);
        
    }
    
}
