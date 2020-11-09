// Jorge (...)
// Calculadora

using System;

class ejercicio57
{
    static void Main()
    {
        long numero1, numero2;
        char operacion;

        Console.Write("Introduzca el numero 1: ");
        numero1 = Convert.ToInt64(Console.ReadLine());
        Console.Write("Que operacion quiere realizar? ");
        operacion = Convert.ToChar(Console.ReadLine());
        Console.Write("Introduzca el numero 2: ");
        numero2 = Convert.ToInt64(Console.ReadLine());

        switch (operacion)
        {
            case '+':
                Console.Write("{0} + {1} = {2} ", numero1, numero2, numero1+numero2);
                break;
            case '-':
                Console.Write("{0} - {1} = {2} ", numero1, numero2, numero1 - numero2);
                break;
            case '*':
            case '·':
            case 'x':
            case 'X':
                Console.Write("{0} * {1} = {2} ", numero1, numero2, numero1 * numero2);
                break;
            case '/':
                Console.Write("{0} / {1} = {2} ", numero1, numero2, numero1 / numero2);
                break;
        }
    }
}
