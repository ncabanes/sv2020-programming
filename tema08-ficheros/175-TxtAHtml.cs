//Alumno: Verónica (...)

/*175. Crea un "convertidor básico de texto a HTML", que leerá un archivo de 
texto de origen y creará un archivo HTML a partir de su contenido. Por ejemplo, 
si el archivo contiene:
Hola
Soy yo
Ya he terminado

El archivo HTML resultante debe contener

<html>
<body>
<p>Hola</p>
<p>Soy yo</p>
<p>Ya he terminado</p>
</body>
</html>

El nombre del fichero de destino debe ser el mismo que el nombre del fichero de 
origen, pero con la extensión "".html"" (que reemplazará a la extensión anterior
 "".txt"", en caso de que la hubiera).  Comprueba los posibles errores.*/

using System;
using System.IO;

class Ejercicio_175
{
    static void Main()
    {
        Console.Write("Nombre de archivo? ");
        string archivo = Console.ReadLine();
        
        if (!File.Exists(archivo))
        {
            Console.WriteLine("El fichero elegido no existe");
            return;
        }
                
        string[] lineasHtml = File.ReadAllLines(archivo);        
        
        string[] partesArchivo = archivo.Split('.');
        
        try
        {
            StreamWriter ficheroHtml = File.CreateText(partesArchivo[0] + ".html");
            
            ficheroHtml.WriteLine("<htlm>");
            ficheroHtml.WriteLine("<body>");
            foreach (string linea in lineasHtml)
            {
                ficheroHtml.WriteLine("<p>"+linea+"</p>");
            }
            
            ficheroHtml.WriteLine("</body>");
            ficheroHtml.WriteLine("</html>");

            ficheroHtml.Close();
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
        
        Console.WriteLine("Exportación finalizada");
        
    }
    
}
