// Alberto (...)

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Serialization;

// -------------------------

class Program
{
    static void Main(string[] args)
    {
        System.Console.OutputEncoding = Encoding.UTF8;
        GestorArticulos g = new GestorArticulos();
        g.Run();
    }
}

// -------------------------

class GestorArticulos
{
    List<Articulo> articulos = new List<Articulo>();
    private void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("---- Menu ----");
        Console.WriteLine("1. Añadir artículo");
        Console.WriteLine("2. Mostrar artículo");
        Console.WriteLine("3. Modificar artículo");
        Console.WriteLine("4. Eliminar artículo");
        Console.WriteLine("5. Rastreador de precios");
        Console.WriteLine("0. Salir");
    }

    private static string SolicitarDatos(string aviso)
    {
        Console.Write(aviso + ": ");
        string entrada = Console.ReadLine();

        return entrada;
    }

    private void MostrarTodos(List<Articulo> articulos)
    {
        for (int i = 0; i < articulos.Count; i++)
        {
            Console.WriteLine("{0}. " + articulos[i], i + 1);
        }
    }

    private void Anyadir(List<Articulo> articulos)
    {
        Console.Clear();
        string descripcion;
        float precio;
        string url; 
        descripcion = SolicitarDatos("Inserte descripción");
        precio = Convert.ToSingle(SolicitarDatos("Inserte precio actual"));       
        url = SolicitarDatos("Inserte URL");

        articulos.Add(new Articulo(descripcion, precio, url));
        articulos.Sort();
        Guardar(articulos);
    }

    private void MostrarArticulo(List<Articulo> articulos)
    {
        Console.Clear();
        string descripABuscar;

        do
        {
            descripABuscar = SolicitarDatos("Inserte descripción o parte de esta " +
                "del artículo a buscar");         
        } while (descripABuscar == "");        

        for (int i = 0; i < articulos.Count; i++)
        {
            if (articulos.Count > 0)
            {
                if (articulos[i].Contiene(descripABuscar))
                {
                    Console.WriteLine("Articulo encontrado");
                    Console.WriteLine("{0}. " + articulos[i], i+1);
                }
            }
        }
    }

    private void Modificar(List<Articulo> articulos)
    {
        Console.Clear();
        MostrarTodos(articulos);
        int posicion;

        posicion = Convert.ToInt32(SolicitarDatos("Inserte la posición del artículo")) - 1;
        Articulo auxArt;
        string descripcionAux;
        string precioAux;
        string urlAux;
        
        if (posicion < articulos.Count && posicion >= 0)
        {
            auxArt = articulos[posicion];
            Console.WriteLine("Descripción actual: {0}", auxArt.Descripcion);
            descripcionAux = SolicitarDatos("Inserte nueva descripción");
            auxArt.Descripcion = descripcionAux;

            Console.WriteLine("Precio actual: {0}", auxArt.PrecioActual);
            precioAux = SolicitarDatos("Inserte nuevo precio");
            auxArt.PrecioActual = Convert.ToSingle(precioAux);

            Console.WriteLine("URL actual: {0}", auxArt.Url);
            urlAux = SolicitarDatos("Inserte nueva URL");
            auxArt.Url = urlAux;

            Console.WriteLine(auxArt);
            articulos[posicion] = auxArt;
        }

        else
        {
            Console.WriteLine("Posición no encontrada.");
        }
        Guardar(articulos);
    }

    private void EliminarArticulo(List<Articulo> articulos)
    {
        Console.Clear();
        int posicion;

        MostrarTodos(articulos);
        posicion = Convert.ToInt32(SolicitarDatos("Inserte posición del artículo a borrar"))-1;

        if(posicion < articulos.Count && posicion >= 0)
        {
            Console.WriteLine("Borrando el artículo {0} " + articulos[posicion].Descripcion, posicion + 1);
            articulos.RemoveAt(posicion);

            for (int j = 0; j < 10; j++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine("Artículo borrado con éxito");
        }

        else
        {
            Console.WriteLine("Articulo no encontrado");
        }
        Guardar(articulos);
    }

    private static List<Articulo> Cargar()
    {
        List<Articulo> articulos = new List<Articulo>();

        if (!File.Exists("articulos.dat"))
        {
            return articulos;
        }

        try
        {
            XmlSerializer formatter = new XmlSerializer(articulos.GetType());
            FileStream stream = new FileStream("articulos.dat",
                FileMode.Open, FileAccess.Read, FileShare.Read);
            articulos = (List<Articulo>)formatter.Deserialize(stream);
            stream.Close();
            return articulos;
        }
        catch (IOException)
        {
            Console.WriteLine("Error de lectura");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        return articulos;
    }

    private static void Guardar(List<Articulo> articulos)
    {
        try
        {
            XmlSerializer formatter = new XmlSerializer(articulos.GetType());
            FileStream stream = new FileStream("articulos.dat",
                FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, articulos);
            stream.Close();
        }
        catch (IOException)
        {
            Console.WriteLine("Error de escritura");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    private void RastrearPrecio(List<Articulo> articulos)
    {
        {
            WebClient cliente = new WebClient();
            string linea = null;
            float precio = 0;
            int posInicialPrecio, posFinalPrecio , longitudPrecio;
            
            Console.Clear();
            Console.WriteLine("Rastreando precios...");

            for (int i = 0; i < articulos.Count; i++)
            {
                precio = -1;
                Stream conexion =
                    cliente.OpenRead(articulos[i].Url);
                StreamReader lector = new StreamReader(conexion);

                linea = lector.ReadLine();

                while (linea != null)
                {
                    linea = lector.ReadLine();
                    if (linea != null)
                    {
                        if(linea.Contains("BuyingPriceString\">"))
                        {
                            posInicialPrecio = linea.IndexOf(">")+1;
                            posFinalPrecio = linea.IndexOf("€")-2;
                            longitudPrecio = posFinalPrecio - posInicialPrecio;
                            precio = Convert.ToSingle(linea.Substring(posInicialPrecio, longitudPrecio));
                        }
                    }
                }

                if (precio != articulos[i].PrecioActual)
                {
                    if (precio == -1)
                    {
                        Console.Write(articulos[i] + " - No disponible ");
                    }
                    else if (precio > articulos[i].PrecioActual)
                    {
                        Console.Write(articulos[i] + " - Precio en tiempo real ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(precio + "€");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.Write(articulos[i] + " - Precio en tiempo real ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(precio + "€");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.Write(articulos[i] + " - Precio en tiempo real ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(precio + "€");
                    Console.ResetColor();
                    Console.WriteLine("El precio no ha variado.");
                }                
                lector.Close();
            }
        }
    }

    public void Run()
    {
        string opcion;
        bool salir = false;
        
        List<Articulo> articulos = Cargar();

        do
        {
            MostrarMenu();
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": Anyadir(articulos); break;
                case "2": MostrarArticulo(articulos); break;
                case "3": Modificar(articulos); break;
                case "4": EliminarArticulo(articulos); break;
                case "5": RastrearPrecio(articulos); break;
                case "0": Guardar(articulos); salir = true; break;
                default: Console.WriteLine("Opción incorrecta"); break;
            }

            if (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("Intro para continuar...");
                Console.ReadLine();
            }

        } while (!salir);

        Console.WriteLine("Gracias por usar ARSoftware");
    }
}

// -------------------------



[Serializable]
public class Articulo :IComparable<Articulo>
{
    public string Descripcion { get; set; }

    public float PrecioActual { get; set; }

    public string Url { get; set; }

    public Articulo()
    {
    }

    public Articulo(string Descripcion, float PrecioActual, string Url)
    {
        this.Descripcion = Descripcion;
        this.PrecioActual = PrecioActual;
        this.Url = Url;
    }

    public bool Contiene(string descripABuscar)
    {
        bool encontrado = false;

        if (Descripcion.ToUpper().Contains(descripABuscar.ToUpper()))
        {
            encontrado = true;
        }
        return encontrado;
    }

    public override string ToString()
    {
        return Descripcion + ", precio - " + PrecioActual + "€";
    }
    
    public int CompareTo(Articulo otro)
    {
        return Descripcion.CompareTo(otro.Descripcion);
    }
}
