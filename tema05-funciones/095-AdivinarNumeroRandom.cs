//Ejercicio que genera un número al azar que el usuario debe adivinar.
using System; 

class Ejercicio95
{
    static void Main()
    {
        int valor;
        int contador= 0;
        bool acertado = false;
        Random generador = new Random(); 
        int valorAlAzar = generador.Next(1, 101);
    
        do
        {
            Console.Write("Dime un número: ");
            valor = Convert.ToInt32(Console.ReadLine());
            contador++;
            if (valor == valorAlAzar)
            {
                Console.WriteLine("Has acertado!");
                acertado = true;
            }
            else if (valor > valorAlAzar)
            {
                Console.WriteLine("Te has pasado!");
            }
            else
            {
                Console.WriteLine("Te has quedado corto!");
            }
        }
        while ((! acertado) && (contador < 6));
        
        if (! acertado)
            Console.WriteLine("Te quedaste sin intentos! Era {0}", valorAlAzar);
    }
}
