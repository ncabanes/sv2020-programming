/*Alumno: Verónica (...), retoques por Nacho
 
145. (Examen del tema 6, 2017/2018): Consulta

Se desea crear un esqueleto para un sistema informático para una pequeña 
consulta médica.

Para ello, se creará una clase “Consulta”, que englobará a todas las demás. 
El sistema estará previsto para controlar:

Médicos, enfermeros y pacientes. Para todos ellos se anotará el nombre y los 
apellidos (en un único campo, con el formato "Apellidos, Nombre"), además de 
un código numérico. Tendrán un constructor que permita indicar esos dos 
parámetros, además de Getters y Setters (o propiedades) para cada uno de ellos. 
En el caso de los médicos, existirá además una "especialidad" (por ejemplo, 
"Oftalmología", junto con su Get y su Set, y un constructor adicional que 
permita indicar la especialidad además de los otros 2 datos (en el caso del 
constructor general, que no indica especialidad, se asumirá que ésta es 
"Medicina general"). Para todos ellos se deberá crear un método ToString, 
que muestre código, nombre y apellidos y (en el caso de los médicos) 
especialidad, separados por comas.

Visitas, que a su vez pueden ser Planificadas o Urgencias. Para cada visita se 
deberá anotar el paciente que se ha atendido y el médico que lo ha hecho (como 
no siempre se precisará un enfermero, este detalle se dejará para la versión 
2.0). También será preciso anotar la fecha y hora (como DateTime.Now), el motivo
de la visita y el diagnóstico. Además, para las urgencias se anotará un dato 
booleano que indique si es necesaria una visita posterior o no. Todos estos 
datos se deberán poder indicar en el constructor, y existirán Getters y Setters 
para ellos (o propiedades). El método ToString de una visita devolverá el nombre
del cliente, nombre del médico, fecha, motivo y diagnóstico, separados por " - ". 
En caso de que sea planificada, esta información será precedida por 
"Planificada - ", y en el caso de una urgencia, estará precedida por 
"Urgencia - ". El método ToString de una urgencia que tenga programada una 
visita posterior deberá terminar con " (P)".

 

El cuerpo del programa estará en el método Ejecutar de la clase Consulta. 
Este cuerpo creará dos médicos y un enfermero prefijados y un array de pacientes 
inicialmente vacío. Mostrará cinco opciones:

 -  Añadir un paciente (pidiendo sus datos por consola)

 -  Buscar pacientes, a partir de parte de su nombre o apellidos.

 -  Añadir una visita (pidiendo el tipo de visita, el código del paciente, el 
    código del médico, el motivo de la visita y el diagnóstico -la fecha no se 
    pedirá, sino que se tomará el instante actual-; si es urgencia, se preguntará 
    también si se ha planificado una visita posterior).

 -  Ver todas las visitas.

 -  Salir

Esta misma clase Consulta será la que también contenga Main.

Como no sabemos manejar ficheros, esta primera versión provisional perderá la 
información cada vez que termine una sesión.

Recuerda evitar código repetitivo tanto como sea posible, reutilizando 
constructores o métodos cuando corresponda.*/

using System;


abstract class Persona
{
    protected string apellidosYNombre;
    protected byte idPersona;

    public Persona(string apellidosYNombre, byte idPersona)
    {
        this.apellidosYNombre = apellidosYNombre;
        this.idPersona = idPersona;
    }

    public string GetApellidosYNombre() { return apellidosYNombre; }
    public byte GetIdPersona() { return idPersona; }

    public void SetApellidosYNombre(string apellidosYNombre)
    {
        this.apellidosYNombre = apellidosYNombre;
    }

    public void SetIdPersona(byte idPersona)
    {
        this.idPersona = idPersona;
    }

    public override string ToString()
    {
        return apellidosYNombre + ", ID: " + idPersona;
    }
}


//--------------------------------------------------------------------------

class Medico : Persona
{
    protected string especialidad;

    public Medico(string apellidosYNombre, byte idPersona, string especialidad)
        : base(apellidosYNombre, idPersona)
    {
        this.especialidad = especialidad;
    }

    public Medico(string apellidosYNombre, byte idPersona)
        : this(apellidosYNombre, idPersona, "Medicina general")
    {
    }


    public string GetEspecialidad() { return especialidad; }

    public void SetEspecialidad(string especialidad)
    {
        this.especialidad = especialidad;
    }

    public override string ToString()
    {
        return "Médico, " + base.ToString() + ", Especialidad: " + especialidad;
    }
}

//--------------------------------------------------------------------------

class Enfermero : Persona
{
    public Enfermero(string apellidosYNombre, byte idPersona)
        : base(apellidosYNombre, idPersona)
    {

    }

    public override string ToString()
    {
        return "Enfermero" + base.ToString();
    }
}

