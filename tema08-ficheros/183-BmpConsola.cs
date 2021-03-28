//Alejandro (...)
//1 DAM

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            byte[] datos = new byte[53];
            int inicioImagen, ancho, alto;
            char[,] imagen;
            byte bitLeido;
            if(File.Exists(args[0]))
            {
                BinaryReader fichero = new BinaryReader(
                    File.Open(args[0], FileMode.Open));
                for (int i = 0; i < datos.Length; i++)
                {
                    datos[i] = fichero.ReadByte();
                }
                inicioImagen = datos[10]+datos[11]*256+datos[12]*256*
                    256+datos[13]*256*256*256;
                ancho = datos[18]+datos[19]*256+datos[20]*256*256+
                    datos[21]*256*256*256;
                alto = datos[22]+datos[23]*256+datos[24]*256*256+
                    datos[25]*256*256*256;
                imagen = new char[alto, ancho];
                fichero.BaseStream.Seek(inicioImagen, SeekOrigin.Begin);
                Console.WriteLine(inicioImagen + " - " + ancho + " - "
                    + alto);
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    { 
                    bitLeido = fichero.ReadByte();
                        if (bitLeido > 127)
                        {
                            imagen[i, j] = '.';
                        }
                        else
                        {
                            imagen[i, j] = '*';
                        }
                    }
                }
                fichero.Close();
                for (int i = alto - 1; i > 0; i--)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        Console.Write(imagen[i,j]);
                    }
                    Console.WriteLine();
                }


            }
            else
            {
                Console.WriteLine("El archivo no existe");
            }
        }
        else
        {
            Console.WriteLine("Número de parámetros erroneo");
        }
    }
}
