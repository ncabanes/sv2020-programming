/*111. Crea una clase llamada "Titulo". Sus atributos (públicos) serán el texto 
y las coordenadas x e y. Tendrá un método llamado "Mostrar", que mostrará su 
texto en la pantalla, en sus coordenadas. Crea una clase "PruebaDeTitulo" (en 
el mismo fichero fuente), que tendrá un "Main" para probarlo. Puedes ayudarte 
de Console.SetCursorPosition para conseguir que el texto aparezca realmente en 
esas coordenadas. Deberás entregar sólo el fichero .cs.*/


//ALBERTO (...)

using System;

class Titulo
{
    public int x;
    public int y;
    public string texto;

    public void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(texto);
    }
}

class PruebaDeTitulo
{
    static void Main()
    {
        Titulo t = new Titulo();
        t.x = 30;
        t.y = 10;
        t.texto = "Prueba de título";
        t.Mostrar();
    }
}

