/* Eduardo (...)
 * 
 * Crea una clase "AlbumDeFotos" con un atributo privado "numeroDePaginas".
 *
 * También debe tener un método público "GetNumeroDePaginas", que devolverá 
 * el número de páginas.
 *
 * El constructor predeterminado creará un álbum con 16 páginas. Habrá un 
 * constructor adicional, con el que podemos especificar el número de 
 * páginas que queremos en el álbum.
 *
 * Crea una clase "AlbumDeFotosGrande", que herede de ella, y cuyo 
 * constructor creará un álbum con 64 páginas.
 *
 * Crea una clase de prueba "PruebaDeAlbum", que cree un array formado por: 
 * un álbum con su constructor predeterminado, uno con 24 páginas, un 
 * "AlbumDeFotosGrande". Posteriormente, empleando un bucle, muestra la 
 * cantidad de páginas que tienen los tres álbumes.
 */

using System;

class PruebaDeAlbum
{
    static void Main()
    {
        AlbumDeFotos[] albumes = new AlbumDeFotos[3];
        albumes[0] = new AlbumDeFotos();
        albumes[1] = new AlbumDeFotos(24);
        albumes[2] = new AlbumDeFotosGrande();

        for (byte i = 0; i < albumes.Length; i++)
        {
            Console.WriteLine("El album " + i +" tiene: " + 
                albumes[i].NumeroDePaginas + " páginas");
        }
    }
}

// ------------------

class AlbumDeFotos
{
    private int numeroDePaginas;

    public AlbumDeFotos()
    {
        numeroDePaginas = 16;
    }

    public AlbumDeFotos(int numeroDePaginas)
    {
        this.numeroDePaginas = numeroDePaginas;
    }

    public int NumeroDePaginas
    {
        get { return numeroDePaginas; }
    }
}

// ------------------

class AlbumDeFotosGrande : AlbumDeFotos
{
    public AlbumDeFotosGrande()
        : base (64)
    {
        // Aqui ya no hace falta poner nada...
    }
}
