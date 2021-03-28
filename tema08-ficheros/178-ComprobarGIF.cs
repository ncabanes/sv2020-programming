/*
 Carlos (...)
 
 Ejercicio 178. Crea un programa que pida el nombre de un fichero GIF y
 compruebe si realmente se trata de una imagen en ese formato. Debes
 hacerlo de dos formas distintas (que pueden ser parte de un mismo
 programa): con FileStream y con BinaryReader. Para conseguirlo,
 deberás leer byte a byte, y comprobar que los 4 primeros bytes
 corresponden a los caracteres G, I, F, 8. El quinto byte permite
 saber la versión concreta de fichero GIF del que se trata (GIF87 o
 GIF89), que deberás mostrar en pantalla.
*/

using System;
using System.IO;

class Ejercicio178
{
    static void Main()
    {
        string nombre;

        Console.Write("Introduzca el nombre del fichero: ");
        nombre = Console.ReadLine();

        //FileStream
        try
        {
            FileStream fichero1 = File.OpenRead(nombre);
            byte[] formato = new byte[5];
            fichero1.Read(formato, 0, 5);
            fichero1.Close();

            if (""+ (char) formato[0] + (char) formato[1] + 
                (char) formato[2] + (char) formato[3] == "GIF8")
            {
                Console.WriteLine("El fichero es un GIF y su versión es GIF8{0}.",
                    (char) formato[4]);
            }
            else
            {
                Console.WriteLine("El fichero no es un GIF.");
            }
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre demasiado largo!");
        }
        catch (IOException e)
        {
            Console.WriteLine("No se ha podido leer!");
            Console.WriteLine("El error exacto es: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error inesperado!");
            Console.WriteLine("El error exacto es: {0}", e.Message);
        }

        //BinaryReader
        try
        {
            BinaryReader fichero2 = new BinaryReader(
                File.Open(nombre, FileMode.Open));

            char[] formato = new char[5];

            for (int i = 0; i < 5; i++)
            {
                formato[i] = fichero2.ReadChar();
            }

            fichero2.Close();

            if ("" + formato[0] + formato[1] + formato[2] + formato[3] == "GIF8")
            {
                Console.WriteLine("El fichero es un GIF y su versión es GIF8{0}.",
                    formato[4]);

            }
            else
            {
                Console.WriteLine("El fichero no es un GIF.");
            }
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre demasiado largo!");
        }
        catch (IOException e)
        {
            Console.WriteLine("No se ha podido leer!");
            Console.WriteLine("El error exacto es: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error inesperado!");
            Console.WriteLine("El error exacto es: {0}", e.Message);
        }
    }
}

