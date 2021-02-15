/* Crea una clase "EncriptadorCesar", que herede de "Encriptador" (ejercicio 
142) y que use el "cifrado de César para encriptar y desencriptar textos, con 
un desplazamiento de 3 espacios. 
https://es.wikipedia.org/wiki/Cifrado_C%C3%A9sar */

using System;

class Encriptador 
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

// -----------------------------

class EncriptadorCesar: Encriptador
{
    public new static string Encriptar(string cadena)
    {
        string cadenaCifrada = "";

        for (int i = 0; i < cadena.Length; i++)
        {
            if (cadena[i] >= 'a' && cadena[i] <= 'w'
                || cadena[i] >= 'A' && cadena[i] <= 'W')
                cadenaCifrada += Convert.ToChar(cadena[i] + 3);
            else if (cadena[i] >= 'x' && cadena[i] <= 'z'
                || cadena[i] >= 'X' && cadena[i] <= 'Z')
                cadenaCifrada += Convert.ToChar(cadena[i] - 23);

            else
                cadenaCifrada += cadena[i];
        }
        return cadenaCifrada;
    }

    public new static string Descifrar(string cadena)
    {
        string cadenaDescifrada = "";

        for (int i = 0; i < cadena.Length; i++)
        {
            if (cadena[i] >= 'd' && cadena[i] <= 'z'
              || cadena[i] >= 'D' && cadena[i] <= 'Z')
                cadenaDescifrada += Convert.ToChar(cadena[i] - 3);
            else if (cadena[i] >= 'a' && cadena[i] <= 'c'
                || cadena[i] >= 'A' && cadena[i] <= 'C')
                cadenaDescifrada += Convert.ToChar(cadena[i] + 23);

            else
                cadenaDescifrada += cadena[i];
        }
        return cadenaDescifrada;
    }
}


// -----------------------------

class PruebaDeEncriptador
{
    public static void Main()
    {
        Console.WriteLine(Encriptador.Encriptar("Holaz"));
        Console.WriteLine(Encriptador.Descifrar("Ipmb{"));
        
        Console.WriteLine(EncriptadorCesar.Encriptar("Holaz"));
        Console.WriteLine(EncriptadorCesar.Descifrar("Krodc"));
    }
}
