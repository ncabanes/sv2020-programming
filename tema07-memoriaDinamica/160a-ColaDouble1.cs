/*160. Pide al usuario números reales de doble precisión, tantos como desee, 
hasta que pulse Intro en vez de un número. Cada nuevo número lo deberás guardar
en una cola. Finalmente, mostrarás todos los datos que ha introducido, así como
su suma y su media. Puedes emplear una cola con tipo -Generics- o sin tipo, como
prefieras (se compartirán ambas soluciones, para que puedas comparar).*/

// ALBERTO (...)

// V1: Cola sin tipo

using System;
using System.Collections;

class Cola1
{
    static void Main()
    {
        Ejecutar();
    }

    public static void Ejecutar()
    {
        Queue miCola = new Queue();
        bool terminar = false;

        Console.WriteLine("Introduce numeros o pulsa intro para finalizar:");
        do
        {
            string numero = Console.ReadLine();
            if (numero != "")
            {
                miCola.Enqueue(Convert.ToDouble(numero));
            }
            else
            {
                terminar = true;
            }
        } 
        while (!terminar);

        Console.WriteLine("DATOS:");
        double suma = 0;
        int cantidad = miCola.Count;
        while (miCola.Count > 0)
        {
            double dato = (double) miCola.Dequeue();
            suma += dato;
            Console.WriteLine(dato);
        }
        Console.WriteLine("Suma: " + suma);
        Console.WriteLine("Media: " + suma/cantidad);
    }
}