//--------------------------------------------------------------------------

class Paciente : Persona
{
    public Paciente(string apellidosYNombre, byte idPersona)
        : base(apellidosYNombre, idPersona)
    {

    }

    public override string ToString()
    {
        return "Paciente " + base.ToString();
    }
}

//==========================================================================

class Visita
{

    protected Paciente paciente;
    protected Medico medico;
    protected string fecha, motivoVisita, diagnostico;

    public Visita(Paciente paciente, Medico medico, string motivoVisita,
        string diagnostico)
    {
        this.paciente = paciente;
        this.medico = medico;
        fecha = Convert.ToString(DateTime.Now);
        this.motivoVisita = motivoVisita;
        this.diagnostico = diagnostico;
    }

    public Paciente GetPaciente() { return paciente; }
    public Medico GetMedico() { return medico; }
    public string GetMotivoVisita() { return motivoVisita; }
    public string GetDiagnostico() { return diagnostico; }

    public void SetPaciente(Paciente paciente)
    {
        this.paciente = paciente;
    }

    public void SetMedico(Medico medico)
    {
        this.medico = medico;
    }

    public void SetMotivoVisita(string motivoVisita)
    {
        this.motivoVisita = motivoVisita;
    }

    public void SetDiagnostico(string diagnostico)
    {
        this.diagnostico = diagnostico;
    }

    public override string ToString()
    {
        return "Atendido: " + paciente.GetApellidosYNombre() 
            + " - por Médico: " + medico.GetApellidosYNombre() 
            + " - " + fecha + " - " + motivoVisita + " - " + diagnostico;
    }

}
//--------------------------------------------------------------------------
class Planificada : Visita
{
    public Planificada(Paciente paciente, Medico medico, string motivoVisita,
            string diagnostico) 
        : base(paciente, medico, motivoVisita, diagnostico)
    {

    }

    public override string ToString()
    {
        return "Planificada - " + base.ToString();
    }
}
//--------------------------------------------------------------------------
class Urgencias : Visita
{
    protected bool necesitaRevision;

    public Urgencias(Paciente paciente, Medico medico, string motivoVisita,
            string diagnostico, bool revision) 
        : base(paciente, medico, motivoVisita, diagnostico)
    {
        this.necesitaRevision = revision;
    }

    public bool GetNecesitaRevision() { return necesitaRevision; }

    public void SetNecesitaRevision(bool revision)
    {
        this.necesitaRevision = revision;
    }

    public override string ToString()
    {
        return "Urgencia - " + base.ToString() 
            + (necesitaRevision ? " (P)" : "");
    }
}


//==========================================================================

class Consulta
{
    bool salir = false;
    const int CAPACIDAD_PACIENTES = 1000;
    const int CAPACIDAD_VISITAS = 1000;
    int cantidadPacientes = 0;
    int cantidadVisitas = 0;
    string eleccion;

    Paciente[] pacientes;
    Visita[] visitas;
    Medico med_A;
    Medico med_B;
    Enfermero enf;

    public Consulta()
    {
        pacientes = new Paciente[CAPACIDAD_PACIENTES];
        visitas = new Visita[CAPACIDAD_VISITAS];

        med_A = new Medico("Dr.Sánchez, Pepe", 1);
        med_B = new Medico("Dra.Gutiérrez, Lucía", 2, "Ginecología");
        enf = new Enfermero("Flores, Margarita", 1);
    }

    public void Ejecutar()
    {
        do
        {
            Console.WriteLine();
            MostrarMenu();
            Console.WriteLine();
            Console.Write("Elige una opción: ");
            eleccion = Console.ReadLine();

            switch (eleccion)
            {
                case "1": AnyadirPaciente(); break;
                case "2": BuscarPaciente(); break;
                case "3": AnyadirVisita(); break;
                case "4": MostrarVisitas(); break;
                case "0": salir = true; break;
                default: Console.WriteLine("Opción no válida"); break;
            }

        } while (!salir);

        Console.WriteLine("Fin de la sesión");
    }

    private void MostrarMenu()
    {
        Console.WriteLine("MENÚ:");
        Console.WriteLine("1. Añadir un paciente");
        Console.WriteLine("2. Buscar pacientes");
        Console.WriteLine("3. Añadir visita");
        Console.WriteLine("4. Ver todas las visitas");
        Console.WriteLine("0. Salir");
    }

    private void AnyadirPaciente()
    {
        if (cantidadPacientes < CAPACIDAD_PACIENTES)
        {
            Console.WriteLine();
            string apellidos = Pedir("Apellidos del paciente: ");
            string nombre = Pedir("Nombre del paciente: ");

            pacientes[cantidadPacientes] = new Paciente(
                apellidos + "," + nombre,
                Convert.ToByte(cantidadPacientes + 1));

            cantidadPacientes++;
        }
        else
        {
            Console.WriteLine("Alcanzado número máximo de pacientes");
        }
    }

    

