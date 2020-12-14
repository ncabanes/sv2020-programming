/* Función "MayusculasCorrectas", que recibe una cadena como parámetro y la 
 * devuelve en minúsculas, excepto la primera letra y las que están después de 
 * un punto. 
* Por ejemplo, a partir del texto "hola.esto No es. diFícil" se obtendrá 
* "Hola.Esto no es. Difícil"
* Hugo (...)
*/

using System;

class Ejercicio_89
{
    static string MayusculasCorrectas(string frase)
    {
        string[] textoArray = new string[frase.Length];
        string texto = "";
        
        frase = frase.ToLower();
        
        // Array auxiliar de cadenas, para convertir a mayúsculas
        for (int i = 0; i < textoArray.Length; i++)
        {
            textoArray[i] = frase[i].ToString();
        }
        
        // Primera letra
        textoArray[0] = textoArray[0].ToUpper();
        int caracter = 0;
        
        // Letras tras espacios
        while (caracter < textoArray.Length -1)
        {
            if (textoArray[caracter] == ".")
            {
                while (textoArray[caracter+1] == " ")
                {
                    caracter++;
                }
                textoArray[caracter+1] = textoArray[caracter+1].ToUpper();
            }
            caracter++;
        }
        
        // Finalmente, preparamos la respuesta
        for (int i = 0; i < textoArray.Length; i++)
        {
            texto += textoArray[i];
        }
        
        return texto;
    }
    
    static void Main()
    {
        string frase;
        
        Console.WriteLine("Introduce una frase:");
        frase = Console.ReadLine(); 
        
        Console.WriteLine(MayusculasCorrectas(frase));
    }
}
