using System;
class Ejercicio_51
{
    static void Main()
    {    
        short n1;
        short n2;
        short inicio, final;
        
        Console.WriteLine("Introduce un número");
        n1 = Convert.ToInt16( Console.ReadLine () ); 
        Console.WriteLine("Introduce otro número distinto");
        n2 = Convert.ToInt16( Console.ReadLine () ); 

        if (n1 <= n2) 
        {
           inicio = n1;
           final = n2;
        }
        else 
        {
          inicio = n2;
          final = n1;
        }
        
        for(int i = inicio; i <= final; i++)
        {
            Console.Write("{0} ",Convert.ToString (i,16));
            inicio++;
        }

    }
}
