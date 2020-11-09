/* Alejandro Pertíñez Gomez 1 DAM*/
/* 60. Escribe un programa que pida al usuario números 
 * reales de doble precisión y muestre su máximo, mínimo, 
 * suma y media después de cada paso. 
 * Terminará cuando introduzca la palabra "fin"*/

using System;

class Estadistica
{
    static void Main()
    {
        try
        {
            string respuesta;
            bool primerNumero = true;
        
            double numero;
            double maximo = 0;
            double minimo = 0;
            double suma = 0;
            double media = 0;
            int contadorDeNumeros = 1;
            
            Console.Write("Dato: ");
            respuesta = Console.ReadLine();
        
            while(respuesta != "fin")
            {
                numero = Convert.ToDouble(respuesta);
                if(primerNumero)
                {
                    maximo = numero;
                    minimo = numero;
                    suma += numero;
                    media = suma/contadorDeNumeros;
                    primerNumero = false;
                }
                else 
                {
                    maximo = numero > maximo? numero: maximo;
                    minimo = numero < minimo? numero: minimo;
                    suma += numero;
                    media = suma/contadorDeNumeros;
                }
                Console.WriteLine("Max = {0}, Min = {1}, Suma = {2}, Media = {3}", 
                    maximo, minimo, suma, media);
                
                contadorDeNumeros++;
                Console.Write("Dato: ");
                respuesta = Console.ReadLine();
            }
                    
            Console.WriteLine("Hasta otra!!!");
        }
        catch(FormatException)
        {
            Console.WriteLine("Debe ser un numero o \"fin\"");
        }
    }
}
