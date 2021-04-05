/* Eduardo (...)
 * 
 * Convertidor de PASCAL a C#
 */

using System;
using System.Collections.Generic;
using System.IO;

class ejercicio
{
    static int Main(string[]args)
    {
        string nombre;
        

        if(args.Length == 1)
        {
            nombre = args[0];
        }

        else if(args.Length > 1)
        {
            Console.WriteLine("Debe introducir sólo un parámetro, que será" +
                "el nombre completo del archivo pascal a convertir");
            return 1;
        }

        else
        {
            Console.WriteLine("Introduzca el nombre del archivo Pascal a" +
                "convertir");
            nombre = Console.ReadLine();

            if (!File.Exists(nombre))
            {
                Console.WriteLine("Archivo no encontrado");
                return 2;
            }
        }

        try
        {
            List<string> lineas = new List<string>(File.ReadAllLines(nombre));
            lineas.Insert(0, "using System;");
            int numeroLineaComienzoPrograma = 500000;

            for (int i = 0; i < lineas.Count; i++)
            {    
                if (lineas[i].Contains("=") && !lineas[i].Contains(":"))
                    lineas[i] = lineas[i].Replace("=", "==");

                // MODIFICAR WRITELINE
                if(lineas[i].Contains("write") && !lineas[i].Contains("Ln"))
                    modifica("write", "Console.Write", lineas, i);

                //MODIFICACIONES VARIAS
                modifica("writeLn", "Console.WriteLine", lineas, i);
                modifica("begin", "", lineas, i); //ESTE ME ESTROPEABA EL CODIGO
                modifica("end;", "}", lineas, i);
                modifica("end.", "}", lineas, i);
                modifica("end", "}", lineas, i);
                modifica(":=", "=", lineas, i);
                modifica("'", "\"", lineas, i);

                // ELIMINAR VAR
                if (lineas[i].Trim() == "var")
                    lineas.RemoveAt(i);

                if (lineas[i].Contains("program"))
                {
                    numeroLineaComienzoPrograma = i;
                    lineas[i] = lineas[i].Replace("program", "class") + 
                        Environment.NewLine + "{" +
                        Environment.NewLine + "  static void Main()" +
                        Environment.NewLine + "  {";
                    lineas[i] = lineas[i].Replace(";", "");
                }

                // MODIFICAR INTEGER
                if (lineas[i].Contains("integer"))
                {
                    lineas[i] = lineas[i].Trim();
                    lineas[i] = "  int " + 
                        lineas[i].Substring(0,lineas[i].IndexOf(":")) + ";";
                }

                // MODIFICAR READLN
                if (lineas[i].Contains("readLn"))
                {
                    modifica("readLn(", "", lineas, i);
                    modifica(");", "", lineas, i);
                    lineas[i] = lineas[i] + " = Convert.ToInt32(Console.ReadLine());";
                }

                // FORMATO IF
                modifica("if ", "if (", lineas, i);
                modifica(" then", ")", lineas, i);

                // FORMATO FOR
                modifica("for ", "for( ", lineas, i);
                modifica(" to ", "; i <= ", lineas, i);
                modifica(" do", "; i++)", lineas, i);
                
                if (i > numeroLineaComienzoPrograma)
                    lineas[i] = "    " + lineas[i];
            }

            // CERRAMOS EL ULTIMO CORCHETER
            lineas.Add("}");
            
            // Y VOLCAMOS LA LISTA EN EL ARCHIVO DE SALIDA
            File.WriteAllLines(nombre.Remove(nombre.Length - 3) + "cs", lineas);
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("Nombre de archivo demasiado largo");
        }
        catch (IOException)
        {
            Console.WriteLine("Error de lectura/escritura");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR MORTAL: " + e + " ¡Tu alma es mia!");
        }
        return 0;
    }

    static void modifica(string esto, string porEsto, List<string> lineas, int i)
    {
        if (lineas[i].Contains(esto))
            lineas[i] = lineas[i].Replace(esto, porEsto);
    }
}
