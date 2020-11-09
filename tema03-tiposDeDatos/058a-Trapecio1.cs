using System;

// Alberto (...)

/*58.Escribe un programa que pida un ancho y una altura (ambos serán "byte"), 
así como un carácter, y muestre un trapecio descendente como este:

Introduzca el ancho deseado: 5
Introduzca la altura deseada: 3
Introduzca el carácter: *
*********
 *******
  *****

 */


class Ejercicio58
{
    static void Main()
    {
        byte ancho;
        byte alto;
        char caracter;
            
        Console.Write("Introduzca ancho: ");
        ancho = Convert.ToByte(Console.ReadLine());
        
        Console.Write("Introduzca alto: ");
        alto = Convert.ToByte(Console.ReadLine());

        Console.Write("Introduzca el caracter: ");
        caracter = Convert.ToChar(Console.ReadLine());

            
        for (int fila = 0; fila < alto; fila++)
        {
            int anchoresultado = ancho + (2 *(alto - fila -1));

            for (int columnaEspacio = 0; columnaEspacio < fila; columnaEspacio++)
            {

                Console.Write(" ");

            }

            for (int columnaRellena = 0; columnaRellena < anchoresultado; columnaRellena++)
            {

                Console.Write(caracter);
                
            }

            Console.WriteLine();

        }
    }       
}

