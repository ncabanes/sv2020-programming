/*
Alumno: Verónica (...)

Crea un programa en C# que pida al usuario su edad, su año de nacimiento, 
su estatura en centímetros, la población de su ciudad y el dinero que 
tiene ahorrado. Debes optimizar los tipos de datos usados (todos ellos 
serán números enteros)
*/

using System;  

class Ejercicio_48

{  
    static void Main()  
    {  
        //Edad datos es byte porque va de 0 a 255, y sólo puede ser positivos
        //de sobra para la magnitud de los datos que se manejan
        byte edad; 
        
        //La persona más alta del mundo mide 272 cms, se sale del byte
        ushort cm;
        
        //Dato uint porque población siempre será positiva y la ciudad con más
        //habitantes es Tokio (40millones), da de sobra para int
        uint poblacion;
        
        //Dato long para dinero ya que puede ser positivo o negativo y 
        //muchimillorario
        long dinero;
        
        Console.Write("Introduce tu edad: ");            
        edad=Convert.ToByte(Console.ReadLine());
       
        Console.Write("Introduce tu altura (en cms): ");            
        cm=Convert.ToUInt16(Console.ReadLine());
    
        Console.Write("Introduce la población de tu ciudad: ");            
        poblacion=Convert.ToUInt32(Console.ReadLine());

        Console.Write("Introduce el dinero que tienes ahorrado: ");            
        dinero=Convert.ToInt64(Console.ReadLine());
     }  
} 
