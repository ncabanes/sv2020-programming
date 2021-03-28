/* Eduardo (...)
 * 
 * Crea un programa que permita copiar un archivo de origen a un archivo de 
 * destino. El nombre de ambos ficheros se tomará de la línea de comandos. 
 * Debes usar FileStream y un bloque con el tamaño de todo el archivo. Un 
 * ejemplo de uso podría ser:
 * 
 * micopiador fichero1.txt e:\fichero2.txt
 *
 * Debe comportarse correctamente si el archivo de origen no existe y debe 
 * avisar (pero no sobrescribirlo) si el archivo de destino existe.
 */

using System;
using System.IO;

class Ejercicio179
{
    static int Main(string[] args)
    {
        if(args.Length < 2)
        {
            Console.WriteLine("Error al introducir los parámetros.");
            Console.WriteLine("Primer parámetro: nombre del fichero");
            Console.WriteLine("Segundo parámetro: ruta y nombre del fichero " +
                "de destino");

            return 1;
        }

        if (File.Exists(args[1]))
        {
            Console.WriteLine("Ya existe un fichero con ese nombre en la " +
                "ruta de destino");
            return 2;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine("El fichero indicado para copiar no existe");
            return 2;
        }

        try
        {
            FileStream fichero = File.OpenRead(args[0]);
            byte[] datosOrigen = new byte[fichero.Length];
            int cantidadLeida = fichero.Read(datosOrigen, 0, 
                (int)fichero.Length); // Válido para ficheros de 2 GB o menos
            fichero.Close();

            if (cantidadLeida < fichero.Length)
            {
                Console.WriteLine("Error, el archivo no ha podido vocarse" +
                    "completamente");
            }
            else
            {
                fichero = File.Create(args[1]);
                fichero.Write(datosOrigen, 0, cantidadLeida);
                fichero.Close();
            }
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("La ruta del archivo es demasiado larga");
        }

        catch (IOException)
        {
            Console.WriteLine("Error de lectura / escritura");
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }

        return 0;
    }

}


