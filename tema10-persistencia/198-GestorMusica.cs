/* 198. Debes crear una aplicación que permita llevar el control de una 
colección de música en formato MP3. De cada canción o similar (que será un 
objeto de la clase "Musica") querremos anotar el titulo (por ejemplo, "The 
bell"), el intérprete ("Mike Oldfield"), el nombre del fichero ("thebell.mp3"), 
la ubicación ("MikeOldfield/tubularBells"), el tamaño del fichero (en MB, quizá 
con decimales, como en "3,070"). Otros detalles que podrían ser interesantes, 
como la categoría, el álbum al que pertenece o la valoración personal, hemos 
decidido aplazarlos para una versión posterior 2.0.  Tu aplicación debe mostrar 
un menú que permita:  1. Añadir un nueva canción (al final de los datos 
existentes).  2. Mostrar las canciones que contengan un cierto texto en el 
título o en el autor.  3. Modificar los datos de una canción a partir de su 
posición (la canción número 1 sería la primera de la lista).  4. Eliminar la 
canción que se encuentra en cierta posición.  5. Ordenar alfabéticamente por 
título.  6. Ordenar alfabéticamente por autor.  7. Salir  Debe cargar datos al 
comenzar y guardar datos al terminar, empleando serialización con un 
formateador binario.  
*
* Hugo (...)
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class PruebaMusica
{
    static void Main()
    {
        GestorMusica g = new GestorMusica();
        g.Run();
    }
}

// -----------------------------



class GestorMusica
{
    List<Musica> listaMusica;
    const string NOMBRE_FICHERO = "musica.dat";

    public GestorMusica()
    {
        listaMusica = Cargar();
    }
    public void Run()
    {
        string opcion;
        bool salir = false;

        do
        {
            MostrarMenu();
            opcion = Pedir("Opción");

            switch (opcion)
            {
                case "1": Anyadir(listaMusica); break;
                case "2": Buscar(listaMusica); break;
                case "3": ModificarCancion(listaMusica); break;
                case "4": EliminarCancion(listaMusica); break;
                case "5": OrdenarPorTitulo(listaMusica); break;
                case "6": OrdenarPorAutor(listaMusica); break;
                case "7": salir = true; break;
                default: Console.WriteLine("Opción incorrecta"); break;
            }
        }
        while (!salir);
    }

    private void MostrarMenu()
    {
        Console.WriteLine("1. Añadir nueva canción.");
        Console.WriteLine("2. Buscar canción por título o autor.");
        Console.WriteLine("3. Modificar canción por posición");
        Console.WriteLine("4. Eliminar canción por posición");
        Console.WriteLine("5. Ordenar alfabéticamente por título.");
        Console.WriteLine("6. Ordenar alfabéticamente por autor");
        Console.WriteLine("7. Salir");
    }

    private void Anyadir(List<Musica> listaMusica)
    {
        Musica m;
        string titulo = Pedir("Título");
        string interprete = Pedir("Intérprete");
        string nombreFichero = Pedir("Nombre fichero");
        string ubicacion = Pedir("Ubicación");
        float tamanyo = Convert.ToSingle(Pedir("Tamaño en MB"));

        m = new Musica(titulo, interprete, nombreFichero, ubicacion, tamanyo);

        listaMusica.Add(m);
        Guardar(listaMusica);
    }

    private void Buscar(List<Musica> listaMusica)
    {
        string textoABuscar = Pedir("Texto a buscar");

        foreach (Musica m in listaMusica)
        {
            if (m.Titulo.ToUpper().Contains(textoABuscar.ToUpper()) ||
                m.Interprete.ToUpper().Contains(textoABuscar.ToUpper()))
            {
                Console.WriteLine(m);
            }
        }
    }

    private void ModificarCancion(List<Musica> listaMusica)
    {
        int posicion = Convert.ToInt32(Pedir("Posición a modificar")) - 1;

        Musica m = listaMusica[posicion];
        m.Titulo = PedirYModificar("Titulo",
            listaMusica[posicion].Titulo);
        m.Interprete = PedirYModificar("Intérprete",
            listaMusica[posicion].Interprete);
        m.NombreFichero = PedirYModificar("Nombre fichero",
            listaMusica[posicion].NombreFichero);
        m.Ubicacion = PedirYModificar("Ubicación",
            listaMusica[posicion].Ubicacion);
        m.Tamanyo = Convert.ToSingle(PedirYModificar("Tamaño",
            listaMusica[posicion].Tamanyo.ToString()));

        listaMusica[posicion] = m;
        Guardar(listaMusica);
    }

    

    private void EliminarCancion(List<Musica> listaMusica)
    {
        int posicion = Convert.ToInt32(Pedir("Posición a modificar")) - 1;

        Console.WriteLine(listaMusica[posicion]);

        Console.WriteLine("Pulsa S para confirmar eliminación u otra tecla para salir");
        if (Console.ReadLine() == "S")
        {
            Console.WriteLine("Canción eliminada!");
            listaMusica.RemoveAt(posicion);
            Guardar(listaMusica);
        }
        else
        {
            Console.WriteLine("Eliminación cancelada!");
        }
    }

    private void OrdenarPorTitulo(List<Musica> listaMusica)
    {
        listaMusica.Sort();
        foreach (Musica m in listaMusica)
        {
            Console.WriteLine(m);
        }

        Guardar(listaMusica);
    }

    private void OrdenarPorAutor(List<Musica> listaMusica)
    {
        Musica aux;

        for (int i = 0; i < listaMusica.Count - 1; i++)
        {
            for (int j = i + 1; j < listaMusica.Count; j++)
            {
                if (listaMusica[i].CompareTo(listaMusica[j]) > 0)
                {
                    aux = listaMusica[i];
                    listaMusica[i] = listaMusica[j];
                    listaMusica[j] = aux;
                }
            }  
        }

        foreach (Musica m in listaMusica)
        {
            Console.WriteLine(m);
        }

        Guardar(listaMusica);
    }

    private string Pedir(string aviso)
    {
        Console.WriteLine(aviso + ":");
        string respuesta = Console.ReadLine();
        return respuesta;
    }

    private string PedirYModificar(string aviso, string valorAnterior)
    {
        Console.WriteLine(aviso + " actual: " + valorAnterior);
        Console.Write("Nuevo " + aviso + ": ");
        string respuesta = Console.ReadLine();

        if (respuesta == "")
            respuesta = valorAnterior;

        return respuesta;
    }

    public void Guardar(List<Musica> listaMusica)
    {
        try
        {
            IFormatter formateador = new BinaryFormatter();
            FileStream fichero = new FileStream(NOMBRE_FICHERO, FileMode.Create,
                FileAccess.Write, FileShare.None);
            formateador.Serialize(fichero, listaMusica);
            fichero.Close();
        }
        catch (IOException)
        {
            Console.WriteLine("Error de escritura");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
        }      
    }

    public List<Musica> Cargar()
    {
        List<Musica> listaMusica = new List<Musica>();

        if (File.Exists(NOMBRE_FICHERO))
        {
            try
            {
                IFormatter formateador = new BinaryFormatter();
                FileStream fichero = new FileStream(NOMBRE_FICHERO, FileMode.Open,
                    FileAccess.Read, FileShare.Read);
                listaMusica = (List<Musica>)formateador.Deserialize(fichero);
                fichero.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Error de lectura");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        return listaMusica;
    }
}

// -----------------------------

[Serializable]
class Musica: IComparable<Musica>
{
    public string Titulo { get; set; }
    public string Interprete { get; set; }
    public string NombreFichero { get; set; }
    public string Ubicacion { get; set; }
    public float Tamanyo { get; set; }

    public Musica(string titulo, string interprete, string nombreFichero,
        string ubicacion, float tamanyo)
    {
        Titulo = titulo;
        Interprete = interprete;
        NombreFichero = nombreFichero;
        Ubicacion = ubicacion;
        Tamanyo = tamanyo;
    }

    public int CompareTo(Musica otra)
    {
        return Titulo.ToUpper().CompareTo(otra.Titulo.ToUpper());
    }

    public override string ToString()
    {
        return "Título: " + Titulo + " - Intérprete: " + Interprete + " - Fichero: "
            + NombreFichero + " - Ubicación: " + Ubicacion + " - Tamaño: " + Tamanyo + "MB";
    }
}
