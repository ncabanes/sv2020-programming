using System;
using System.IO;

/*188. Crea un programa "logger", que añadirá a un archivo de texto llamado
 * "log.txt" la fecha y hora actuales, en formato AAAA-MM-DD HH:MM:SS.mmm 
 * seguida por el texto introducido por el usuario como parámetros de la línea
 * de comandos. Porejemplo, si el ejecutable se llama "logger.exe" y el usuario
 * escribe "logger Esto es una prueba" en la línea de comandos, se debe añadir 
 * una línea como: 2021-04-20 17:20:02.023 - Esto es una prueba */

//Iván (...)

class Logger
{
    static void Main(string[] args)
    {
        DateTime fecha = DateTime.Now;

        if (args.Length > 0)
        {
            string texto = "";

            for (int i = 0; i < args.Length; i++)
            {
                texto += args[i] + " ";
            }

            texto = texto.TrimEnd();
            
            try
            {
                StreamWriter fichero = File.AppendText("log.txt");
                fichero.WriteLine(fecha.ToString("yyyy-MM-dd HH:mm:ss.fff") 
                    + " - " + texto);
                fichero.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return;
            }
        }
        else
        {
            Console.WriteLine("Faltan parámetros");
        }
    }
}
