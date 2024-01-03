using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            // Añadir tareas
            manager.NewTask("Comprar leche");
            manager.NewTask("Enviar correo electrónico");

            // Listar tareas
            manager.ListTasks();
        }
    }
    public class Tarea
    {
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Tarea(string descripcion)
        {
            Descripcion = descripcion;
            Completada = false;
            FechaCreacion = DateTime.Now;
        }

    }

    public class TaskManager
    {
        public List<Tarea> Tasks { get; private set; }

        public TaskManager()
        {
            Tasks = new List<Tarea>();
        }

        public void NewTask(string descripcion)
        {
            Tarea nuevaTarea = new Tarea(descripcion);
            Tasks.Add(nuevaTarea);
        }

        public void ListTasks()
        {
            foreach (Tarea tarea in Tasks)
            {
                Console.WriteLine("Tarea: " + tarea.Descripcion + ", Completada: " + tarea.Completada + ", Fecha: " + tarea.FechaCreacion);
            }
        }
        // añadir métodos para listar, completar o eliminar tareas.
    }
}