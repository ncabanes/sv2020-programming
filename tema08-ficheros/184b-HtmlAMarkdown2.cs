// Valentina (...)

using System;
using System.Collections.Generic;
using System.IO;

namespace Ejercicio1_tema8_semana3
{
    class Ejercicio1
    {
        static void Main(string[] args)
        {
            string nombreFichero;

            if (args.Length < 1)
            {
                Console.WriteLine("Escribe el nombre del archivo a convertir");
                nombreFichero = Console.ReadLine();
            }
            else
            {
                nombreFichero = args[0];
            }

            try
            {
                if (File.Exists(nombreFichero))
                {
                    CrearTxt(nombreFichero);
                }
                else
                {
                    Console.WriteLine("Fichero no encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!: {0}", e.Message);
            }
        }

        private static void CrearTxt(string nombre)
        {            
            StreamReader fichero;            
            List<string> contenidoFichero = new List<string>();
            List<string> contenidoTxt = new List<string>();
            string linea;
            string nombreTxt = GetNombreTxt(nombre);
            bool parrafo = false;

            try
            {
                fichero = File.OpenText(nombre);                

                do
                {
                    linea = fichero.ReadLine();

                    if (linea != null)
                        contenidoFichero.Add(linea);

                } while (linea != null);
                fichero.Close();
                linea = "";

                foreach (string dato in contenidoFichero)
                {
                    List<int> indexes = AllIndexesOf(dato,'<');
                    List<int> indexes2 = AllIndexesOf(dato, '>');
                 

                    string contenido1 = dato.Substring(0, indexes[0]);

                    if (parrafo)
                        linea += EliminarEspacios(contenido1);

                    for (int i = 0; i < indexes.Count; i++)
                    {
                        string etiqueta = dato.Substring(indexes[i] + 1, 
                            indexes2[i] - indexes[i] - 1);

                        if (etiqueta == "h1")
                        {
                            string contenido = dato.Substring(indexes2[i] + 1, 
                                Longitud(dato, indexes, indexes2, i));                            
                            linea = "# " + contenido;
                            contenidoTxt.Add(linea);
                            contenidoTxt.Add("");
                        }
                        else if (etiqueta == "li")
                        {
                            string contenido = dato.Substring(indexes2[i] + 1, 
                                Longitud(dato, indexes, indexes2, i));                            
                            linea = "* " + contenido;
                            contenidoTxt.Add(linea);
                        }
                        else if (etiqueta == "p")
                        {
                            parrafo = true;                           

                            string contenido = dato.Substring(indexes2[i] + 1, 
                                Longitud(dato, indexes, indexes2, i));
                            linea = contenido;
                        }
                        else if (parrafo && etiqueta != "/p")
                        {             
                            string contenido = dato.Substring(indexes2[i] + 1, 
                                Longitud(dato, indexes, indexes2, i));
                            linea += contenido;
                           
                        }
                        else if (etiqueta == "/p")
                        {
                            parrafo = false;
                            List<string> lista = PartirParrafo(linea);

                            foreach(string elemento in lista)
                                contenidoTxt.Add(elemento);

                            contenidoTxt.Add("");
                        }
                    }
                }

                AgregarFichero(contenidoTxt, nombreTxt);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Nombre demasiado largo!");
            }
            
        }

        private static int Longitud(string dato, List<int> indexes, 
            List<int> indexes2, int i)
        {
            int longitud = dato.Length - 1 - indexes2[i];

            if (i + 1 < indexes.Count)
                longitud = indexes[i + 1] - indexes2[i] - 1;

            return longitud;
        }

        private static string GetNombreTxt(string nombre)
        {
            string[] arrayNombre = nombre.Split('.');
            string nombreTxt = arrayNombre[0] + ".txt";
            return nombreTxt;
        }

        private static List<int> AllIndexesOf(string str, char value)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == value)
                    indexes.Add(i);
            }

            return indexes;
        }

        private static string EliminarEspacios(string texto)
        {
            while (texto.Contains("  "))
            {
                texto = texto.Replace("  ", " ");
            }

            return texto;
        }

        private static List<string> PartirParrafo(string texto)
        {
            List<string> parrafo = new List<string>();
            int contador = 0;
            int inicio = 0;
            bool vacio = true;

            foreach (char caracter in texto)
            {
                contador++;

                if (contador % 72 == 0)
                {
                    parrafo.Add(texto.Substring(inicio, 72));
                    inicio = contador;
                    vacio = false;
                }
            }
            if (vacio)
                parrafo.Add(texto);

            return parrafo;

        }  
        
        private static void AgregarFichero(List<string> lista, string nombreTxt)
        {
            try
            {
                StreamWriter ficheroTxt;
                ficheroTxt = File.CreateText(nombreTxt);

                foreach (string data in lista)
                {
                    ficheroTxt.WriteLine(data);
                }

                ficheroTxt.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("No se ha podido escribir!");
                Console.WriteLine("El error exacto es: {0}", e.Message);
            }

        }
    }
}
