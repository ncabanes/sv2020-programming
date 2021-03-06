/*
Queremos crear un programa básico de facturación, utilizando un diseño
orientado a objetos.

Debe permitir crear facturas, que estarán formadas por varias líneas,
cada una de las cuales contendrá los detalles de un artículo. Cada
factura corresponderá a un único cliente.

En esta primera aproximación, de cada cliente (clase Cliente)
almacenaremos un código, además, del DNI o CIF y el nombre. Debe haber
un único constructor que permita inicializar los valores de estos 3
campos, getters para los 3 campos y un setter que permita cambiar el
valor del nombre (no se podrá modificar el código ni el DNI/CIF, para
evitar inconsistencias). Querremos un "ToString", que devuelva los tres
datos en una misma línea, separados por " - ", y también un "bool
Contiene", que permita saber si contiene un cierto texto en su DNI o en
su nombre (sin distinguir mayúsculas y minúsculas).

De forma similar, en esta primera aproximación, de cada artículo (clase
Articulo) guardaremos un código, una descripción y un precio de venta.
Debe haber un único constructor que permita inicializar los valores de
estos 3 campos, getters para los 3 campos y setters para descripción y
precio. Querremos un "ToString", que devuelva el código, seguido por
".- " y la descripción y por el precio entre paréntesis.

Cada línea de factura (clase LinFact) tendrá un único constructor que
recibirá el artículo que aparece en esa línea y la cantidad. Se deberá
almacenar (como atributos) el código del artículo, su descripción (por
si cambia), su precio (por el mismo motivo) y la cantidad.

La factura (clase Factura) tendrá un constructor que reciba el número
de factura, la fecha y el cliente para quien es dicha factura. Este
constructor estará vacío (sin código) por ahora. Habrá otro constructor
(sin código) que reciba sólo la fecha y el cliente (porque más adelante
calculará el número de factura a partir de la lista de facturas
anteriores. Un tercer constructor (sin código) recibirá sólo el
cliente, y se apoyará en el segundo constructor, al que pasará la fecha
actual como primer parámetro. También existirá un método "Add", todavía
sin código, que tendrá como parámetro una línea de factura, que se
añadirá (en una versión posterior del programa) a la factura actual.

Como la estructura de un albarán de entrega de mercancía es tan similar
a la de una factura, se ha decidido crear también una clase albarán y
una clase "línea de albarán" (LinAlb), así como una clase "documento
para cliente" (DocCliente) y otra "línea de documento para cliente"
(LinDocCliente). Estas dos últimas clases serán las que se utilicen
como superclases de las que heredar tanto facturas como albaranes y sus
respectivas líneas.

Además, nos han pedido que creemos también una clase Proveedor, para
futuras ampliaciones. De cada proveedor almacenaremos un código, el DNI
o CIF, el nombre y la categoría (para poder anotar qué tipo de
productos nos suministra). Para esta clase también querremos un
"ToString", que devuelva los cuatro datos en una misma línea, separados
por " - ", y también un "bool Contiene", que permita saber si contiene
un cierto texto en su DNI, en su categoría o en su nombre (sin
distinguir mayúsculas y minúsculas).

Debes crear un esqueleto (que compile correctamente) para los
requisitos anteriores, y que permita anotar clientes, ver todos los
clientes (haciendo una pausa tras mostrar 20 datos) y buscar los que
contengan un cierto texto. También permitirá añadir artículos (pero no
ver ni buscar). De momento no permitirá ninguna operación relacionada
con Albaranes ni con Proveedores.

Dada la limitación de tiempo, lleva cuidado en no crear código para los
métodos que se te ha indicado que aún no deben tenerlo.
*/

using System;

abstract class Entidad
{
    protected int codigo;
    protected string dni;
    protected string nombre;

    public Entidad(int codigo, string dni, string nombre)
    {
        this.codigo = codigo;
        this.dni = dni;
        this.nombre = nombre;
    }

    public int GetCodigo() { return codigo; }
    public string GetDni() { return dni; }
    public string GetNombre() { return nombre; }

    public void SetNombre(string nombre) { this.nombre = nombre; }
    
    public override string ToString()
    {
        return codigo + " - " + dni + " - " + nombre;
    }
    
