/*
Carlos (...) - 1ºDAM
Ejercicio 73
*/

/*
Crea un programa en C# que pueda almacenar fichas de hasta 1000 programas de 
ordenador. Para cada programa, debe guardar los siguientes datos:

Nombre
Descripción
Versión (es un conjunto de 2 datos: 
    el mes de lanzamiento –byte- y el año de lanzamiento –entero corto sin signo-)

El programa debe permitir al usuario las siguientes operaciones:

1- Añadir datos de un nuevo programa. 

2- Mostrar los nombres de todos los programas almacenados. Cada nombre debe 
aparecer en una línea distinta, precedido por el número de programa (empezando 
a contar desde 1). Si hay más de 20 programas, se deberá hacer una pausa tras 
mostrar cada bloque de 20 programas, y esperar a que el usuario pulse Intro 
antes de seguir. Se deberá avisar si no hay datos.

3- Ver todos los datos de un cierto programa (a partir de su número de 
registro, contando desde 1). Se deberá avisar (pero no volver a pedir) si el 
número no es válido.

4- Modificar una ficha (se pedirá el número y se volverá a introducir el valor 
de todos los campos. Se debe avisar (pero no volver a pedir) si introduce un 
número de ficha incorrecto.

5- Borrar un cierto dato, a partir del número que indique el usuario. Se debe 
avisar (pero no volver a pedir) si introduce un número incorrecto.

T- Terminar el uso de la aplicación (como no sabemos almacenar la información, 
los datos se perderán).
*/

using System;

class Ejercicio73
{
    struct MesAnyo
    {
        public byte mes;
        public ushort anyo;
    }

    struct DatosPrograma
    {
        public string nombre;
        public string descripcion;
        public MesAnyo version;
    }

    static void Main()
    {
        DatosPrograma[] programas = new DatosPrograma[1000];
        int cantidadDatos = 0;
        bool terminar = false;

        const char OPC_ANYADIR = '1';
        const char OPC_VER_NOMBRES = '2';
        const char OPC_VER_DETALLE = '3';
        const char OPC_MODIFICAR = '4';
        const char OPC_BORRAR = '5';
        const char OPC_SALIR_MAY = 'T';
        const char OPC_SALIR_MIN = 't';

        char menu;

        do
        {
            Console.WriteLine(OPC_ANYADIR + ". Añadir datos de un programa.");
            Console.WriteLine(OPC_VER_NOMBRES + ". Mostrar los nombres de todos los " +
                "programas almacenados.");
            Console.WriteLine(OPC_VER_DETALLE + ". Ver todos los datos de un " +
                "cierto programa.");
            Console.WriteLine(OPC_MODIFICAR + ". Modificar una ficha.");
            Console.WriteLine(OPC_BORRAR + ". Borrar un programa.");
            Console.WriteLine(OPC_SALIR_MAY + ". Terminar.");

            menu = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();

            switch (menu)
            {
                case OPC_ANYADIR:
                    try
                    {
                        Console.Write("Introduce el nombre: ");
                        programas[cantidadDatos].nombre =
                            Console.ReadLine();

                        Console.Write("Introduce la descipción: ");
                        programas[cantidadDatos].descripcion =
                            Console.ReadLine();

                        Console.Write("Introduce el mes de lanzamiento: ");
                        programas[cantidadDatos].version.mes =
                            Convert.ToByte(Console.ReadLine());

                        Console.Write("Introduce el año de lanzamiento: ");
                        programas[cantidadDatos].version.anyo =
                            Convert.ToUInt16(Console.ReadLine());

                        cantidadDatos++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Valor no válido, el programa " +
                            "no se ha guardado.");
                    }
                    break;

                case OPC_VER_NOMBRES:
                    if (cantidadDatos < 1)
                    {
                        Console.WriteLine("No hay datos.");
                    }
                    else
                    {
                        int filaActual = 0;
                        for (int i = 0; i < cantidadDatos; i++)
                        {
                            Console.WriteLine( (i+1) + ". " + programas[i].nombre);
                            filaActual++;
                            if (filaActual == 22)
                            {
                                Console.WriteLine("Pulse Intro para seguir");
                                Console.ReadLine();
                                filaActual = 0;
                            }
                        }
                    }
                    break;

                case OPC_VER_DETALLE:
                    Console.Write("Introduce un número de programa: ");
                    int programaVer = Convert.ToInt32(Console.ReadLine());

                    if ((programaVer > cantidadDatos) || (programaVer < 1))
                    {
                        Console.WriteLine("Número no válido.");
                    }
                    else
                    {
                        Console.WriteLine(programaVer +
                            ". {0} {1} V.{2}.{3}",
                            programas[programaVer-1].nombre,
                            programas[programaVer-1].descripcion,
                            programas[programaVer-1].version.mes,
                            programas[programaVer-1].version.anyo);
                    }
                    break;

                case OPC_MODIFICAR:
                    Console.Write("Introduce el número de programa que " +
                        "quieres modificar: ");
                    int programaModif = Convert.ToInt32(Console.ReadLine());

                    if ((programaModif > cantidadDatos) ||
                        (programaModif < 1))
                    {
                        Console.WriteLine("Número no válido.");
                    }
                    else
                    {
                        try
                        {
                            Console.Write("Introduce el nombre: ");
                            programas[programaModif-1].nombre = Console.ReadLine();

                            Console.Write("Introduce la descipción: ");
                            programas[programaModif-1].descripcion = Console.ReadLine();

                            Console.Write("Introduce el mes de lanzamiento: ");
                            programas[programaModif].version.mes =
                                Convert.ToByte(Console.ReadLine());

                            Console.Write("Introduce el año de lanzamiento: ");
                            programas[programaModif].version.anyo =
                                Convert.ToUInt16(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Valor no válido, el " +
                                "programa no se ha guardado.");
                        }
                    }
                    break;

                case OPC_BORRAR:
                    Console.Write("Introduce el número de programa que " +
                        "quieres borrar: ");
                    int programaBorr = Convert.ToInt32(Console.ReadLine());

                    if ((programaBorr > cantidadDatos) ||
                        (programaBorr < 1))
                    {
                        Console.WriteLine("Número no válido.");
                    }
                    else
                    {
                        for (int i = programaBorr; i <= cantidadDatos; i++)
                        {
                            programas[i - 1] = programas[i];
                        }
                        cantidadDatos--;
                    }
                    break;

                case OPC_SALIR_MAY:
                case OPC_SALIR_MIN:
                    terminar = true;
                    break;

                default:
                    Console.WriteLine("Opción no válido.");
                    break;
            }

            Console.WriteLine("");
        }
        while (!terminar);

        Console.WriteLine("Hasta luego!");
    }
}
