//Iván (...)
/*164. Crea una nueva versión del gestor de programas dividido en funciones 
(ej.102), partiendo de la versión oficial, en la que no emplees un array sino 
una lista.*/

using System;
using System.Collections.Generic;

class GestorDeProgramasLista
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
        Console.WriteLine("3. Ver todos los datos de un cierto programa.");
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

    static void Anyadir(List<DatosPrograma> lista)
    {
        DatosPrograma programa;
        try
        {
            Console.Write("Introduce el nombre: ");
            programa.nombre =
                Console.ReadLine();

            Console.Write("Introduce la descipción: ");
            programa.descripcion =
                Console.ReadLine();

            Console.Write("Introduce el mes de lanzamiento: ");
            programa.version.mes =
                Convert.ToByte(Console.ReadLine());

            Console.Write("Introduce el año de lanzamiento: ");
            programa.version.anyo =
                Convert.ToUInt16(Console.ReadLine());

            lista.Add(programa);
        }
        catch (Exception)
        {
            Console.WriteLine("Valor no válido, el programa " +
                "no se ha guardado.");
        }
    }

    static void MostrarTodos(List<DatosPrograma> lista)
    {
        if (lista.Count < 1)
        {
            Console.WriteLine("No hay datos.");
        }
        else
        {
            int filaActual = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + lista[i].nombre);
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

    static void MostrarDetallePrograma(List<DatosPrograma> lista)
    {
        int programaVer = PedirNumeroPrograma();

        if ((programaVer > lista.Count) || (programaVer < 1))
        {
            Console.WriteLine("Número no válido.");
        }
        else
        {
            Console.WriteLine(programaVer +
                ". {0} {1} V.{2}.{3}",
                lista[programaVer - 1].nombre,
                lista[programaVer - 1].descripcion,
                lista[programaVer - 1].version.mes,
                lista[programaVer - 1].version.anyo);
        }
    }

    static void Modificar(List<DatosPrograma> lista)
    {
        int programaModif = PedirNumeroPrograma();

        if ((programaModif > lista.Count) ||
            (programaModif < 1))
        {
            Console.WriteLine("Número no válido.");
        }
        else
        {
            try
            {
                Console.Write("Introduce el nombre: ");
                string nuevoNombre = lista[programaModif - 1].nombre;
                nuevoNombre = Console.ReadLine();

                Console.Write("Introduce la descipción: ");
                string nuevaDescripcion = lista[programaModif - 1].descripcion;
                nuevaDescripcion = Console.ReadLine();

                Console.Write("Introduce el mes de lanzamiento: ");
                byte nuevoMes = lista[programaModif - 1].version.mes;
                nuevoMes = Convert.ToByte(Console.ReadLine());

                Console.Write("Introduce el año de lanzamiento: ");
                ushort nuevoAnyo = lista[programaModif - 1].version.anyo;
                nuevoAnyo = Convert.ToUInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Valor no válido, el " +
                    "programa no se ha guardado.");
            }
        }
    }

    static void Borrar(List<DatosPrograma> lista)
    {
        int programaBorr = PedirNumeroPrograma();

        if ((programaBorr > lista.Count) ||
            (programaBorr < 1))
        {
            Console.WriteLine("Número no válido.");
        }
        else
        {
            lista.RemoveAt(programaBorr - 1);
        }
    }

    static void Main()
    {
        List<DatosPrograma> lista = new List<DatosPrograma>();
        bool terminar = false;

        do
        {
            MostrarMenu();
            char menu = Convert.ToChar(PedirOpcion());

            switch (menu)
            {
                case '1': Anyadir(lista); break;
                case '2': MostrarTodos(lista); break;
                case '3': MostrarDetallePrograma(lista); break;
                case '4': Modificar(lista); break;
                case '5': Borrar(lista); break;
                case 'T': terminar = true; break;
                default: Console.WriteLine("Opción no válido."); break;
            }
            Console.WriteLine("");
        }
        while (!terminar);

        Console.WriteLine("Hasta luego!");
    }
}
