using System;

// Manipulación de cadenas
// Iván (...)

class Ejercicio_74
{
    static void Main()
    {
        Console.Write("Introduza una cadena de texto: ");
        string texto = Console.ReadLine();

        string textoMayus = texto.ToUpper();
        Console.WriteLine("Todo mayúsculas: " + textoMayus);

        string textoMinus = texto.ToLower();
        Console.WriteLine("Todo minúscilas: " + textoMinus);

        string textoEliminar = texto.Remove(1, 2);
        Console.WriteLine("Eliminamos 2ª y 3ª letra: " + textoEliminar);

        string textoInsertar = texto.Insert(2, "yo");
        Console.WriteLine("Insertar 'yo' despues de la  2ª letra: "
            + textoInsertar);

        string textoGuion = texto.Replace(" ", "_");
        Console.WriteLine("Reemplazamos los espacios por guiones bajos: "
            + textoGuion);

        string textoEspaciosIniciales = texto.TrimStart();
        Console.WriteLine("Eliminamos los espacios iniciales: "
            + textoEspaciosIniciales);

        string textoEspaciosFinales = texto.TrimEnd();
        Console.WriteLine("Eliminamos los espacios iniciales: "
            + textoEspaciosFinales);

        string textoRemplazarA = texto.Replace("a", "A");
        Console.WriteLine("Reemplazar las a minúsculas por A mayúsculas: "
            + textoRemplazarA);

        string[] dividirTexto = texto.Split();
        Console.WriteLine("Dividimos el texto en un array y se muestra uno"
            + "en cada línea:");
        foreach (string s in dividirTexto)
        {
            Console.WriteLine(s);
        }
    }
}
