/* 1 DAM Alejandro (...)
 * Pide un número de nota y devuelve la nota de texto*/

using System;

class NotaComoTexto
{
    
    static void Main()
    {
        Console.WriteLine("Dime la nota numérica");
        int num = Convert.ToInt32(Console.ReadLine());
        
        switch (num){
            case 0: 
            case 1: 
            case 2: 
            case 3: 
            case 4:
                Console.WriteLine("SUSPENSO");
                break;
            case 5:
                Console.WriteLine("APROBADO");
                break;
            case 6:
                Console.WriteLine("BIEN");
                break;
            case 7: 
            case 8:
                Console.WriteLine("NOTABLE");
                break;
            case 9: 
            case 10:
                Console.WriteLine("SOBRESALIENTE");
                break;
            default:
                Console.WriteLine("Nota incorrecta");
                break;
        }
    }
}
