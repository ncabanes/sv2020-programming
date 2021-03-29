using System;
public class Javascript2
{
    public static void Main()
    {
        string frase = "string con espacios, no int ";
        if (frase.StartsWith("string"))
        {
            int longitud = frase.Length;
            for( int contador = 0; contador < longitud; contador++)
            {
                Console.WriteLine(frase[contador]);
            }
            
            int n = 0;
            for(n = 5; n > 0; n--)
            {
                Console.WriteLine(n);
            }
            
            if (longitud != 20)
            {
                Console.WriteLine("El primer carácter es " +
                    frase[0]);
            }
            
        }
        string frase2 = "uno,dos,tres";
        string[] partes = frase2.Split(',');
        foreach(string foreach1 in partes)
            Console.WriteLine(foreach1);
    }
}
