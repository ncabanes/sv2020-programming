/*
142. Crea una clase "Encriptador" para cifrar y descifrar texto.
Tendrá un método "Encriptar", que recibirá una cadena y devolverá otra
cadena. Será un método estático, por lo que no necesitaremos crear
ningún objeto de tipo "Encriptador".  También habrá un método de
"Descifrar".  En este primer acercamiento, el método de cifrado será
muy simple: para cifrar sumaremos 1 a cada carácter, de modo que "Hola"
se convierta en "Ipmb", y para descifrar restaremos 1 a cada carácter.
Crea una clase PruebaDeEncriptador para probarlo. Un ejemplo de uso
podría ser  string nuevoTexto = Encriptador.Encriptar ("Hola");
*/

using System;

class Encriptador // Version 2, con "foreach"
{
    public static string Encriptar ( string texto )
    {
        string nuevaCadena = "";
        foreach (char c in texto)
        {
            nuevaCadena += (char)(c + 1);
        }
        return nuevaCadena;
    }

    public static string Descifrar ( string texto )
    {
        string nuevaCadena = "";
        foreach (char c in texto)
        {
            nuevaCadena += (char)(c - 1);
        }
        return nuevaCadena;
    }
}

class PruebaDeEncriptador
{
    public static void Main()
    {
        Console.WriteLine(Encriptador.Encriptar("Hola"));
        Console.WriteLine(Encriptador.Descifrar("Ipmb"));
    }
}
