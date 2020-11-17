//Roberto (...)
/* 65. Crea un array de números reales de doble precisión, con espacio para 
 * 10 datos. Pide al usuario esos 10 datos y luego muestra un menú que le 
 * permita: Ver todos los datos en su orden original, ver todos los datos en 
 * orden inverso, mostrar el máximo de los datos, mostrar el mínimo de los 
 * datos, buscar un cierto dato, salir. La opción de Buscar preguntará el dato 
 * que se quiere localizar y responderá si ese dato era parte de los 10 
 * iniciales o no.*/
 
using System;

class Ejercicio65
{
    static void Main()
    {
        const sbyte capacidad = 10;
        double[] datos = new double[capacidad];
        sbyte i;
        byte opcion;
        double maximo;
        double minimo;
        bool encontrado;
        double buscar;
        
        for (i = 0; i < capacidad; i++)
        {
            Console.Write("Introduce un número: ");
            datos[i] = Convert.ToDouble( Console.ReadLine() );
        }
        
        do
        {   
            Console.WriteLine();
            Console.WriteLine("1. Ver datos en orden de introducción.");
            Console.WriteLine("2. Ver datos en orden inverso.");
            Console.WriteLine("3. Ver el máximo de los datos introducidos.");
            Console.WriteLine("4. Ver el mínimo de los datos introducidos.");
            Console.WriteLine("5. Buscar un dato.");
            Console.WriteLine("0. Salir.");
            Console.WriteLine();
            
            Console.Write("Elija una opción: ");
            opcion = Convert.ToByte( Console.ReadLine() );
            
            switch (opcion)
            {   
                case 1:
                    for (i = 0; i < capacidad; i++)
                        Console.WriteLine(datos[i]);
                    break;
                    
                case 2:
                    for (i = capacidad - 1; i >= 0; i--)
                        Console.WriteLine(datos[i]);
                    break;
                
                case 3:
                    maximo = datos[0];
                    for (i = 1; i < capacidad; i++)
                    {
                        if (datos[i] > maximo)
                        {
                            maximo = datos[i];
                        }
                    }
                    Console.WriteLine("El máximo es: {0}", maximo);
                    break;
    
                case 4:
                    minimo = datos[0];
                    for (i = 1; i < capacidad; i++)
                    {
                        if (datos[i] < minimo)
                        {
                            minimo = datos[i];
                        }
                    }
                    Console.WriteLine("El minimo es: {0}", minimo);
                    break;
                    
                case 5:
                    Console.Write("Introduzca el número que quiere buscar: ");
                    buscar = Convert.ToDouble( Console.ReadLine() );
                    Console.WriteLine();
                    
                    encontrado = false;
                    for (i = 0; i < capacidad; i++)
                    {
                        if (datos[i] == buscar)
                        {
                            encontrado = true;
                        }
                    }
            
                    if (encontrado == true)
                    {
                        Console.WriteLine("Dato hallado.");
                    }
                    else
                    {
                        Console.WriteLine("Dato no hallado.");
                    }
                    break;
            }
        }
        while (opcion != 0);
        
        Console.WriteLine("Hasta otra.");   
    }
}

