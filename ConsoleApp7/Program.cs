using System;
using System.Collections.Generic;

class Program
{
    class Estudiante
    {
        private static int contadorIds = 1;

        public int Id { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Carrera { get; set; }


    }

    static void Main()
    {
        List<Estudiante> listaEstudiantes = new List<Estudiante>();

        while (true)
        {
            Console.WriteLine("1. Agregar Estudiante");
            Console.WriteLine("2. Mostrar Estudiantes");
            Console.WriteLine("3. Eliminar Estudiante");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        AgregarEstudiante(listaEstudiantes);
                        break;
                    case "2":
                        MostrarEstudiantes(listaEstudiantes);
                        break;
                    case "3":
                        EliminarEstudiante(listaEstudiantes);
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del programa.");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void AgregarEstudiante(List<Estudiante> lista)
    {
        Estudiante nuevoEstudiante = new Estudiante();

        Console.WriteLine("Ingrese los datos del estudiante:");

        try
        {
            nuevoEstudiante.Nombre = PedirEntrada("Nombre: ");
            nuevoEstudiante.Apellido = PedirEntrada("Apellido: ");
            nuevoEstudiante.Edad = PedirEdad();
            nuevoEstudiante.Carrera = PedirEntrada("Carrera: ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al ingresar datos: {ex.Message}");
            return;
        }

        lista.Add(nuevoEstudiante);
        Console.WriteLine("Estudiante agregado con éxito.");
    }

    static void MostrarEstudiantes(List<Estudiante> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("Tabla de Estudiantes:");
            Console.WriteLine("ID\tNombre\tApellido\tEdad\tCarrera");
            foreach (var estudiante in lista)
            {
                Console.WriteLine($"{estudiante.Id}\t{estudiante.Nombre}\t{estudiante.Apellido}\t{estudiante.Edad}\t{estudiante.Carrera}");
            }
        }
    }

    static void EliminarEstudiante(List<Estudiante> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("No hay estudiantes para eliminar.");
            return;
        }

        MostrarEstudiantes(lista);

        try
        {
            Console.Write("Ingrese el ID del estudiante a eliminar: ");
            int idEliminar = PedirEntero();
            Estudiante estudianteEliminar = lista.Find(estudiante => estudiante.Id == idEliminar);

            if (estudianteEliminar != null)
            {
                lista.Remove(estudianteEliminar);
                Console.WriteLine("Estudiante eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar estudiante: {ex.Message}");
        }
    }

    static string PedirEntrada(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(entrada))
        {
            throw new Exception("El valor no puede estar vacío o contener solo espacios en blanco.");
        }
        return entrada;
    }

    static int PedirEdad()
    {
        while (true)
        {
            Console.Write("Edad: ");
            try
            {
                int edad = Convert.ToInt32(Console.ReadLine());
                if (edad < 0 || edad > 150) 
                {
                    throw new Exception("La edad debe estar entre 0 y 150.");
                }
                return edad;
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingrese una edad válida.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static int PedirEntero(string mensaje = "Ingrese un número: ")
    {
        while (true)
        {
            Console.Write(mensaje);

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("El número ingresado es demasiado grande o pequeño.");
            }
        }
    }
}
