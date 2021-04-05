//Patrick (...)

using System;
using System.Collections.Generic;
using System.IO;

class HtmlAMarkdown
{
    static int Main(string[] args)
    {
        string nombreArchivo;

        if (args.Length < 1)
        {
            Console.WriteLine("Escribe el nombre del archivo a convertir");
            nombreArchivo = Console.ReadLine();
        }
        else
        {
            nombreArchivo = args[0];
        }


        if (File.Exists(nombreArchivo))
        {
            try
            {
                string[] ficheroHtml = File.ReadAllLines(nombreArchivo);

                List<string> ficheroMarkDown = new List<string>();

                int contador = ficheroHtml.Length;

                for (int i = 0; i < contador; i++)
                {
                    string temporal = ficheroHtml[i];                   

                    if (!(temporal.Contains("<!DOCTYPE html>")||temporal.Contains("<body>") || 
                        temporal.Contains("<html>") || temporal.Contains("</html>") || 
                        temporal.Contains("</body>")))
                    {
                        temporal = temporal.Replace("</h1>", 
                            Environment.NewLine + Environment.NewLine);
                        temporal = temporal.Replace("<h1>", "# ");
                        temporal = temporal.Replace("<p>", "");
                        temporal = temporal.Replace("</p>", 
                            Environment.NewLine + Environment.NewLine);
                        temporal = temporal.Replace("<b>", "");
                        temporal = temporal.Replace("</b>", "");
                        temporal = temporal.Replace("<ul>", "");
                        temporal = temporal.Replace("</ul>", "");
                        temporal = temporal.Replace("<li>", "* ");
                        temporal = temporal.Replace("</li>", "");

                        temporal = temporal.Trim();
                        ficheroMarkDown.Add(temporal);
                    }
                }
                nombreArchivo = nombreArchivo.ToLower().Replace(".html", ".txt");
                nombreArchivo = nombreArchivo.ToLower().Replace(".htm", ".txt");
                File.WriteAllLines(nombreArchivo, ficheroMarkDown);
                Console.WriteLine("Se ha completado con exito");
                return 0;

            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encuentra el archivo");
                return 1;
            }
            catch(IOException)
            {
                Console.WriteLine("Error de escritura");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
                return 1;
            }
        }
        else
        {
            Console.WriteLine("El fichero no existe");
            return 1;
        }
    }
}
