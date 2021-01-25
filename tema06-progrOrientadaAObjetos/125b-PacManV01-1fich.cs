using System;

/*125. Para un esqueleto de juego de PacMan en modo consola, crea una clase 
 * Sprite, que contenga como atributos las coordenada X e Y, así como el 
 * carácter a mostrar en pantalla, todos ellos protegidos. Crea setters y 
 * getters para cada uno de los datos. Crea un constructor, que reciba los 
 * tres datos. Debes crear también un método Mostrar, que dibuje ese Sprite 
 * en pantalla, empleando SetCursorPosition. Crea una clase Fantasma, que 
 * herede de Sprite y cuyo constructor sólo recibirá los valores de X e Y, 
 * y prefijará el carácter a "A". Crea una clase Pac, que  herede de Sprite y 
 * cuyo constructor sólo recibirá los valores de X e Y, y prefijará el carácter
 * a "C". El primer Main de prueba creará un Pac y 4 Fantasmas, con coordenadas
 * adecuadas, y los mostrará en pantalla.*/

//Iván (...)

class PruebaPacMan
{
    static void Main()
    {
        Pac p = new Pac(8, 10);
        p.Mostrar();
        Fantasma f1 = new Fantasma(15, 10);
        f1.Mostrar();
        Fantasma f2 = new Fantasma(17, 10);
        f2.Mostrar();
        Fantasma f3 = new Fantasma(19, 10);
        f3.Mostrar();
        Fantasma f4 = new Fantasma(21, 10);
        f4.Mostrar();
    }
}

// ---------------------------------

class Sprite
{
    protected int x, y;
    protected char caracter;

    public Sprite()
    {
        x = GetX();
        y = GetY();
        caracter = GetCaracter();
    }

    public int GetX() { return x; }

    public int GetY() { return y; }

    public char GetCaracter() { return caracter; }

    public void SetX(int nuevaX)
    {
        x = nuevaX;
    }

    public void SetY(int nuevaY)
    {
        y = nuevaY;
    }

    public void SetCaracter(char nuevoCaracter)
    {
        caracter = nuevoCaracter;
    }

    public void Mostrar()
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(caracter);
    }
}

// ---------------------------------

class Pac : Sprite
{
    public Pac(int nuevaX, int nuevaY)
    {
        x = nuevaX;
        y = nuevaY;
        caracter = 'C';
    }
}

// ---------------------------------


class Fantasma: Sprite
{
    public Fantasma(int nuevaX, int nuevaY)
    {
        x = nuevaX;
        y = nuevaY;
        caracter = 'A';
    }
}
