//Iván (...)

/*171. Crea una nueva versión del gestor de programas V2 (en clases, ej.151), 
partiendo de la versión oficial, en la que no emplees un array sino una lista.*/

using System;
using System.Collections.Generic;

class Programa
{
    private string nombre;
    private string descripcion;
    private byte mesLanzamiento;
    private ushort anyoLanzamiento;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public byte MesLanzamiento
    {
        get { return mesLanzamiento; }
        set { mesLanzamiento = (byte)value; }
    }

    public ushort AnyoLanzamiento
    {
        get { return anyoLanzamiento; }
        set { anyoLanzamiento = (ushort)value; }
    }

    public Programa(string Nombre, string Descripcion,
        int MesLanzamiento, int AnyoLanzamiento)
    {
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.MesLanzamiento = (byte)MesLanzamiento;
        this.AnyoLanzamiento = (ushort)AnyoLanzamiento;
    }

    public Programa(string Nombre)
    {
        this.Nombre = Nombre;
        Descripcion = Nombre;
        MesLanzamiento = (byte)DateTime.Now.Month;
        AnyoLanzamiento = (ushort)DateTime.Now.Year;
    }

    public bool Contiene(string textoABuscar)
    {
        bool encontrado = false;

        if (Nombre.ToUpper().Contains(textoABuscar.ToUpper()) ||
            (descripcion.ToUpper().Contains(textoABuscar.ToUpper())))
        {
            encontrado = true;
        }
        return encontrado;
    }


    public void Mostrar()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Descripción: " + Descripcion);
        Console.WriteLine("Mes Lanzamiento: " + MesLanzamiento);
        Console.WriteLine("Año lanzamiento: " + AnyoLanzamiento);
    }
}

//-----------------------------------


class ProgramaComercial : Programa
{
    private float precio;

    public float Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public ProgramaComercial(string Nombre, string Descripcion,
        byte MesLanzamiento, ushort AnyoLanzamiento, float Precio)
        : base(Nombre, Descripcion, MesLanzamiento, AnyoLanzamiento)
    {
        this.Precio = Precio;
    }

    public ProgramaComercial(string Nombre, float Precio)
        : this(Nombre, "Comercial", (byte)DateTime.Now.Month,
              (ushort)DateTime.Now.Year, Precio)
    {
    }
}

//-----------------------------------

class GestorDeProgramas
{
    private void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Ver datos de todos los programas");
        Console.WriteLine("2. Buscar texto");
        Console.WriteLine("3. Añadir un programa");
        Console.WriteLine("0. Salir");
    }

    private static string Pedir(string aviso)
    {
        Console.Write(aviso + ": ");
        string respuesta = Console.ReadLine();

        return respuesta;
    }

    private void Anyadir(List<Programa> programas)
    {
        Console.Clear();

        string nombre = Pedir("Nombre");
        string descripcion = Pedir("Descripción");
        int mes = Convert.ToInt32(Pedir("Mes de lanzamiento"));
        int anyo = Convert.ToInt32(Pedir("Año de publicación"));

        programas.Add(new Programa(nombre, descripcion,
                mes, anyo));      // <-- Diferencia
    }

    private void VerTodos(List<Programa> programas)
    {
        Console.Clear();
        int cantidad = programas.Count;             // <-- Diferencia
        foreach (Programa program in programas)     // <-- Diferencia
        {
            program.Mostrar();
        }
        if (cantidad == 0)
        {
            Console.WriteLine("No hay ningún programa para mostrar");
        }
    }

    void BuscarTexto(List<Programa> programas)
    {
        int cantidad = programas.Count;     // <-- Diferencia
        Console.Clear();

        Console.WriteLine("Introduce el texto a buscar:");
        string textoABuscar = Console.ReadLine();

        for (int i = 0; i <= cantidad; i++)
        {
            if (programas[i].Contiene(textoABuscar))
            {
                programas[i].Mostrar();
                Console.WriteLine();
            }
        }
        if(cantidad == 0)
        {
            Console.WriteLine("No hay ningún programa para mostrar");
        }
    }

    public void Run()
    {
        string opcion;
        bool salir = false;
        List<Programa> programas = new List<Programa>();    // <-- Diferencia

        do
        {
            MostrarMenu();
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": VerTodos(programas); break;
                case "2": BuscarTexto(programas); break;
                case "3": Anyadir(programas); break;
                case "0": salir = true; break;
                default: Console.WriteLine("Opción incorrecta"); break;
            }

            if (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("Intro para continuar...");
                Console.ReadLine();
            }

        } while (!salir);

        Console.WriteLine("Hasta luego");
    }
}
//-----------------------------------

class PruebaPrograma
{
    static void Main()
    {
        GestorDeProgramas gestor = new GestorDeProgramas();
        gestor.Run();
    }
}
