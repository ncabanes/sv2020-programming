using System;
class Javascript
{
    static void Main()
    {
        Console.WriteLine("Hola, bienvenido a JavaScript");

        Console.WriteLine("\"Console.WriteLine\" escribe string e int en C#");

        int numero = 3;
        if (numero > 2)
        {
            Console.WriteLine("El numero es mayor que 2");
        }

        if (numero == 3)
        {
            Console.WriteLine("El numero es 3");
        }

        int contador = 1;
        while (contador <= 5)
        {
            Console.WriteLine(contador);
            contador++;
        }

        for (int i = 10; i <= 20; i += 2)
        {
            Console.WriteLine(i);
        }

        string frase = "ejemplo de frase con Trim y Split";
        frase = frase.Replace("de", "con");
        frase = frase.ToUpper();
        frase = frase.Trim();
        string[] palabras = frase.Split(' ');
        foreach (string unaPalabra in palabras)
            Console.WriteLine(unaPalabra);
    }
}
