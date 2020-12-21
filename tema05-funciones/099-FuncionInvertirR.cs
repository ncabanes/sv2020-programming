/* Alejandro (...) */
/*99. Crea una función Invertir, que devuelva invertida la cadena pasada 
 * como parámetro. Hazlo utilizando un bucle. Crea también una función 
 * InvertirR, que devuelva invertida la cadena pasada como parámetro, 
 * pero de forma recursiva. Pista para el caso recursivo: como caso 
 * base, una cadena de 1 letra o menos se quedará como está; para una 
 * cadena de mayor longitud, se puede tomar su primer carácter y 
 * añadirlo al final de la subcadena invertida (o tomar el último 
 * carácter y añadirlo al principio).*/

using System;
using System.Text;

public class Program
{
    static string Invertir(string cadena)
    {
        string cadenaInvertida = "";
        
        for(int i = cadena.Length-1; i >= 0; i--)
            cadenaInvertida += cadena[i];
        
        return cadenaInvertida;
    }
    
    static string InvertirR(string cadena)
    {
        if (cadena.Length <= 1)
        {
            return cadena;
        }
        else
        {
            return Invertir(cadena.Substring(1)) 
                + cadena[0];
        }
    }
    
    static void Main()
    {
        Console.WriteLine(Invertir("Hola como estas?"));
        Console.WriteLine(InvertirR("Segunda frase para probar"));
    }
}
