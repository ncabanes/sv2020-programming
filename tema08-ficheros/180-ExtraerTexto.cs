/* 180. Crea un programa que extraiga los caracteres imprimibles (código ASCII 
32 a 127, además del 7, el 10 y el 13) de un fichero y los vuelque a otro 
fichero. El nombre del fichero de origen se tomará de la línea de comandos y el 
de destino se creará añadiendo ".txt" al nombre de origen. Debes usar 
FileStream y un bloque de 1 KiB (1024 bytes) de tamaño. Si el fichero de 
destino ya existe, lo sobreescribirás sin preguntar.
* 
* Hugo (...), retoques por Nacho
*/

using System;
using System.IO;

class Ejercicio_180
{
    static void Main(string[] args)
    {
        const int TAMANYO_BLOQUE = 1024;
        if (args.Length == 1)
        {
            string nombre = args[0];
            int cantidadLeida;

            try
            {
                FileStream entrada = File.OpenRead(nombre);
                FileStream salida = File.Create(nombre + ".txt");
                byte[] datos = new byte[TAMANYO_BLOQUE];
                do
                {
                    cantidadLeida = entrada.Read(datos, 0, TAMANYO_BLOQUE);
                    for (int i = 0; i < cantidadLeida; i++)
                    {
                        if ((datos[i] >= 32 && datos[i] <= 127) ||
                            datos[i] == 7 || datos[i] == 10 || datos[i] == 13)
                        {
                            salida.WriteByte(datos[i]);
                        }
                    }
                }
                while ( cantidadLeida == TAMANYO_BLOQUE);

                entrada.Close();
                salida.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Archivo no encontrado");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Nombre de archivo o ruta demasiado larga");
            }
            catch (IOException)
            {
                Console.WriteLine("Error de lectura o escritura");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        else
            Console.WriteLine("Uso: nombreFichero");
    }
}