    private void BuscarPaciente()
    {
        if (cantidadPacientes > 0)
        {
            Console.WriteLine();
            string busqueda = Pedir("Nombre o apellidos a buscar:");
            bool encontrado = false;

            for (byte i = 0; i < cantidadPacientes; i++)
            {
                if (pacientes[i].GetApellidosYNombre().ToUpper().
                    Contains(busqueda.ToUpper()))
                {
                    Console.WriteLine(pacientes[i]);
                    encontrado = true;
                }
            }
            if (! encontrado)
                Console.WriteLine("No se ha encontrado");
        }
        else
        {
            Console.WriteLine("Sin pacientes en el registro");
        }
    }

    private void AnyadirVisita()
    {
        Paciente paciente;
        Medico medico;
        string motivoVisita, diagnostico;
        byte numPaciente, numMedico;

        if (cantidadVisitas < CAPACIDAD_VISITAS)
        {
            Console.WriteLine();

            Console.Write("> Marque U si es un episodio de Urgencias " +
                "en otro caso se consignará como Consulta Planificada: ");
            ConsoleKeyInfo indicaUrgencias = Console.ReadKey();

            Console.WriteLine();
            Console.Write("Elija el código del paciente, tomando como" +
                " referencia el listado mostrado a continuación:\n");
            MostrarPacientes();
            do
            {
                Console.Write("\n> Indique el ID del paciente del listado" +
                    " superior: ");
                numPaciente = Convert.ToByte(Console.ReadLine());
            }
            while (numPaciente > cantidadPacientes);
            paciente = DevolverPaciente(numPaciente);

            if (paciente == null)
            {
                Console.WriteLine("Paciente no indicado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Elija el código del especialista, " +
                "tomando como referencia el siguiente listado de médicos " +
                "disponibles.");
            MostrarMedicos();
            Console.Write("> Indique el ID del médico del listado superior: ");
            numMedico = Convert.ToByte(Console.ReadLine());
            medico = DevolverMedico(numMedico);

            motivoVisita = Pedir("> Motivo de la visita: ");
            diagnostico = Pedir("> Diagnóstico: ");

            if (indicaUrgencias.Key == ConsoleKey.U)
            {
                Console.WriteLine();
                Console.WriteLine("> Marque X si se ha planificado una " +
                    "revisión o cualquier tecla en otro caso:");
                ConsoleKeyInfo indicaRevision = Console.ReadKey();

                if (indicaRevision.Key == ConsoleKey.X)
                {
                    Console.WriteLine(">>> Visita grabada como URGENCIA " +
                    "CON revisión posterior");
                    visitas[cantidadVisitas] = new Urgencias(paciente,
                        medico, motivoVisita, diagnostico, true);
                }
                else
                {
                    Console.WriteLine("\n>>> Visita grabada como URGENCIA " +
                    "sin revisión posterior");

                    visitas[cantidadVisitas] = new Urgencias(paciente,
                    medico, motivoVisita, diagnostico, false);
                }

                cantidadVisitas++;
            }
            else
            {
                Console.WriteLine("\n>>> Visita grabada como consulta " +
                   "planificada");
                visitas[cantidadVisitas] = new Planificada(paciente,
                    medico, motivoVisita, diagnostico);

                cantidadVisitas++;
            }
        }
        else
        {
            if (cantidadVisitas >= CAPACIDAD_VISITAS - 1)
            {
                Console.WriteLine("No se pueden añadir más visitas");
            }
        }
    }

    private void MostrarPacientes()
    {
        for (byte i = 0; i < cantidadPacientes; i++)
        {
            Console.WriteLine(pacientes[i]);
        }
    }

    private Paciente DevolverPaciente(byte id)
    {
        for (byte i = 0; i < cantidadPacientes; i++)
        {
            if (pacientes[i].GetIdPersona() == id)
                return pacientes[i];
        }
        return null;
    }

    private void MostrarMedicos()
    {
        Console.WriteLine(" - " + med_A);
        Console.WriteLine(" - " + med_B);
    }

    private Medico DevolverMedico(byte id)
    {
        if (id == med_B.GetIdPersona())
            return med_B;
        else
            return med_A;
    }


    private void MostrarVisitas()
    {
        Console.WriteLine();
        for (byte i = 0; i < cantidadVisitas; i++)
        {
            Console.WriteLine(visitas[i]);
        }
    }

    // Función auxiliar para simplificar introd. datos
    private static string Pedir(string concepto)
    {
        Console.Write(concepto);
        string respuesta = Console.ReadLine();

        return respuesta;
    }

    // Cuerpo del programa
    static void Main()
    {
        Consulta c = new Consulta();
        c.Ejecutar();
    }

}
