/* Eduardo (...)
 * 
 * Crea un programa que muestre un menú que permita al usuario introducir 
 * palabras (en una lista de strings), ver todas ellas (haciendo una pausa tras 
 * cada 22 palabras), buscar las que contengan un cierto texto, modificar una 
 * de ellas o borrar una de ellas.
 */

using System;
using System.Collections.Generic;

class Ejercicio162
{ 
    public static void Main()
    {
        List<string> palabros = new List<string>();

        string seleccion;
        bool salir = false;
        int contadorDePalabras = palabros.Count;
        
        do
        {
            MostrarMenu();
            Console.WriteLine("Seleccione una opción del menu");
            seleccion = Console.ReadLine();
            AnalizarOpcion(seleccion, 
                ref palabros, contadorDePalabras, ref salir);
        }
        while (!salir);
    }

    public static void MostrarMenu()
    {
        Console.WriteLine("--------  MENU ---------");
        Console.WriteLine("1. AÑADIR PALABRA");
        Console.WriteLine("2. MOSTRAR PALABRAS");
        Console.WriteLine("3. MODIFICAR PALABRA");
        Console.WriteLine("4. BUSCAR PALABRA");
        Console.WriteLine("5. BORRAR PALABRA");
        Console.WriteLine("X. SALIR");
    }

    public static void AnalizarOpcion(string opcion, ref List<string> palabros, 
        int contadorDePalabras, ref bool salir)
    {
        switch (opcion.ToUpper())
        {
            case "1":
                AnyadirPalabra(ref palabros);
                Console.Clear();
                break;
            case "2":
                MostrarPalabras(ref palabros);
                Console.Clear();
                break;
            case "3":
                ModificarPalabra(ref palabros);
                Console.Clear();
                break;
            case "4":
                BuscarPalabra(ref palabros);
                Console.Clear();
                break;
            case "5":
                BorrarPalabra(ref palabros);
                Console.Clear();
                break;
            case "X":
                salir = true;
                break;
            default:
                Console.WriteLine("Selección incorrecta. ¡Lease el manual!");
                break;
        }
    }

    public static void BorrarPalabra(ref List<string> palabros)
    {
        string palabraBorrar;
        int posicion;

        Console.WriteLine("Escriba \"P\" para indicar la palabra a borrar " +
            "o \"I\" para indicar qué posicion ocupa.");
        string seleccion = Console.ReadLine().ToUpper();

        if (seleccion == "P")
        {
            Console.WriteLine("Escriba la palabra que desea borrar");
            palabraBorrar = Console.ReadLine();
            palabros.Remove(palabraBorrar);
        }

        else if (seleccion == "I")
        {
            Console.WriteLine("Indique la posición de la palabra a borrar");
            posicion = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Borrando: {0}", palabros[posicion - 1]);
            palabros.RemoveAt(posicion - 1);
            
        }
        else
            Console.WriteLine("Selección incorrecta!!");

        Console.WriteLine("Palabra borrada correctamente, pulse " +
                "tecla para continuar");
        Console.ReadLine();
    }


    public static void BuscarPalabra(ref List<string> palabros)
    {
        string palabraBuscada;
        bool encontrada = false;

        Console.WriteLine("Indique qué palabra desea buscar");
        palabraBuscada = Console.ReadLine();

        for (int i = 0; i < palabros.Count; i++)
        {
            if (palabros[i] == palabraBuscada)
            {
                encontrada = true;
                Console.WriteLine("Palabra encontrada en la posición {0}", i + 1);
            }
        }

        if (!encontrada)
            Console.WriteLine("Palabra no encontrada");

        Console.WriteLine("Pulse tecla para continuar");
        Console.ReadLine();
    }

    public static void ModificarPalabra(ref List<string> palabros)
    {
        string palabraModificar;
        string nuevaPalabra;
        int posicion;


        Console.WriteLine("Escriba \"P\" para indicar la palabra a modificar " +
            "o \"I\" para indicar qué posicion ocupa la palabra a modificar");
        string seleccion = Console.ReadLine().ToUpper();

        if (seleccion == "P")
        {
            Console.WriteLine("Escriba la palabra que desea modificar");
            palabraModificar = Console.ReadLine();

            Console.WriteLine("Indique la nueva palabra");
            nuevaPalabra = Console.ReadLine();

            palabros[palabros.IndexOf(palabraModificar)] = nuevaPalabra;
        }

        else if (seleccion == "I")
        {
            Console.WriteLine("Indique la posición de la palabra a modificar");
            posicion = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("La palabra a modificar es: {0}", palabros[posicion - 1]);
            Console.WriteLine("Indique un nuevo valor");
            palabros[posicion - 1] = Console.ReadLine();
        }
        else
            Console.WriteLine("Selección incorrecta!!");

        Console.WriteLine("Palabra modificada correctamente, pulse " +
                "tecla para continuar");
        Console.ReadLine();
    } 



    public static void AnyadirPalabra(ref List<string> palabros)
    {
        Console.WriteLine("Introduzca palabra:");
        string dato = Console.ReadLine();
        palabros.Add(dato);
        
    }
    public static void MostrarPalabras(ref List<string> palabros) 
    {
        int cuentaVueltas = 0;
        int contadorDePalabras = palabros.Count;

        for (int i = 0; i < contadorDePalabras; i++)
        {
            Console.WriteLine("{0}.- {1}", i + 1, palabros[i]);
            cuentaVueltas++;
            if (cuentaVueltas % 22 == 0)
            {
                Console.WriteLine("Pulse Intro para continuar");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Pulse Intro para volver");
        Console.ReadLine();
    }
}
