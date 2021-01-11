using System;
/*102. Crea una versión actualizada del gestor de programas (ejercicio 073),
 *  descomponiéndola en funciones*/

//Iván (...)

class Ejercicio_102
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

    static void MostrarMenu()
    {
        Console.WriteLine("1. Añadir datos de un programa.");
        Console.WriteLine("2. Mostrar los nombres de todos los " +
            "programas almacenados.");
        Console.WriteLine( "3. Ver todos los datos de un cierto programa.");
        Console.WriteLine("4. Modificar una ficha.");
        Console.WriteLine("5. Borrar un programa.");
        Console.WriteLine("T. Terminar.");
    }
    
    static string PedirOpcion()
    {
        return Console.ReadLine().ToUpper();
    }

    static int PedirNumeroPrograma()
    {
        Console.Write("Introduce el número de programa: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static void Anyadir(DatosPrograma[] programas, ref int cantidad)
    {
        try
        {
            Console.Write("Introduce el nombre: ");
            programas[cantidad].nombre =
                Console.ReadLine();

            Console.Write("Introduce la descipción: ");
            programas[cantidad].descripcion =
                Console.ReadLine();

            Console.Write("Introduce el mes de lanzamiento: ");
            programas[cantidad].version.mes =
                Convert.ToByte(Console.ReadLine());

            Console.Write("Introduce el año de lanzamiento: ");
            programas[cantidad].version.anyo =
                Convert.ToUInt16(Console.ReadLine());

            cantidad++;
        }
        catch (Exception)
        {
            Console.WriteLine("Valor no válido, el programa " +
                "no se ha guardado.");
        }
    }

    static void MostrarTodos(DatosPrograma[] programas, int cantidad)
    {
        if (cantidad < 1)
        {
            Console.WriteLine("No hay datos.");
        }
        else
        {
            int filaActual = 0;
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine((i + 1) + ". " + programas[i].nombre);
                filaActual++;
                if (filaActual == 22)
                {
                    Console.WriteLine("Pulse Intro para seguir");
                    Console.ReadLine();
                    filaActual = 0;
                }
            }
        }
    }

    static void MostrarDetallePrograma(DatosPrograma[] programas, int cantidad)
    {
        int programaVer = PedirNumeroPrograma();

        if ((programaVer > cantidad) || (programaVer < 1))
        {
            Console.WriteLine("Número no válido.");
        }
        else
        {
            Console.WriteLine(programaVer +
                ". {0} {1} V.{2}.{3}",
                programas[programaVer - 1].nombre,
                programas[programaVer - 1].descripcion,
                programas[programaVer - 1].version.mes,
                programas[programaVer - 1].version.anyo);
        }
    }

    static void Modificar(DatosPrograma[] programas, int cantidad)
    {
        int programaModif = PedirNumeroPrograma();

        if ((programaModif > cantidad) ||
            (programaModif < 1))
        {
            Console.WriteLine("Número no válido.");
        }
        else
        {
            try
            {
                Console.Write("Introduce el nombre: ");
                programas[programaModif - 1].nombre = Console.ReadLine();

                Console.Write("Introduce la descipción: ");
                programas[programaModif - 1].descripcion = Console.ReadLine();

                Console.Write("Introduce el mes de lanzamiento: ");
                programas[programaModif - 1].version.mes =
                    Convert.ToByte(Console.ReadLine());

                Console.Write("Introduce el año de lanzamiento: ");
                programas[programaModif - 1].version.anyo =
                    Convert.ToUInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Valor no válido, el " +
                    "programa no se ha guardado.");
            }
        }
    }

    static void Borrar(DatosPrograma[] programas, ref int cantidad)
    {
        int programaBorr = PedirNumeroPrograma();

        if ((programaBorr > cantidad) ||
            (programaBorr < 1))
        {
            Console.WriteLine("Número no válido.");
        }
        else
        {
            for (int i = programaBorr; i <= cantidad; i++)
            {
                programas[i - 1] = programas[i];
            }
            cantidad--;
        }
    }

    static void Main()
    {
        DatosPrograma[] programas = new DatosPrograma[1000];
        int cantidadDatos = 0;
        bool terminar = false;

        do
        {
            MostrarMenu();
            char menu = Convert.ToChar(PedirOpcion());

            switch (menu)
            {
                case '1': Anyadir(programas, ref cantidadDatos); break;
                case '2': MostrarTodos(programas, cantidadDatos); break;
                case '3': MostrarDetallePrograma(programas, cantidadDatos); break;
                case '4': Modificar(programas, cantidadDatos); break;
                case '5': Borrar(programas, ref cantidadDatos); break;
                case 'T': terminar = true; break;
                default: Console.WriteLine("Opción no válido."); break;
            }
            Console.WriteLine("");
        }
        while (!terminar);

        Console.WriteLine("Hasta luego!");
    }
}
