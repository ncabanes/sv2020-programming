using System;

/*
58.Escribe un programa que pida un ancho y una altura (ambos serán "byte"),
así como un carácter, y muestre un trapecio descendente como este:

Introduzca el ancho deseado: 5
Introduzca la altura deseada: 3
Introduzca el carácter: *
*********
 *******
  *****

 */


class Ejercicio58bis
{
    static void Main()
    {
        byte anchoMinimo, alto;
        char caracter;

        Console.Write("Introduzca ancho: ");
        anchoMinimo = Convert.ToByte(Console.ReadLine());

        Console.Write("Introduzca alto: ");
        alto = Convert.ToByte(Console.ReadLine());

        Console.Write("Introduzca el caracter: ");
        caracter = Convert.ToChar(Console.ReadLine());

        int espacios = 0;
        int simbolos = anchoMinimo + (alto-1)*2;
        for (int fila = 0; fila < alto; fila++)
        {
            for (int columnaEspacio = 0; columnaEspacio < espacios; columnaEspacio++)
                Console.Write(" ");

            for (int columnaRellena = 0; columnaRellena < simbolos; columnaRellena++)
                Console.Write(caracter);

            Console.WriteLine();
            
            espacios ++;
            simbolos -= 2;
        }
    }
}

