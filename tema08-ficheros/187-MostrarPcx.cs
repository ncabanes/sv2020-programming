/* Extraer información y Mostrar imagen en formato PCX
 * 
 * Hugo (...)
 */

using System;
using System.IO;

class MostrarPCX
{
    static void Main(string[] args)
    {
        string nombre;
        
        if (args.Length == 1)
        {
            nombre = args[0];
        }
        else
        {
            Console.WriteLine("Uso: nombre_fichero");
            return;
        }
        
        if (!File.Exists(nombre))
        {
            Console.WriteLine("El fichero no existe");
            return;
        }
        
        try
        {
            BinaryReader fichero = new BinaryReader(File.Open(nombre, FileMode.Open));

            byte dato1 = fichero.ReadByte();
            if (dato1 != 10)
            {
                Console.WriteLine("El archivo no es un PCX");
                return;
            }
            
            fichero.ReadByte();
            byte compresion = fichero.ReadByte();
            if (compresion == 1)
                Console.WriteLine("La imagen está comprimida");
            else if (compresion == 0)
                Console.WriteLine("La imagen está sin comprimir");

            byte dato3 = fichero.ReadByte();
            if (dato3 == 8)
                Console.WriteLine("Bits por píxel: " + dato3);
            else
            {
                Console.WriteLine("Error en los colores de la imagen");
                Console.WriteLine("Bits por píxel: " + dato3);
                return;
            }

            ushort xMin = fichero.ReadUInt16();
            ushort yMin = fichero.ReadUInt16();
            ushort xMax = fichero.ReadUInt16();
            ushort yMax = fichero.ReadUInt16();

            int ancho = xMax - xMin + 1;
            int alto = yMax - yMin + 1;

            Console.WriteLine("Ancho: " + ancho);
            Console.WriteLine("Alto: " + alto);

            fichero.BaseStream.Seek(66, SeekOrigin.Begin);
            byte tamanyoLinea = fichero.ReadByte();

            if (tamanyoLinea != ancho)
            {
                Console.WriteLine("Ancho de la imagen no coincide con el nº de bytes");
                return;
            }

            fichero.BaseStream.Seek(128, SeekOrigin.Begin);
            string cadenaPixel = "";
            while (fichero.BaseStream.Position < fichero.BaseStream.Length - 1)
            {
                byte pixel = fichero.ReadByte();
                
                if (pixel < 192)
                {
                    cadenaPixel += CaracterAMostrar(pixel);
                }
                else
                {
                    int vecesARepetir = pixel - 192;
                    pixel = fichero.ReadByte();
                    
                    for (int i = 0; i < vecesARepetir; i++)
                    {
                        cadenaPixel += CaracterAMostrar(pixel);
                    }
                }
            }
            fichero.Close();
        
            int posicion = 0;
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    Console.Write(cadenaPixel[posicion]);
                    posicion++;
                }
                Console.WriteLine();
            }
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre o ruta de archivo demasiado larga");
        }
        catch (IOException)
        {
            Console.WriteLine("Error de lectura");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    static char CaracterAMostrar(byte pixel)
    {
        char caracter;

        if (pixel < 49)
            caracter = '#';
        else if (pixel < 100)
            caracter = '=';
        else if (pixel < 150)
            caracter = '-';
        else if (pixel < 200)
            caracter = '.';
        else
            caracter = ' ';

        return caracter;
    }
}
