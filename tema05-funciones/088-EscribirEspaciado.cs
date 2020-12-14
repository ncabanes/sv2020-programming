using System;
/*88. Crea una función llamada "EscribirEspaciado", que mostrará el parámetro
 * de texto con un espacio adicional entre cada par de letras. 
 * Por ejemplo, el texto "DAM" se mostraría como "D A M".*/

//Iván (...)

class Ejercicio_88
{
    static void EscribirEspaciado(string frase)
    {
        string resultado = "";

        for (int i = 0; i < frase.Length; i++)
        {
            resultado += frase[i] + " ";
            
        }
        Console.Write( resultado.TrimEnd() );
    }

    static void Main()
    {
        Console.WriteLine("Dime un texto: ");
        string texto = Console.ReadLine();
        EscribirEspaciado(texto);
        Console.WriteLine();
    }
}
