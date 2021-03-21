/*x173. Crea una versión alternativa del ejercicio 172 (ordenar y volcar sin 
duplicados), empleado StreamReader y StreamWriter. Debes comprobar si el fichero
de entrada existe, y avisar en caso de que no sea así.*/
using System;
using System.Collections.Generic;
using System.IO;

class OrdenarFichero2
{
    static void Main()
    {
        Console.Write("Nombre archivo: ");
        string inputNombre = Console.ReadLine();

        if (File.Exists(inputNombre))
        {
            try
            {
                // Leemos y ordenamos
                List<string> lineasLista = new List<string>();
                StreamReader f = File.OpenText(inputNombre);
                string linea;
                do
                {
                    linea = f.ReadLine();

                    if (linea != null)
                    {
                        lineasLista.Add(linea);
                    }
                } while (linea != null);
                f.Close();
                lineasLista.Sort();
                
                // Borramos repetidas
                int contador = 0;
                while (contador < lineasLista.Count - 1)
                {
                    if (lineasLista[contador] == lineasLista[contador + 1])
                    {
                        lineasLista.RemoveAt(contador);
                    }
                    else
                    {
                        contador++;
                    }
                }
                
                // Y finalmente volcamos
                string outputNombre = inputNombre + ".ordenado.txt";
                File.WriteAllLines(outputNombre, lineasLista.ToArray());
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Dirección demasiado larga");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Archivo no encontrado");
            }
            catch (IOException)
            {
                Console.WriteLine("Permisos denegados y/o perdido acceso a " +
                    "fichero ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Fichero no encontrado.");
        }
        
        Console.WriteLine("Ordenado y volcado");
    }
}
