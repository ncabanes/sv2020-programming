/*151. Crea una nueva versión del gestor de programas (ejercicio 133), partiendo 
de la solución oficial, con los siguientes cambios:

- Debe haber un constructor alternativo para Programa que reciba sólo el nombre,
y que dará a la descripción el mismo valor que al nombre y tomará el mes y el
año de la fecha actual (deberás investigar cómo obtenerlos a partir de
DateTime.Now).

- Emplea propiedades en formato largo, en vez de getters y setters convencionales.

- Crea una clase ProgramaComercial, que herede de programa y añada un campo
adicional, el precio. Deberá tener un constructor con todos los campos, que se
apoye en el de Programa, y otro sólo con el nombre y el precio, que se apoyará
en el otro constructor de la misma clase ProgramaComercial. Esta clase no se
utilizará todavía en el gestor de programas.*/

// Iván (...)

using System;

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


class ProgramaComercial: Programa
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
        : this (Nombre, "Comercial", (byte)DateTime.Now.Month, 
              (ushort)DateTime.Now.Year, Precio)
    {
    }
}

//-----------------------------------

class GestorDeProgramas
{
    const int CAPACIDAD = 1000;
    string opcion;
    bool salir = false;
    int cantidad = 0, mes, anyo;
    string textoABuscar, nombre, descripcion;

    Programa[] programas = new Programa[CAPACIDAD];

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

    private void Anyadir()
    {
        Console.Clear();

        if (cantidad < CAPACIDAD)
        {
            nombre = Pedir("Nombre");
            descripcion = Pedir("Descripción");
            mes = Convert.ToInt32(Pedir("Mes de lanzamiento"));
            anyo = Convert.ToInt32(Pedir("Año de publicación"));

            programas[cantidad] = new Programa(nombre, descripcion,
                mes, anyo);

            cantidad++;
        }
        else
        {
            Console.WriteLine("Memoria llena. No caben más programas");
        }
    }

    private void VerTodos()
    {
        Console.Clear();

        if (cantidad > 0)
        {
            for (int i = 0; i < cantidad; i++)
            {
                programas[i].Mostrar();
                Console.WriteLine();
            }
        }
        else
            Console.WriteLine("No hay ningún programa para mostrar");
    }

    void BuscarTexto()
    {
        Console.Clear();

        if (cantidad > 0)
        {
            Console.WriteLine("Introduce el texto a buscar:");
            textoABuscar = Console.ReadLine();

            for (int i = 0; i < cantidad; i++)
            {
                if (programas[i].Contiene(textoABuscar))
                {
                    programas[i].Mostrar();
                    Console.WriteLine();
                }
            }
        }
        else
            Console.WriteLine("No hay ningún programa para mostrar");

    }

    public void Run()
    {
        do
        {
            MostrarMenu();
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": VerTodos(); break;
                case "2": BuscarTexto(); break;
                case "3": Anyadir(); break;
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
