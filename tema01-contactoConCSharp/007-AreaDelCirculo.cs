/* Ejercicio realizado por Carlos (...)
 Dado un radio que introduce el usurario, el programa calculará 
 el área del círculo y la mostrará en pantalla.*/
         
class AreaCirculo
{
    static void Main ()
    {
        int radio;
        System.Console.Write("Introduce un radio en metros: ");
        radio = System.Convert.ToInt32( System.Console.ReadLine() );
        System.Console.WriteLine(
            "El área de un círculo de radio {0} m es de {1} m2", 
            radio, 3.14*radio*radio);
    }
}
