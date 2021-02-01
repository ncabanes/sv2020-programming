/* 
* Nueva versión del ejercicio 126 (clase Programa), partiendo de la 
* "solución oficial", en la que el cuerpo del programa muestre un menú que 
* permita al usuario: ver los datos de todos los programas (opción 1), buscar 
* los que contengan un cierto texto (opción 2), añadir un programa (opción 3) o 
* salir (opción 0). Los datos de programas deben guardarse en un array 
* sobredimensionado, con capacidad para 1000 datos.
* 
* Hugo (...)

*/

using System;

class Programa
{
    protected string nombre;
    protected string descripcion;
    protected byte mesLanzamiento;
    protected ushort anyoLanzamiento;

    public Programa(string nuevoNombre, string nuevaDescripcion,
        int nuevoMes, int nuevoAnyo)
    {
        nombre = nuevoNombre;
        descripcion = nuevaDescripcion;
        mesLanzamiento = (byte) nuevoMes;
        anyoLanzamiento = (ushort) nuevoAnyo;
    }


    public string GetNombre()
    {
        return nombre;
    }

    public string GetDescripcion()
    {
        return descripcion;
    }

    public int GetMesLanzamiento()
    {
        return mesLanzamiento;
    }

    public int GetanyoLanzamiento()
    {
        return anyoLanzamiento;
    }

    public void SetNombre(string nuevoNombre)
    {
        nombre = nuevoNombre;
    }

    public void SetDescripcion(string nuevaDescripcion)
    {
        descripcion = nuevaDescripcion;
    }

    public void SetMesLanzamiento(int nuevoMes)
    {
        mesLanzamiento = (byte)nuevoMes;
    }

    public void SetAnyoLanzamiento(int nuevoAnyo)
    {
        anyoLanzamiento = (ushort)nuevoAnyo;
    }


    public bool Contiene(string textoABuscar)
    {
        bool encontrado = false;

        if (nombre.ToUpper().Contains(textoABuscar.ToUpper()) || 
            (descripcion.ToUpper().Contains(textoABuscar.ToUpper())))
        {
            encontrado = true;
        }
        return encontrado;
    }


    public void Mostrar()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Descripción: " + descripcion);
        Console.WriteLine("Mes Lanzamiento: " + mesLanzamiento);
        Console.WriteLine("Año lanzamiento: " + anyoLanzamiento);
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
            for(int i = 0; i < cantidad; i++)
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
            
            for(int i = 0; i < cantidad; i++)
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
        GestorDeProgramas gest = new GestorDeProgramas();
        
        gest.Run();
    }
}
