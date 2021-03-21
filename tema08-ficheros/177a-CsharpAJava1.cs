using System;
using System.Collections.Generic;
using System.IO;

/*177. Crea un "convertidor básico de C#" a Java, que pedirá el nombre de un 
 * fichero y volcará su contenido a otro con el mismo nombre pero con 
 * extensión ".java" en vez de ".cs" y que debe ser capaz de convertir 
 * correctamente ficheros como los dos siguientes*/

// Iván (...)

class Ejercicio_177
{
    static void Main()
    {
        Console.WriteLine("Conversor de C# a Java");
        Console.Write("Introduzca nombre del fichero a convertir: ");
        string fichero = Console.ReadLine();

        if (File.Exists(fichero))
        {
            List<string> ficheroCs =
                new List<string>(File.ReadAllLines(fichero));

            string[] nombre = fichero.Split('.');
            int lineas = ficheroCs.Count;

            ficheroCs.Insert(0, "import java.util.Scanner;");

            for (int i = 0; i < lineas; i++)
            {
                if (ficheroCs[i].Contains("using"))
                {
                    ficheroCs.RemoveAt(i);
                }

                if (ficheroCs[i].Contains("class"))
                {
                    if (!ficheroCs[i].Contains("public"))
                    {
                        ficheroCs[i] = "public " + ficheroCs[i];
                        ficheroCs[i + 2] =
                            "    public static void main(String[] args)";
                    }
                    else
                        ficheroCs[i + 2] = "    static void main(String[] args)";

                    ficheroCs.Insert(i + 4,
                            "        Scanner sc = new Scanner(System.in);");  
                }

                if (ficheroCs[i].Contains("Console")
                        && ficheroCs[i].Contains("ReadLine")
                        && ficheroCs[i].Contains("Convert"))
                {
                    int posicion = ficheroCs[i].IndexOf('=');

                    if (ficheroCs[i].Contains("ToInt32"))
                    {
                        ficheroCs[i] = ficheroCs[i].Substring(0, posicion + 2);
                        ficheroCs[i] += "sc.nextInt();";
                    }

                    if (ficheroCs[i].Contains("ToDouble"))
                    {
                        ficheroCs[i] = ficheroCs[i].Substring(0, posicion + 2);
                        ficheroCs[i] += "sc.nextDouble();";
                    }
                }

                ficheroCs[i] = ficheroCs[i].Replace("Console.WriteLine",
                    "System.out.println");
                ficheroCs[i] = ficheroCs[i].Replace("Console.Write",
                    "System.out.print");
            }
            File.WriteAllLines(nombre[0] + ".java", ficheroCs);
            Console.WriteLine("Fichero convertido con éxito!");
        }
        else
            Console.WriteLine("Fichero no encontrado");
    }
}
