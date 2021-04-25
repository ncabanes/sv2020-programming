using System;
using System.IO;
using System.Net;

/*Carlos(...)
 
 195. Descarga la versión HTML del libro "Learn Ruby the Hard Way" 
(al menos los 52 ejercicios), desde

https://learnrubythehardway.org/book/ */
class DescargaLibro
{
    static void Main()
    {
        WebClient cliente = new WebClient();
        StreamWriter salida = File.AppendText("Learn Ruby the Hard Way.html");
        string linea = null;

        for (int i = 0; i < 52; i++)
        {
            Stream conexion = 
                cliente.OpenRead("https://learnrubythehardway.org/book/ex" 
                + i + ".html");
            StreamReader lector = new StreamReader(conexion);

            linea = lector.ReadLine();

            while (linea != null)
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    salida.WriteLine(linea);
                }
            }

            lector.Close();
        }

        salida.Close();
    }
}

