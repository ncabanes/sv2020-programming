/*
 * Eduardo (...)
 * Programa para identificar numeros primos
 */
 
 using System;
 class NumeroPrimo
 {
     static void Main()
     {
         int numero, divisorActual;
         int divisoresEncontrados = 0;
         Console.WriteLine("Introduzca número");
         numero = Convert.ToInt32(Console.ReadLine());
         
         divisorActual = 1;
         while (divisorActual <= numero)
         {
             if (numero % divisorActual == 0)   
             {
                divisoresEncontrados = divisoresEncontrados + 1;
             }
             divisorActual = divisorActual + 1;
         }
         Console.Write("El numero {0} tiene {1} divisores", 
            numero, divisoresEncontrados);
         
         if (divisoresEncontrados == 2) 
            Console.Write(" por lo tanto es un número primo");
         else 
            Console.Write(" por lo tanto no es un número primo");
     }
 }
 
            
                
