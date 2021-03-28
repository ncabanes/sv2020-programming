/* Eduardo (...)
 * 
 * Crea un programa que sea capaz de encriptar y desencriptar una imagen en 
 * formato BMP, intercambiando el orden de sus dos primeros bytes de modo que 
 * los visores de imágenes no la detecten como una imagen válida.
 */

using System;
using System.IO;

class ejercicio182
{
    static void Main()
    {
        string nombre;
        FileStream fichero;
        byte dato1, dato2;

        Console.WriteLine("¿Cuál va a ser el archivo BMP a encriptar/desencriptar?");
        nombre = Console.ReadLine();

        if (!File.Exists(nombre))
        {
            Console.WriteLine("El archivo no existe");
            return;
        }

        try
        {
            fichero = File.Open(nombre, FileMode.Open, FileAccess.ReadWrite);
            dato1 = (byte)fichero.ReadByte();
            dato2 = (byte)fichero.ReadByte();

            fichero.Seek(0, SeekOrigin.Begin);
            fichero.WriteByte(dato2);
            fichero.WriteByte(dato1);

            fichero.Close();

            if (dato1 == 'M')
                Console.WriteLine("Archivo desencriptado ;)");
            else
                Console.WriteLine("Archivo encriptado :P");
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("Ruta de archivo demasiado larga");
        }

        catch (IOException)
        {
            Console.WriteLine("Error de lectura/escritura");
        }

        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }
}
