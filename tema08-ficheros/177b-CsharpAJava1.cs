// Alumno: Verónica (...)

/* 177. Crea un "convertidor básico de C#" a Java, que pedirá el nombre de un 
fichero y volcará su contenido a otro con el mismo nombre pero con extensión 
".java" en vez de ".cs" y que debe ser capaz de convertir correctamente ficheros 
como los dos siguientes [...]
Es decir, hará los siguientes cambios:

    -Cambiará Console.WriteLine por System.out.println
    -Cambiará Console.Write por System.out.print
    -Eliminará las líneas que comienzan por "using"
    -Añadirá "public" a la línea "class" si no lo tiene
    -Corregirá la línea de "Main" para adaptarla al formato de Java
    -Añadirá una línea "import java.util.Scanner;" al principio del fuente
    -Añadirá una línea "Scanner sc = new Scanner(System.in);" tras la línea de 
    comienzo de "Main".
    -Cambiará los "Convert.ToInt32(Console.ReadLine());" (quizá con espacios 
    intermedios) por "sc.nextInt();"
    -Cambiará los "Convert.ToDouble(Console.ReadLine());" (quizá con espacios 
    intermedios) por "sc.nextDouble();"

Comprueba que los programas generados para esos dos ejemplos compilan 
correctamente.*/


using System;
using System.IO;

class Ejercicio_177
{
    static void Main()
    {
        string archivo;
        
        do
        {
            Console.WriteLine("Qué fichero .cs quieres convertir a .java? " +
                "(Sólo nombre, la extensión se autocompleta): ");
            archivo = Console.ReadLine();
            
            if(!File.Exists(archivo + ".cs"))
            {
                Console.WriteLine("El fichero elegido no existe");
            }
        }
        while(!File.Exists(archivo + ".cs"));
                
        string[] lineasJava = File.ReadAllLines(archivo + ".cs");
        
        
        try
        {
            StreamWriter ficheroJava = File.CreateText("Ejercicio177.java");
            
            ficheroJava.WriteLine("import java.util.Scanner;");
            int contadorLineas = 0;
            int mainEncontrado = 1; //Empieza en 1 porque metí el util.Scanner
            
            foreach (string linea in lineasJava)
            {
                if(linea.ToLower().Contains("main"))
                {
                    mainEncontrado = contadorLineas;
                }
                
                string lineaCambios = RevisarConsoleW(linea);
                lineaCambios = EliminarUsing(lineaCambios);
                lineaCambios = RevisarClasePublica(lineaCambios);
                lineaCambios = RevisarMain(lineaCambios);
                lineaCambios = RevisarConvertToInt(lineaCambios);
                lineaCambios = RevisarConvertToDouble(lineaCambios);
                
                if(contadorLineas != mainEncontrado + 1)//Para la sig. a Main
                {
                    ficheroJava.WriteLine(lineaCambios);
                }
                contadorLineas++;
            }
            
            ficheroJava.Close();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Ruta de fichero demasiado larga");
        }
        catch (IOException)
        {
            Console.WriteLine("Error al escribir");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        
        Console.WriteLine("Conversión realizada");
        
    }
    
    private static string RevisarConsoleW(string codigo)
    {
        if(codigo.Contains("Console.WriteLine"))
        {
            return codigo.Replace("Console.WriteLine", "System.out.println");
        }
        else 
        {
            if(codigo.Contains("Console.Write"))
            {
                return codigo.Replace("Console.Write", "System.out.print");
            }
            else
            {
                return codigo;
            }
        }
    }
    
    private static string EliminarUsing(string codigo)
    {
        if(codigo.IndexOf("using ") >= 0)
        {
            return "";
        }
        else
        {
            return codigo;
        } 
    }
    
    private static string RevisarClasePublica(string codigo)
    {
        if(codigo.Contains("class ") && !codigo.Contains("public "))
        {
            return codigo.Replace("class ", "public class ");
        }
        else
        {
            return codigo;
        } 
    }
    
    private static string RevisarMain(string codigo)
    {
        int posicionMain = 0;
        string nuevaLineaMain = "";
        
        if(codigo.ToUpper().Contains(" MAIN"))
        {
            int sangria = codigo.Length - codigo.TrimStart().Length;            
            string[] partesCadena = codigo.Split(' ');
            
            for( byte i = 0; i < partesCadena.Length; i++)
            {
                if(partesCadena[i].ToUpper().Contains("MAIN"))
                {
                    posicionMain = i;
                }
            }
            
            for (byte i = 0; i < posicionMain; i++)
            {
                nuevaLineaMain = nuevaLineaMain + partesCadena[i] + " ";
            }
            
            return ( nuevaLineaMain + "main (String[] args) \n" +
                new string(' ', sangria) + "{\n" + new string(' ', sangria + 4)+ 
                "Scanner sc = new Scanner(System.in);");
        }
        else
        {
            return codigo;
        }
        
        
    }
    
    private static string RevisarConvertToInt(string codigo)
    {
        if(codigo.Contains("Console") && codigo.Contains("ReadLine")
            && codigo.Contains("ToInt32"))
        {
            int posicSigno = codigo.IndexOf("=",0,codigo.Length);
            
            return codigo.Substring(0,posicSigno + 1) + " sc.nextInt();";
        }
        else
        {
            return codigo;
        } 
    }
    
    private static string RevisarConvertToDouble(string codigo)
    {
        if(codigo.Contains("Console") && codigo.Contains("ReadLine")
            && codigo.Contains("ToDouble"))
        {
            int posicSigno = codigo.IndexOf("=",0,codigo.Length);
            
            return codigo.Substring(0,posicSigno + 1) + " sc.nextDouble();";
        }
        else
        {
            return codigo;
        } 
    }
    
}
