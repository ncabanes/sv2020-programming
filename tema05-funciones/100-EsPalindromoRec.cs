/* Función "EsPalindromoR", que devuelve "true" si la cadena de caracteres
 * indicada como parámetro es simétrica (un palíndromo).
 * 
 * Hugo (...)
 */

using System;

class PalindromoRecursivo
{
    static bool EsPalindromoR(string texto)
    {
        // manipulamos el texto para que se compruebe sin espacios ni mayúsculas
        texto = texto.ToUpper();
        while (texto.Contains(" "))
        {
            texto = texto.Replace(" ", "");
        }
        
        // Caso base
        if (texto.Length <= 1)
        {
            return true;
        }
            

        // Caso general
        if (texto[0] != texto[texto.Length - 1])
            return false;
        else
            return EsPalindromoR(texto.Substring(1, texto.Length - 2));
    }

    static void Main()
    {
        if (EsPalindromoR("Dabale arroz a la zorra     el abad"))
            Console.WriteLine("El texto es palíndromo!");
        else
            Console.WriteLine("El texto no es palíndromo!");
    }
}
