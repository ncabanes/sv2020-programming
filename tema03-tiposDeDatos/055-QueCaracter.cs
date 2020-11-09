//Roberto (...)

/*Se pedirá al usuario un símbolo y responda si se trata 
  de un dígito, un operador, un símbolo de puntuación o de algún otro símbolo.*/
  
using System;

class Ejercicio_55
{
    static void Main()
    {
        char simbolo;
        bool esDigito, esOperador, esPuntuacion;
        
        Console.Write("Introduzca un símbolo: ");
        simbolo = Convert.ToChar( Console.ReadLine() );
        
        esDigito = (simbolo >= '0' && simbolo <= '9');        
        esOperador = (simbolo == '+' || simbolo == '-' || simbolo == '*' ||
            simbolo == '/');        
        esPuntuacion = (simbolo == '.' || simbolo == ',' || simbolo == ':' ||
            simbolo == ';');
        
        if (esDigito)
            Console.WriteLine("Se trata de un dígito.");
        else if (esOperador)
            Console.WriteLine("Se trata de un operador.");
        else if (esPuntuacion)
            Console.WriteLine("Se trata de una puntuación.");
        else
            Console.WriteLine("Se trata de otro tipo de símbolo.");
            
        switch (simbolo)
        {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9': Console.WriteLine("Se trata de un dígito."); 
                        break;  
            case '+':
            case '-':
            case '*':
            case '/': Console.WriteLine("Se trata de un operador."); 
                        break;
            case '.':
            case ',':
            case ';':
            case ':': Console.WriteLine("Se trata de una puntuación."); 
                        break;
            default: Console.WriteLine("Se trata de otro tipo de símbolo.");
                        break;
        }
    }
} 
  
