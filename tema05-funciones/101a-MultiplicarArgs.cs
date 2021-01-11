/*101. Crea un programa llamado "Multiplicar", que reciba dos números enteros 
en línea de comandos y muestre su producto, como en este ejemplo:

multiplicar 5 3
15
*/

//ALBERTO (...)

using System;

class EJERCICICIO101
{
    static void Main(string[] args)
    {
        if (args.Length == 2)
        {
            int primerNumero = Convert.ToInt32(args[0]);
            int segundoNumero = Convert.ToInt32(args[1]);
            Console.WriteLine(primerNumero*segundoNumero);
        }
        else
        {
            Console.WriteLine("Uso: multiplicar 5 3");
        }
    }
}

