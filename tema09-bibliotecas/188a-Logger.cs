using System;
using System.Collections.Generic;
using System.IO;

/*Carlos (...)
 
 188. Crea un programa "logger", que añadirá a un archivo de texto llamado 
"log.txt" la fecha y hora actuales, en formato AAAA-MM-DD HH:MM:SS.mmm seguida 
por el texto introducido por el usuario como parámetros de la línea de comandos.
Por ejemplo, si el ejecutable se llama "logger.exe" y el usuario escribe "logger
Esto es una prueba" en la línea de comandos, se debe añadir una línea como:

2021-04-20 17:20:02.023 - Esto es una prueba
*/
class Logger
{
    static int Main(string[] args)
    {
        if (args.Length >= 1)
        {
            StreamWriter fichero;
            string input = "";

            for (int i = 0; i < args.Length; i++)
            {
                input = input + " " + args[i];
            }

            DateTime ahora = DateTime.Now;
            string linea = ahora.Year + "-" + ahora.Month.ToString("00") + "-" 
                + ahora.Day.ToString("00") + " " + ahora.ToString("T") + "." 
                + ahora.Millisecond + " -" + input;

            fichero = File.AppendText("log.txt");
            fichero.WriteLine(linea);

            fichero.Close();

            return 0;
        }
        else
        {
            Console.WriteLine("Por favor, indica en línea de comandos "+
                "el texto a guardar en el log");
            return 1;
        }
    }
}
