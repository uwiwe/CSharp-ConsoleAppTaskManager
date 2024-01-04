using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            while (true)
            {
                Console.WriteLine("\nGestor de Tareas");
                Console.WriteLine("1. Añadir Tarea");
                Console.WriteLine("2. Listar Tareas");
                Console.WriteLine("3. Completar Tarea");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();
                        manager.NewTask(descripcion);
                        break;

                    case "2":
                        manager.ListTasks();
                        break;

                    case "3":
                        Console.Write("Ingrese el ID de la tarea a completar: ");
                        int idCompletar = int.Parse(Console.ReadLine());
                        if (manager.CompleteTask(idCompletar))
                        {
                            Console.WriteLine("Tarea completada con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Tarea no encontrada.");
                        }
                        break;

                    case "4":
                        Console.Write("Ingrese el ID de la tarea a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        if (manager.DeleteTask(idEliminar))
                        {
                            Console.WriteLine("Tarea eliminada con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Tarea no encontrada.");
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }
    }
    public class Tarea
    {
        public int Id { get; private set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Tarea(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            Completada = false;
            FechaCreacion = DateTime.Now;
        }

    }

    public class TaskManager
    {
        public static int nextId = 1;
        public List<Tarea> Tasks { get; private set; }

        public TaskManager()
        {
            Tasks = new List<Tarea>();
        }

        public void NewTask(string descripcion)
        {
            Tarea nuevaTarea = new Tarea(nextId++, descripcion);
            Tasks.Add(nuevaTarea);
        }

        public bool DeleteTask(int id)
        {
            Tarea eliminarTarea = FindTaskById(id);
            if (eliminarTarea != null)
            {
                Tasks.Remove(eliminarTarea);
                return true;
            }
            return false;
        }

        public void ListTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No hay tareas en la lista.");
            }
            else
            {
                foreach (Tarea tarea in Tasks)
                {
                    Console.WriteLine("Tarea: " + tarea.Descripcion + ", Id: " + tarea.Id + ", Completada: " + tarea.Completada + ", Fecha: " + tarea.FechaCreacion);
                }
            }
        }

        public Tarea FindTaskById(int id)
        {
            return Tasks.FirstOrDefault(tarea => tarea.Id == id);
        }

        public bool CompleteTask(int id)
        {
            Tarea completarTarea = FindTaskById(id);
            if (completarTarea != null)
            {
                completarTarea.Completada = true;
                return true;
            }
            return false;
        }
    }
}