    public virtual bool Contiene (string texto)
    {
        return dni.ToUpper().Contains(texto.ToUpper()) ||
            nombre.ToUpper().Contains(texto.ToUpper());
    }
}

// --------------------------------

class Cliente : Entidad
{
    public Cliente(int codigo, string dni, string nombre)
        : base(codigo, dni, nombre)
    {
    }
}

// --------------------------------

class Proveedor : Entidad
{
    protected string categoria;

    public Proveedor(int codigo, string dni, string nombre, string categoria)
        : base(codigo, dni, nombre)
    {
        this.codigo = codigo;
        this.dni = dni;
        this.categoria = categoria;
    }

    public string GetCategoria() { return categoria; }
    public void SetCategoria(string categoria) { this.categoria = categoria; }
    
    public override string ToString()
    {
        return base.ToString() + " - " + categoria;
    }
    
    public override bool Contiene (string texto)
    {
        return base.Contiene(texto) ||
            categoria.ToUpper().Contains(texto.ToUpper());
    }
}

// --------------------------------

class Articulo
{
    protected int codigo;
    protected string descripcion;
    protected double precio;

    public Articulo(int codigo, string descripcion, double precio)
    {
        this.codigo = codigo;
        this.descripcion = descripcion;
        this.precio = precio;
    }

    public int GetCodigo() { return codigo; }
    public string GetDescripcion() { return descripcion; }
    public double GetPrecio() { return precio; }

    public void SetDescripcion(string descripcion)
    {
        this.descripcion = descripcion;
    }
    public void SetPrecio(double precio) 
    {
        this.precio = precio;
    }
    
    public override string ToString()
    {
        return codigo + ".- " + descripcion + " (" + precio +")";
    }
}

// --------------------------------

abstract class DocCliente
{
    protected int numero;
    protected DateTime fecha;
    protected Cliente cliente;

    public DocCliente(int numero, DateTime fecha, Cliente cliente)
    {
        // TO DO
    }

    public DocCliente(DateTime fecha, Cliente cliente)
    {
        // TO DO
    }

    public DocCliente(Cliente cliente) : this(DateTime.Now, cliente)
    {
        // TO DO
    }
    
    public void Add(LinDocCliente linea)
    {
        // TO DO
    }
}

// --------------------------------

abstract class LinDocCliente
{
    protected Articulo articulo;
    protected int cantidad;
    protected int codigoArticulo;
    protected string descripcion;
    protected double precio;

    public LinDocCliente(Articulo articulo, int cantidad)
    {
        this.articulo = articulo;
        this.cantidad = cantidad;
        codigoArticulo = articulo.GetCodigo();
        descripcion = articulo.GetDescripcion();
        precio = articulo.GetPrecio();
    }
}


// --------------------------------

class Factura : DocCliente
{
    public Factura(int numero, DateTime fecha, Cliente cliente)
        : base(numero, fecha, cliente)
    {
        // TO DO
    }

    public Factura(DateTime fecha, Cliente cliente)
        : this (0, fecha, cliente)
    {
        // TO DO: Calcular último número real de factura
    }

    public Factura(Cliente cliente) 
        : this(DateTime.Now, cliente)
    {
        // TO DO
    }
}

// --------------------------------

class LinFact : LinDocCliente
{
    public LinFact(Articulo articulo, int cantidad) :
            base(articulo, cantidad)
    {
    }
}

// --------------------------------

class Albaran : DocCliente
{
    public Albaran(int numero, DateTime fecha, Cliente cliente)
        : base(numero, fecha, cliente)
    {
        // TO DO
    }

    public Albaran(DateTime fecha, Cliente cliente)
        : this (0, fecha, cliente)
    {
        // TO DO: Calcular último número real de albarán
    }

    public Albaran(Cliente cliente) 
        : this(DateTime.Now, cliente)
    {
        // TO DO
    }
}

// --------------------------------

class LinAlb : LinDocCliente
{
    public LinAlb(Articulo articulo, int cantidad) :
            base(articulo, cantidad)
    {
    }
}

// --------------------------------

class Facturacion
{
    static void Main()
    {
        Cliente cliente = new Cliente(1, "111C", "Antonio");
        Articulo guitarra = new Articulo(1, "Fender Stratocaster", 599.95);
        Albaran albaran = new Albaran(cliente);

        albaran.Add(new LinAlb(guitarra, 1));
    }
}
