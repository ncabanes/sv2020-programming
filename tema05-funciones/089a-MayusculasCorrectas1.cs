/* Alejandro (...) */
/* 89. Crea una función llamada "MayusculasCorrectas", que recibirá una 
 * cadena como parámetro y la devolverá en minúsculas, excepto la 
 * primera letra y las que están después de una punto. Por ejemplo, 
 * a partir del texto "hola.esto No es. diFícil" se obtendrá 
 * "Hola.Esto no es. Difícil"*/
 
using System;

class Program 
{
    static bool EsMinuscula(char caracter)
    {
        if (caracter >= 'a' && caracter<= 'z')
        {
            return true;
        }
        return false;
    }
    
    static string MayusculasCorrectas(string texto)
    {
        texto = texto.ToLower();
        
        for (int i = 0; i < texto.Length; i++)
        {
            if( i == 0 || texto[i-1] == '.')
            {
                while(texto[i] == ' ')
                {
                    i++;
                }
                 
                if (EsMinuscula(texto[i]))
                {
                    char reemplazar = (char)(texto[i] - 'a' + 'A');
                    texto = texto.Remove(i,1);
                    texto = texto.Insert(i, "" + reemplazar);
                }
            }
        }   
        return texto;
    }

    public static void Main()
    {
        Console.WriteLine(
            MayusculasCorrectas("hola.esto No es. dificil.Y tal.2"));
        
    }
    
}
