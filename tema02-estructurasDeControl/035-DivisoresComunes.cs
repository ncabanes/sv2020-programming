//Alumno: Verónica (...)
//Pedir al usuario dos números y mostrar divisores comunes, excepto el 1


using System;

class Ejercicio_35
{
    static void Main()
    {
       int num1, num2, divisor = 2, menor; //div=2 porque se excluye el 1
       
       Console.Write("Introduce un número: ");
       num1=Convert.ToInt32(Console.ReadLine());
       Console.Write("Introduce otro número: ");
       num2=Convert.ToInt32(Console.ReadLine());
       menor = num1 < num2 ? num1 : num2 ;
       
       while (divisor < menor)
       {
            if((num1 % divisor == 0) && (num2% divisor == 0))
            {
                Console.Write("{0} ", divisor);
            }
            divisor = divisor + 1;
        }
    }
}
