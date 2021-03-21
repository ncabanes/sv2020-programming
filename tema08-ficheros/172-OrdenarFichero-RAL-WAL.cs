/*172. Crea un programa en C# que ordene el contenido de un fichero de texto 
y lo vuelque a otro fichero, eliminando las líneas duplicadas. Usa
File.ReadAllLines y File.WriteAllLines, junto con las estructuras dinámicas que
consideres adecuadas. El nombre del fichero de texto de entrada se debe
preguntar al usuario. El nombre del fichero de salida será el mismo que el de
entrada, añadiéndole ".ordenado.txt". Debes comprobar los posibles errores con
try-catch.
*/

//ALBERTO (...)

using System;
using System.Collections.Generic;
using System.IO;

class OrdenarFichero
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
                string[] lineas = File.ReadAllLines(inputNombre);
                List<string> lineasLista = new List<string>(lineas);
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
                
                StreamWriter fichero = new StreamWriter(outputNombre);
                foreach(string linea in lineasLista)
                    fichero.WriteLine(linea);
                fichero.Close();
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
